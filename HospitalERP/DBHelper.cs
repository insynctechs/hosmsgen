using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace HospitalERP.Helpers
{
    internal class DBUtility
    {
        //Get the connection string from App config file.  
        internal static string GetConnectionString()
        {
            //Util-2 Assume failure.  
            string returnValue = null;

            //Util-3 Look for the name in the connectionStrings section.  
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];

            //ConnectionStringSettings settings =
            //ConfigurationManager.ConnectionStrings["conString"];


            //If found, return the connection string.  
            if (settings != null)
              returnValue = settings.ConnectionString;

            return returnValue;
        }

        public DataSet GetDataSetFromWebApi(string path)
        {
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(res);
                return ds;
            }
            return null;
        }

        public DataTable GetDataTableFromWebApi(string path)
        {
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                DataSet dt = JsonConvert.DeserializeObject<DataSet>(res);
                return dt.Tables[0];
            }
            return null;
        }

        public int GetExecuteNonQueryResFromWebApi(string path)
        {
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                int ret = JsonConvert.DeserializeObject<int>(res);
                return ret;
            }
            return 0;
        }


        public string GetExecuteNonQueryStringResFromWebApi(string path)
        {
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                string ret = JsonConvert.DeserializeObject<string>(res);
                return ret;
            }
            else
                return "Error";// + response.StatusCode.ToString();
        }


    }
}
