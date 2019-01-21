using Microsoft.Win32;
namespace HospitalERP.Helpers
{
    internal class DBHelper
    {        
        public static string Constr
        {
            get
            {
                //return System.Configuration.ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"].ConnectionString;

                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP\dset");
                string server="", database="", user_id="", user_pwd="";
                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    server = key.GetValue("srvr").ToString();
                    database = key.GetValue("catlog").ToString();
                    user_id = key.GetValue("usrkey").ToString();
                    user_pwd = key.GetValue("usrval").ToString();

                }
                string strConn = "Data Source=" + server + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + user_id + ";Password=" + user_pwd;
                return strConn;
            }
        }
    }
}
