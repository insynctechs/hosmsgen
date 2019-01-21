using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace HospitalERP.Procedures
{
    class ProcTypes : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
       
        
        public int InsertProc(string DepartmentName,string description, bool Active)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@type_name", DepartmentName);
            sqlParam[1] = new SqlParameter("@description", description);
            sqlParam[2] = new SqlParameter("@active", Active);
            Int32 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspProcedureTypes_Add", sqlParam).ToString());
            return Id;
        }

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedureTypes_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetProcTypesIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedureTypes_Combo", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public int editTypes(int id, string name, string desc, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", name);
                sqlParam[2] = new SqlParameter("@desc", desc);
                sqlParam[3] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspProcedureTypes_Edit", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
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
                dt.Rows.Add(new object[] { "type_name", "Name" });
                dt.Rows.Add(new object[] { "active", "Active" });
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable ProcTypesCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetProcTypesIDName(id);
                foreach (DataRow dr in dt1.Rows)
                {
                    dt.Rows.Add(dr.ItemArray);
                }
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
