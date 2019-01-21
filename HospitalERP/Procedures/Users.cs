using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Users : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        
        public int ValidateLogin(string empid, string pwd)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@empid", empid);
                sqlParam[1] = new SqlParameter("@pass", pwd);
                int ret = Convert.ToInt32(SqlHelper.ExecuteScalar(HospitalERP.Helpers.DBHelper.Constr, CommandType.StoredProcedure, "uspUsers_ValidateLogin", sqlParam));
                return ret;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return 0;
            }
        }

        public DataTable GetLoggedUser(string empid)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@empid", empid);                
                DataSet dt = SqlHelper.ExecuteDataset(HospitalERP.Helpers.DBHelper.Constr, CommandType.StoredProcedure, "uspUsers_LoggedUser", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public int SetLoginDate(string empid )
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@empid", empid);
                int ret = Convert.ToInt32(SqlHelper.ExecuteScalar(HospitalERP.Helpers.DBHelper.Constr, CommandType.StoredProcedure, "uspUsers_SetLogDate", sqlParam));
                return ret;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return 0;
            }
        }

        public int SetPassword(string empid, string pass, int utype)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@empid", empid);
                sqlParam[1] = new SqlParameter("@pass", pass);
                sqlParam[2] = new SqlParameter("@utype", utype);
                int ret = Convert.ToInt32(SqlHelper.ExecuteScalar(HospitalERP.Helpers.DBHelper.Constr, CommandType.StoredProcedure, "uspUsers_SetPwdHash", sqlParam));
                return ret;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return 0;
            }
        }

        public void Dispose()
        {
            conn = null;            
            
        }


    }

    
}
