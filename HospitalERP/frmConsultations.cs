using System;
using System.Linq;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmConsultations : Form
    {

        Doctors doc = new Doctors();
        Appointments app = new Appointments();
        Patients pat = new Patients();
        int startload = 0;
        public frmConsultations()
        {
            InitializeComponent();
        }

        private void frmConsultations_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                dgvApp.AutoGenerateColumns = false;
                GetDoctorsCombo(0);
                PopulateStatus();
                getAppointmentList();
                startload = 1;
                


                Timer timer = new Timer();
                timer.Interval = (30 * 1000); // 30 secs
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //refresh here...
            getAppointmentList();
        }

        private void dgvApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvApp.Columns[e.ColumnIndex].Name)
                {

                    case "ABtnDues":
                        try
                        {
                            frmPatientDues fcf = new frmPatientDues(0, Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString())); //
                            fcf.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            CommonLogger.Info(ex.ToString());
                        }
                        break;

                    case "ABtnBill":
                        if (dgvApp.Rows[e.RowIndex].Cells["AStatus"].Value.ToString() == "Completed" && Utils.DaysBetweenDates(dtpAppDate.Text, DateTime.Now.ToShortDateString()) >= 0)
                            ViewBill(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
                        else
                            MessageBox.Show("Bills can be generated/viewed for today's/past completed appointments only", "Information", MessageBoxButtons.OK);
                        break;
                
                    case "ABtnDetails":
                        ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
                        break;

                    case "ABtnHistory":
                        ViewPatientHistory(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString(), dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString());

                        break;
                }
                getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void ViewPatientHistory(string pid, string pnum)
        {
            try
            {
                frmConsultationHistory frm = new frmConsultationHistory(Int32.Parse(pid));
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void GetDoctorsCombo(int tid)
        {
            try
            {
                cmbDoc.ValueMember = "id";
                cmbDoc.DisplayMember = "name";
                cmbDoc.DataSource = doc.getDoctorsCombo(tid);
                //LoggedUser.type_name = "DOCTOR";
                //LoggedUser.staff_id = 1;
                if (LoggedUser.type_name.ToUpper() == "DOCTOR" && LoggedUser.staff_id > 0)
                {
                    cmbDoc.SelectedValue = LoggedUser.staff_id;
                    cmbDoc.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void PopulateStatus()
        {
            try
            {
                cmbStatus.DataSource = app.getAppointmentStatus(1);
                cmbStatus.ValueMember = "id";
                cmbStatus.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        private void getAppointmentList()
        {
            try
            {
                dgvApp.DataSource = app.getAllAppointmentsForDate(Convert.ToDateTime(dtpAppDate.Text), Int32.Parse(cmbDoc.SelectedValue.ToString()), Int32.Parse(cmbStatus.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmConsultations_Activated(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                if (startload == 1)
                    getAppointmentList();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        private void ViewDetails(int app_id, int pat_id)
        {
            try
            {
                if (Application.OpenForms.OfType<frmConsultationDetails>().Count() == 1)
                    Application.OpenForms.OfType<frmConsultationDetails>().First().Close();
                frmConsultationDetails frm = new frmConsultationDetails(app_id, pat_id);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void ViewBill(int app_id, int pat_id)
        {
            try
            {
                frmOneTimeBill frm = new frmOneTimeBill(app_id, pat_id);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvApp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ViewDetails(Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["AID"].Value.ToString()), Int32.Parse(dgvApp.Rows[e.RowIndex].Cells["APatID"].Value.ToString()));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmConsultations_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            doc.Dispose();
            app.Dispose();
            pat.Dispose();
        }
    }
}
