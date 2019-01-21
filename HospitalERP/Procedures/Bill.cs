using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Bill : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        
        public int AddBill(int aid, int pid, decimal amount, int type, int userid)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@appointment_id", aid);
                sqlParam[1] = new SqlParameter("@patient_id", pid);               
                sqlParam[2] = new SqlParameter("@bill_amount", amount);
                sqlParam[3] = new SqlParameter("@bill_type", type);
                sqlParam[4] = new SqlParameter("@user_id", userid);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspBill_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editBill(int id, decimal amount, decimal paid, decimal balance, int status, int userid)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@id", id);               
                sqlParam[1] = new SqlParameter("@amount", amount);
                sqlParam[2] = new SqlParameter("@paid", paid);
                sqlParam[3] = new SqlParameter("@balance", balance);
                sqlParam[4] = new SqlParameter("@status", status);
                sqlParam[5] = new SqlParameter("@user", userid);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspBill_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public DataTable GetAppointmentBill(int aid, int pid, int type)
        {
            
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@appointment_id", aid);
                sqlParam[1] = new SqlParameter("@patient_id", pid);
                sqlParam[2] = new SqlParameter("@bill_type", type);              
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBill_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetAppointmentAllBills(int aid, int pid)
        {

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@appointment_id", aid);
                sqlParam[1] = new SqlParameter("@patient_id", pid);                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBill_GetAllForApp", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBill(int id)
        {

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBill_GetSingle", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBillCreatedUser(int id)
        {

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspUsers_GetDetails", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBillTypes(int hasall = 0)
        {

            try
            {
               
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillTypes_Get");
                if (hasall == 1)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "Choose One";
                    dt.Tables[0].Rows.InsertAt(dr, 0);
                }
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBillStatus(int hasall = 0)
        {

            try
            {

                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillStatus_Get");
                if (hasall == 1)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "All";
                    dt.Tables[0].Rows.InsertAt(dr, 0);
                }
                else if (hasall == 11)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "Choose One";
                    dt.Tables[0].Rows.InsertAt(dr, 0);
                }
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable BillSearchValues()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "All", "All" });
                dt.Rows.Add(new object[] { "b.bill_number", "Bill Number" });
                dt.Rows.Add(new object[] { "b.bill_status", "Bill Status" });
                dt.Rows.Add(new object[] { "p.patient_number", "Patient Number" });
                dt.Rows.Add(new object[] { "p.first_name", "Patient First Name" });
                dt.Rows.Add(new object[] { "p.last_name", "Patient Last Name" });
                dt.Rows.Add(new object[] { "p.phone", "Patient Phone Number" });                
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable SearchBills(string SearchBy, string SearchValue, DateTime date, bool datesearch)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                sqlParam[2] = new SqlParameter("@date", date);
                sqlParam[3] = new SqlParameter("@datesearch", datesearch);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBill_Search", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable BillsForPatient(int patientId)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@patient_id", patientId);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillHistory_ForPatient", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public int UpdateBillDetails(DataTable dtBill, int appId)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@List", dtBill);
                sqlParam[1] = new SqlParameter("@appId", appId);
                sqlParam[0].SqlDbType = SqlDbType.Structured;
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspBillDetails_Add", sqlParam).ToString());
                return ret;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message + ";" + ex.StackTrace + ";" + ex.InnerException, ex);
                return ret;
            }

        }

        public DataTable getBillDetails(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillingDetails_Get", sqlParam);
                return ds.Tables[0];
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
