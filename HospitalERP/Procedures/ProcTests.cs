using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace HospitalERP.Procedures
{
    class ProcTests : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
       
        public int InsertProcedure(string name, string desc, int type, decimal fee, bool active)
        {
            SqlParameter[] sqlParam = new SqlParameter[5];
            sqlParam[0] = new SqlParameter("@name", name);
            sqlParam[1] = new SqlParameter("@desc", desc);
            sqlParam[2] = new SqlParameter("@type", type);
            sqlParam[3] = new SqlParameter("@fee", fee);
            sqlParam[4] = new SqlParameter("@active", active);
            Int32 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspProcedures_Add", sqlParam).ToString());
            return Id;
        }

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedures_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public int editProcedures(int id, string name, string desc, int type, decimal fee, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", name);
                sqlParam[2] = new SqlParameter("@desc", desc);
                sqlParam[3] = new SqlParameter("@type", type);
                sqlParam[4] = new SqlParameter("@fee", fee);
                sqlParam[5] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspProcedures_Edit", sqlParam).ToString());
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
                dt.Rows.Add(new object[] { "p.name", "Name" });
                dt.Rows.Add(new object[] { "t.type_name", "Type" });
                dt.Rows.Add(new object[] { "p.fee", "Fee" });                
                dt.Rows.Add(new object[] { "p.active", "Active" });
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable getRecordFromID(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedures_Single", sqlParam);
                return dt.Tables[0];
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
