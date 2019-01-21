using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;


namespace HospitalERP.Procedures
{
    class Appointments : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;       

        public int addAppointment(int patient_id, int doctor_id, DateTime meet_date, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@patient_id", patient_id);
                sqlParam[1] = new SqlParameter("@doctor_id", doctor_id);
                sqlParam[2] = new SqlParameter("@meet_date", meet_date);
                sqlParam[3] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }
        public int editAppointmentSignature(int id, string signature,string consent_details, DateTime consent_date)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@signature", signature);
                sqlParam[2] = new SqlParameter("@consent_details", consent_details);
                sqlParam[3] = new SqlParameter("@consent_date", consent_date);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_EditSignature", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }


        public int ReferAppointment(int patient_id, int doctor_id, DateTime meet_date, int status, int refer_by, int prev_appt)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@patient_id", patient_id);
                sqlParam[1] = new SqlParameter("@doctor_id", doctor_id);
                sqlParam[2] = new SqlParameter("@meet_date", meet_date);
                sqlParam[3] = new SqlParameter("@status", status);
                sqlParam[4] = new SqlParameter("@refer_by", refer_by);
                sqlParam[5] = new SqlParameter("@prev_appt", prev_appt);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Refer", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }
        public int editAppointment(int app_id, string notes, string history, string allergies, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@id", app_id);
                sqlParam[1] = new SqlParameter("@notes", notes);
                sqlParam[2] = new SqlParameter("@history", history);
                sqlParam[3] = new SqlParameter("@allergies", allergies);
                sqlParam[4] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable getAllAppointmentsForDate(DateTime meet_date, int doctor_id, int status=0 )
        {
            
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@meet_date", meet_date);
                sqlParam[1] = new SqlParameter("@doctor_id", doctor_id);
                sqlParam[2] = new SqlParameter("@status", status);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspAppointments_GetForDateDoc", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
            
        }

        public DataTable getAppointmentStatus(int hasall=0)
        {

            try
            {
                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspAppointmentStatus_Get");
                if (hasall == 1)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "All";
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

        public int DeleteAppointment(int id, int pid, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@patient_id", pid);
                sqlParam[2] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Delete", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return -1;
            }
            return ret;
        }

        public DataTable getAppointmentDetailsForBilling(int aid)
        {

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@aid", aid);                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspAppointments_GetForBilling", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public int GetBillLockStatus(int app_id)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@app_id", app_id);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspGetBillLock", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return -1;
            }
            return ret;
        }

        public void Dispose()
        {
            conn = null;           
        }
    }
}
