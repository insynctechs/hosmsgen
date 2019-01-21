using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalERP.Procedures
{
    class LoggedUser
    {

        public static int id;
        public static string emp_id;
        public static int staff_id;
        public static string name;
        public static int type_id;
        public static string type_name;
        public static string last_log_date;
        public static string phone;
        public static string tbl_name;
        public static string gender;
        public static string nationality;
        public static string designation;
        public static int age;
        public static string dob;
        public static string department;
        public static string staff_type;

        public static void setLoggedUser(DataTable dtUser)
        {
            id = Int32.Parse(dtUser.Rows[0]["id"].ToString());
            emp_id = dtUser.Rows[0]["emp_id"].ToString();
            type_id = Int32.Parse(dtUser.Rows[0]["user_type_id"].ToString());
            type_name = dtUser.Rows[0]["type_name"].ToString();
            phone = dtUser.Rows[0]["staff_phone"].ToString();
            last_log_date = String.IsNullOrEmpty(dtUser.Rows[0]["log_date"].ToString()) ? "": DateTime.Parse(dtUser.Rows[0]["log_date"].ToString()).ToString();
            dob = String.IsNullOrEmpty(dtUser.Rows[0]["dob"].ToString()) ? "" : DateTime.Parse(dtUser.Rows[0]["dob"].ToString()).ToShortDateString();
            name = dtUser.Rows[0]["staff_name"].ToString();
            staff_id = String.IsNullOrEmpty(dtUser.Rows[0]["staff_id"].ToString()) ? 0 : Int32.Parse(dtUser.Rows[0]["staff_id"].ToString());
            staff_type = dtUser.Rows[0]["staff_type"].ToString();
            tbl_name = dtUser.Rows[0]["staff_tbl"].ToString();
            designation = dtUser.Rows[0]["designation"].ToString();
            department = dtUser.Rows[0]["department"].ToString();
            age = String.IsNullOrEmpty(dtUser.Rows[0]["age"].ToString()) ? 0 : Int32.Parse(dtUser.Rows[0]["age"].ToString());
            designation = dtUser.Rows[0]["designation"].ToString();
            gender = dtUser.Rows[0]["gender"].ToString().Trim();
            nationality = dtUser.Rows[0]["nationality"].ToString();

        }

        

    }
}
