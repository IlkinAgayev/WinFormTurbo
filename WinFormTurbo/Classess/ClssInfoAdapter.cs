using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormTurbo.Utils;

namespace WinFormTurbo.Classess
{
    class ClssInfoAdapter
    {
        SqlUtils sqlUtils = SqlUtils.GetInstance();
        public DataTable GetBrands()
        {   
            string query = "SELECT ID, BRAND_NAME FROM BRANDS";
            return sqlUtils.GetDataWithAdapter(query);
        }
        public DataTable GetModels(String brandId)
        {
            string query = $"SELECT ID, MODEL_NAME FROM MODELS WHERE BRAND_ID = {brandId}";
            return sqlUtils.GetDataWithAdapter(query);
        }
        public DataTable GetGeneralInfo(string typeId)
        {
            string query = $"SELECT ID, NAME FROM GENERAL_INFO WHERE TYPE_ID = {typeId}";
            return sqlUtils.GetDataWithAdapter(query);
        }
        public DataTable GetCity() 
        {
            string query = "SELECT ID, CITY_NAME FROM CITIES";
            return sqlUtils.GetDataWithAdapter(query);
        }
        public DataTable GetImages(string adsID)
        {
            string query = $"SELECT [ID],[CAR_IMAGE] FROM[dbo].[TB_ADS_IMAGES] WHERE ADS_ID = {adsID}";
            return sqlUtils.GetDataWithAdapter(query);
        }
    }
}
