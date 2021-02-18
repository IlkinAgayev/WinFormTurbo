using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormTurbo.Classess;

namespace WinFormTurbo
{
    public class CommandMethods
    {
        ClssInfoAdapter clssInfoAdapter = new ClssInfoAdapter();

        public void SetGeneralInfo(LookUpEdit lkUpEdtGenInfo, string typeId)
        {            
            lkUpEdtGenInfo.Properties.DataSource = clssInfoAdapter.GetGeneralInfo(typeId);
            lkUpEdtGenInfo.Properties.DisplayMember = "NAME";
            lkUpEdtGenInfo.Properties.ValueMember = "ID";
        }

        public void SetBrandData(LookUpEdit lkUpEdtBrand)
        {
            lkUpEdtBrand.Properties.DataSource = clssInfoAdapter.GetBrands();
            lkUpEdtBrand.Properties.DisplayMember = "BRAND_NAME";
            lkUpEdtBrand.Properties.ValueMember = "ID";
        }

        public void SetYears(LookUpEdit lkUpEdtYear)
        {
            List<int> listYears = new List<int>();
            int currentYear = DateTime.Now.Year;
            for (int i = 1960; i <= currentYear; i++)
            {
                listYears.Add(i);
            }
            lkUpEdtYear.Properties.DataSource = listYears;
        }

        public void SetCityData(LookUpEdit lkUpEdtCity)
        {
            lkUpEdtCity.Properties.DataSource = clssInfoAdapter.GetCity();
            lkUpEdtCity.Properties.DisplayMember = "CITY_NAME";
            lkUpEdtCity.Properties.ValueMember = "ID";
        }

        public void SetModelData(LookUpEdit lkUpEdtModel, string brandId)
        {
            lkUpEdtModel.Properties.DataSource = clssInfoAdapter.GetModels(brandId);
            lkUpEdtModel.Properties.DisplayMember = "MODEL_NAME";
            lkUpEdtModel.Properties.ValueMember = "ID";
        }

    }
}
