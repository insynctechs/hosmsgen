using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace HospitalERP.Helpers
{
    class Utils
    {
        public static NameValueCollection AppointmentStatus = new NameValueCollection()
        {
            { "Scheduled","1" },
            { "Completed", "2" },
            { "On-Hold","3" },
            { "Billed","4" }
        };

        public static NameValueCollection ProcedureStatus = new NameValueCollection()
        {
            { "Scheduled","1" },
            { "Completed", "2" },
            { "On-Hold","3" }
        };

        public static NameValueCollection BillStatus = new NameValueCollection()
        {
            { "Generated", "1" },
            { "Pending", "2"  },
            {"Partial Paid", "3" },
            { "Paid", "4" }
        };

        public static NameValueCollection Gender = new NameValueCollection()
        {
            { "M", "Male" },
            { "F", "Female"  }
            
        };

        public static string FormatAmount(double d, int decimalPlaces=3)
        {
            string format = String.Format("{{0:0.{0}}}", new string('0', decimalPlaces));
            return String.Format(format, d);
        }

        public static string FormatZeroSearch()
        {
            return "No records Found for the Searched Criteria!";
        }

        public static string FormatDoctorName(string name, bool caps=false)
        {
            if(name.StartsWith("Dr."))
                return caps ? name.ToUpper() : name;
            else 
                return caps? ("Dr. " + name).ToUpper() : "Dr. " + name;            
        }

        public static string FormatDateShort(string strDate)
        {
            return DateTime.Parse(strDate).ToShortDateString(); 
        }

        public static string FormatAddress(string address, string city, string state, string zip)
        {
            string address1 = !string.IsNullOrEmpty(address) ? (address + ",\r\n") : address;
            string city1 = !string.IsNullOrEmpty(city) ? (city + ", ") : city;
            string zip1 = !string.IsNullOrEmpty(zip) ? (" - " + zip) : zip;
            return string.Format("{0}{1}{2}{3}", address1, city1, state, zip1);

        }

        public static int getChildFormCount(Form frmParent)
        {
            int childCount = 0;
            foreach (Form frm in frmParent.MdiChildren)
            {
                if (frm.GetType() != typeof(frmDashboard) && frm.GetType() != typeof(frmMain) && frm.GetType() != typeof(frmLogin))
                {
                    childCount++;
                }
            }
            return childCount;
        }

        public static int DaysBetweenDates(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }

        public static int DaysBetweenDates(string d1, string d2)
        {
            System.DateTime firstDate = Convert.ToDateTime(d1);
            System.DateTime secondDate = Convert.ToDateTime(d2);
            System.TimeSpan diff = secondDate.Subtract(firstDate);           
            return (int)diff.TotalDays;
        }

        public static void toggleChildCloseButton(Form frmParent, int fromChild)
        {
            try
            {
                int cnt = getChildFormCount(frmParent);
                Control[] c = frmParent.Controls.Find("btnChildClose", true);
                Button b = (Button)c[0];
                if (cnt == fromChild)
                {

                    b.Visible = false;
                }
                else
                {

                    b.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

    }
}
