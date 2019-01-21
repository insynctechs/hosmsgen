using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Staffs : IDisposable
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
       
        public int addStaffs(string first_name, string last_name,int department_id, string designation,
            string qualification, int staff_type_id,char gender, DateTime dob,  string nationality, string legal_id, 
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, bool active, int user_type_id)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[20];
                sqlParam[0] = new SqlParameter("@first_name",first_name);
                sqlParam[1] = new SqlParameter("@last_name", last_name);
                sqlParam[2] = new SqlParameter("@department_id", department_id);
                sqlParam[3] = new SqlParameter("@designation",designation);
                sqlParam[4] = new SqlParameter("@qualification", qualification);
                sqlParam[5] = new SqlParameter("@staff_type_id", staff_type_id);
                sqlParam[6] = new SqlParameter("@gender", gender);
                sqlParam[7] = new SqlParameter("@dob", dob);
                sqlParam[8] = new SqlParameter("@nationality", nationality);
                sqlParam[9] = new SqlParameter("@legal_id", legal_id);
                sqlParam[10] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[11] = new SqlParameter("@address", address);
                sqlParam[12] = new SqlParameter("@city", city);
                sqlParam[13] = new SqlParameter("@state", state);
                sqlParam[14] = new SqlParameter("@zip", zip);
                sqlParam[15] = new SqlParameter("@phone", phone);
                sqlParam[16] = new SqlParameter("@email", email);                
                sqlParam[17] = new SqlParameter("@added_id", LoggedUser.id);
                sqlParam[18] = new SqlParameter("@active", active);
                sqlParam[19] = new SqlParameter("@user_type_id", user_type_id);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspStaffs_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editStaffs(int id, int user_id, string first_name, string last_name, int department_id, string designation,
            string qualification, int staff_type_id, char gender, DateTime dob, string nationality, string legal_id,
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, bool active, int user_type_id)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[22];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@user_id", user_id);
               sqlParam[2] = new SqlParameter("@first_name", first_name);
                sqlParam[3] = new SqlParameter("@last_name", last_name);
                sqlParam[4] = new SqlParameter("@department_id", department_id);
                sqlParam[5] = new SqlParameter("@designation", designation);
                sqlParam[6] = new SqlParameter("@qualification", qualification);
                sqlParam[7] = new SqlParameter("@staff_type_id", staff_type_id);
                sqlParam[8] = new SqlParameter("@gender", gender);
                sqlParam[9] = new SqlParameter("@dob", dob);
                sqlParam[10] = new SqlParameter("@nationality", nationality);
                sqlParam[11] = new SqlParameter("@legal_id", legal_id);
                sqlParam[12] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[13] = new SqlParameter("@address", address);
                sqlParam[14] = new SqlParameter("@city", city);
                sqlParam[15] = new SqlParameter("@state", state);
                sqlParam[16] = new SqlParameter("@zip", zip);
                sqlParam[17] = new SqlParameter("@phone", phone);
                sqlParam[18] = new SqlParameter("@email", email);
                sqlParam[19] = new SqlParameter("@active", active);                
                sqlParam[20] = new SqlParameter("@modified_id", LoggedUser.id);
                sqlParam[21] = new SqlParameter("@user_type_id", user_type_id);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspStaffs_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                Helpers.CommonLogger.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable GetStaffs(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspStaffs_Get", sqlParam);
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
                dt.Rows.Add(new object[] { "D.first_name", "First Name" });
                dt.Rows.Add(new object[] { "D.last_name", "Last Name" });
                dt.Rows.Add(new object[] { "D.phone", "Phone No" });
                dt.Rows.Add(new object[] { "De.name", "Department" });
                dt.Rows.Add(new object[] { "ST.type_title", "Staff Type" });
                dt.Rows.Add(new object[] { "D.active", "Active" });
                return dt;
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetDepartmentsCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetDepartmentsIDName(id);
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

        public DataTable GetDepartmentsIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspDepartments_Combo", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetStaffTypeCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetStaffTypeIDName(id);
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

        public DataTable GetStaffTypeIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspStaffType_Combo", sqlParam);
                return dt.Tables[0];
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
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspStaffs_GetSingle", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                Helpers.CommonLogger.Error(ex.Message, ex);
                return null;
            }

        }


        public DataTable GetUserRolesCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetUserRolesIDName(id);
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

        public DataTable GetUserRolesIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspUserTypes_Combo", sqlParam);
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
