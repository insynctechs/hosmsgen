using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Departments : IDisposable 
    {
        
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        

        
        public int addTypes(string type_title,string type_description,  bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@name", type_title);
                sqlParam[1] = new SqlParameter("@description", type_description);
                sqlParam[2] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDepartments_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editTypes(int id,string name, string desc, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];                
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", name);
                sqlParam[2] = new SqlParameter("@desc", desc);
                sqlParam[3] = new SqlParameter("@active", active);                
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDepartments_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable GetDepartments(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspDepartments_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
            
        }

        public DataTable SearchValues()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "All", "All" });
                //dt.Rows.Add(new object[] { "id", "ID" });
                dt.Rows.Add(new object[] { "name", "Name" });
                dt.Rows.Add(new object[] { "active", "Active" });
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public void Dispose()
        {
            conn = null;           

        }


    }
}
