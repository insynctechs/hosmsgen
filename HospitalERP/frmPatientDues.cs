using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmPatientDues : Form
    {
        public int doctor_id = 0;
        public int appoint_id = 0;
        public int patient_id = 0;
       
        ConsultationDetails objCD = new ConsultationDetails();
        Appointments appt = new Appointments();
        OptionVals opt = new OptionVals();
        Bill bill = new Bill();

        public frmPatientDues()
        {
            InitializeComponent();
        }

        public frmPatientDues(int doc_id,int app_id,int pat_id)
        {
            InitializeComponent();
            doctor_id = doc_id;
            appoint_id = app_id;
            patient_id = pat_id;
        }

        private void getBillHistory()
        {
            try
            {
                DataTable dtRecords = bill.BillsForPatient(patient_id);
                dgvList.DataSource = dtRecords;
                if (dtRecords.Rows.Count == 0)
                {
                    MessageBox.Show(Utils.FormatZeroSearch());
                }
                DataRow lastRow = dtRecords.Rows[dtRecords.Rows.Count - 1];
                lblDue.Text = lastRow[7].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

}




private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      



        private void getConsultationDetails()
        {
            try
            {                
                DataTable dt = objCD.getRecordFromID(appoint_id);                
                lblName.Text = dt.Rows[0]["patient_name"].ToString();
                //lblDue.Text = dt.Rows[0]["dues"].ToString();


            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        
        private void frmPatientDues_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;

            dgvList.AutoGenerateColumns = false;

            getConsultationDetails();
            getBillHistory();
            
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvList.Columns[e.ColumnIndex].Name == "bDate")
            {
                ShortFormDateFormat(e);
            }
        }

        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());
                    String dateString = theDate.ToString("dd-MM-yy");
                    formatting.Value = dateString;
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }
    }
}
