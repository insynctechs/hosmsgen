using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace HospitalERP.Procedures
{
    class Medicines : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
       
        public int InsertProcedure(string name, string desc, int type,  bool active)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];
            sqlParam[0] = new SqlParameter("@name", name);
            sqlParam[1] = new SqlParameter("@desc", desc);
            sqlParam[2] = new SqlParameter("@type", type);            
            sqlParam[3] = new SqlParameter("@active", active);
            Int32 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspMedicines_Add", sqlParam).ToString());
            return Id;
        }

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMedicines_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public int editProcedures(int id, string name, string desc, int type,  bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", name);
                sqlParam[2] = new SqlParameter("@desc", desc);
                sqlParam[3] = new SqlParameter("@type", type);
                sqlParam[4] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspMedicines_Edit", sqlParam).ToString());
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
                //dt.Rows.Add(new object[] { "p.fee", "Fee" });                
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
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMedicines_Single", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }


        public DataTable getMedicinesFromApptID(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMedicines_PatientAppt_Get", sqlParam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }


        public int addMedicines(int patientid, int doctorid, int apptid, int medid, string prescription)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@doctor_id", doctorid);
                sqlParam[1] = new SqlParameter("@patient_id", patientid);
                sqlParam[2] = new SqlParameter("@appointment_id", apptid);
                sqlParam[3] = new SqlParameter("@medicine_id", medid);
                sqlParam[4] = new SqlParameter("@prescription", prescription);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspMedicines_AddPatientMedicines", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editMedicines(int id, int patientid, int doctorid, int apptid, int medicine_id, string prescription)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[6];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@doctor_id", doctorid);
                sqlParam[2] = new SqlParameter("@patient_id", patientid);
                sqlParam[3] = new SqlParameter("@appointment_id", apptid);
                sqlParam[4] = new SqlParameter("@medicine_id", medicine_id);
                sqlParam[5] = new SqlParameter("@prescription", prescription);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspMedicines_EditPatientMedicines", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public DataTable MedicinesCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Rows.Add(new object[] { "0", "Select Medicine" });
                DataTable dt1 = new DataTable();
                dt1 = GetMedicinesIDName(id);
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

        public DataTable GetMedicinesIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMedicines_Combo", sqlParam);
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

        public string getMedicinePrescription(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMedicines_GetPrescription", sqlParam);
                return ds.Tables[0].Rows[0].ItemArray[0].ToString()+"^>$<"+ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }
        }

        public int DeletePatientMedicine(int pat_med_id)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", pat_med_id);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspMedicines_DeletePatientMedicines", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return -1;
            }
            return ret;
        }

    }
}
