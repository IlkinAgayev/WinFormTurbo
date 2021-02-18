using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTurbo.Utils;

namespace WinFormTurbo
{
    public partial class frmTurbo : Form
    {
        CommandMethods commandMethods = new CommandMethods();
        public frmTurbo()
        {
            InitializeComponent();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            FrmAddCar frmAddCar = new FrmAddCar();
            frmAddCar.ShowDialog();
        }

        private void frmTurbo_Load(object sender, EventArgs e)
        {
            commandMethods.SetBrandData(lkUpEdtBrand);
            commandMethods.SetGeneralInfo(lkUpEdtCurrency, "3");
            commandMethods.SetYears(lkUpEdtYearBegin);
            commandMethods.SetYears(lkUpEdtYearEnd);
            commandMethods.SetCityData(lkUpEdtCity);
            GetCars();
        }

        private void lkUpEdtBrand_EditValueChanged(object sender, EventArgs e)
        {
            commandMethods.SetModelData(lkUpEdtModel, lkUpEdtBrand.EditValue.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetCars();
        }

        private void GetCars()
        {
            string query = $@"SELECT 
            ADS.[ID],
            ADS.[PRICE],
            BRD.BRAND_NAME + '  ' + MDL.MODEL_NAME CAR_FULL_NAME,
            ADS.YEAR,
            GN1.NAME ,
            ADS.WOLK,
            GN.NAME CITY_NAME,
             (SELECT TOP(1) IMG.CAR_IMAGE FROM TB_ADS_IMAGES IMG WHERE IMG.ADS_ID = ADS.ID) CAR_IMAGE
            FROM[dbo].[TB_ADS] ADS
            JOIN MODELS MDL ON MDL.ID = ADS.MODEL_ID
            JOIN BRANDS BRD ON MDL.BRAND_ID = BRD.ID
            JOIN GENERAL_INFO GN ON GN.ID = ADS.CITY_ID
            JOIN GENERAL_INFO GN1 ON GN1.ID = ADS.ENGINE_SIZE_ID
            WHERE 1=1";
          
            if (lkUpEdtBrand.EditValue != null)
            {
                query = query+ $" AND MDL.BRAND_ID = {lkUpEdtBrand.EditValue}";
            }
            if (lkUpEdtModel.EditValue != null)
            {
                query = query+ $" AND ADS.[MODEL_ID] = {lkUpEdtModel.EditValue}";
            }
            if (txtPriceMin.EditValue != null)
            {
                query = query+ $" AND ADS.[PRICE] >= {txtPriceMin.EditValue}";
            }
            if (txtPriceMax.EditValue != null)
            {
                query = query+ $" AND ADS.[PRICE] <= {txtPriceMax.EditValue}";
            }
            if (lkUpEdtYearBegin.EditValue != null)
            {
                query = query+ $" AND ADS.[YEAR] >= {lkUpEdtYearBegin.EditValue}";
            }
            if (lkUpEdtYearEnd.EditValue != null)
            {
                query = query+ $" AND ADS.[YEAR] <= {lkUpEdtYearEnd.EditValue}";
            }
            if (lkUpEdtCity.EditValue != null)
            {
                query = query+ $" AND ADS.[CITY_ID] = {lkUpEdtCity.EditValue}";
            }
            DataTable dtTableCars = SqlUtils.GetInstance().GetDataWithAdapter(query);
            grdCntrlCars.DataSource = dtTableCars;
        }

        private int Test()
        {
            return 0;
        }
    }
}
