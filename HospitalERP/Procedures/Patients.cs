using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Patients : IDisposable
    {

        string conn = HospitalERP.Helpers.DBHelper.Constr;
        
        public int addPatients(string first_name, string last_name, char gender, DateTime dob, string nationality, string legal_id,
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, string history, string allergies, int loggedid)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[16];
                sqlParam[0] = new SqlParameter("@first_name", first_name);
                sqlParam[1] = new SqlParameter("@last_name", last_name);           
                sqlParam[2] = new SqlParameter("@gender", gender);
                sqlParam[3] = new SqlParameter("@dob", dob);
                sqlParam[4] = new SqlParameter("@nationality", nationality);
                sqlParam[5] = new SqlParameter("@legal_id", legal_id);
                sqlParam[6] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[7] = new SqlParameter("@address", address);
                sqlParam[8] = new SqlParameter("@city", city);
                sqlParam[9] = new SqlParameter("@state", state);
                sqlParam[10] = new SqlParameter("@zip", zip);
                sqlParam[11] = new SqlParameter("@phone", phone);
                sqlParam[12] = new SqlParameter("@email", email);
                sqlParam[13] = new SqlParameter("@history", history);
                sqlParam[14] = new SqlParameter("@allergies", allergies);
                sqlParam[15] = new SqlParameter("@loggedid", loggedid);
                
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspPatients_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int existPatients(string first_name, string last_name, char gender, DateTime dob, string nationality, string phone)
        {
            int ret = 0;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@first_name", first_name);
                sqlParam[1] = new SqlParameter("@last_name", last_name);
                sqlParam[2] = new SqlParameter("@gender", gender);
                sqlParam[3] = new SqlParameter("@dob", dob);
                sqlParam[4] = new SqlParameter("@nationality", nationality);
                sqlParam[5] = new SqlParameter("@phone", phone);
                
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspPatients_Exists", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editPatients(int id, string first_name, string last_name, char gender, DateTime dob, string nationality, string legal_id,
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, string history, string allergies, int loggedid)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[17];
                sqlParam[0] = new SqlParameter("@id", id);               
                sqlParam[1] = new SqlParameter("@first_name", first_name);
                sqlParam[2] = new SqlParameter("@last_name", last_name);
                sqlParam[3] = new SqlParameter("@gender", gender);
                sqlParam[4] = new SqlParameter("@dob", dob);
                sqlParam[5] = new SqlParameter("@nationality", nationality);
                sqlParam[6] = new SqlParameter("@legal_id", legal_id);
                sqlParam[7] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[8] = new SqlParameter("@address", address);
                sqlParam[9] = new SqlParameter("@city", city);
                sqlParam[10] = new SqlParameter("@state", state);
                sqlParam[11] = new SqlParameter("@zip", zip);
                sqlParam[12] = new SqlParameter("@phone", phone);
                sqlParam[13] = new SqlParameter("@email", email);
                sqlParam[14] = new SqlParameter("@history", history);
                sqlParam[15] = new SqlParameter("@allergies", allergies);
                sqlParam[16] = new SqlParameter("@loggedid", loggedid);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspPatients_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

      

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspPatients_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetRecordsDetailedSearch(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspPatients_GetDetailedSearch", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }


        public DataTable SearchValues(int hasall=1)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                if(hasall ==1)
                    dt.Rows.Add(new object[] { "All", "All" });
                dt.Rows.Add(new object[] { "phone", "Phone Number" });
                dt.Rows.Add(new object[] { "patient_number", "Patient Number" });
                dt.Rows.Add(new object[] { "first_name", "First Name" });
                dt.Rows.Add(new object[] { "last_name", "Last Name" });
                
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable RptSearchValues(int hasall = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                if (hasall == 1)
                    dt.Rows.Add(new object[] { "All", "All" });
                dt.Rows.Add(new object[] { "p.phone", "Phone Number" });
                dt.Rows.Add(new object[] { "p.patient_number", "Patient Number" });
                dt.Rows.Add(new object[] { "p.first_name", "First Name" });
                dt.Rows.Add(new object[] { "p.last_name", "Last Name" });

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
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspPatients_GetSingle", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable getDetailedPatientRecordFromID(int id, int aid=0)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@aid", aid);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspPatients_GetDetailed", sqlParam);
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
