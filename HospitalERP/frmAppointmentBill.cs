using System;
using System.Data;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmAppointmentBill : Form
    {

        public int appointment_id = 0;
        public int patient_id = 0;

        
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();

        public frmAppointmentBill()
        {
            try
            {
                InitializeComponent();
                PopulateBillTypes();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        public frmAppointmentBill(int app_id, int pat_id)
        {
            try
            {
                InitializeComponent();
                appointment_id = app_id;
                patient_id = pat_id;
                PopulateBillTypes();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }



        }

        private void frmAppointmentBill_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                dgvList.AutoGenerateColumns = false;
                loadPatientAppInfo();
                if(this.txtMeetDate.Text != DateTime.Now.ToShortDateString())
                {
                    btnGenerateBill.Enabled = false;
                    btnGenerateBill.ForeColor = System.Drawing.Color.LightGray;                    
                }
                else
                {
                    btnGenerateBill.Enabled = true;
                    btnGenerateBill.ForeColor = System.Drawing.Color.White;
                    btnGenerateBill.Cursor = Cursors.Hand;
                }
                

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbBillType.SelectedValue.ToString())
                {
                    case "0":
                        MessageBox.Show("Please choose a bill type!");
                        break;
                    case "1":                        
                        frmConsultationBill frm = new frmConsultationBill(appointment_id, patient_id);
                        frm.ShowDialog();
                        ListBills();
                        break;

                    case "2":
                        int count = 0;
                        using (ConsultationDetails cdet = new ConsultationDetails())
                        {
                            DataTable dtProcedures = cdet.getProceduresFromApptID(appointment_id);
                            count = dtProcedures.Rows.Count;
                        }
                        if (count > 0)
                        {

                            frmProceduresBill frm1 = new frmProceduresBill(appointment_id, patient_id);
                            frm1.ShowDialog();
                            ListBills();
                        }
                        else
                        {
                            MessageBox.Show("Cannot Generate Bill as Procedures have not been added to this appointment!");
                        }
                        break;

                    case "3":
                        frmOneTimeBill frm2 = new frmOneTimeBill(appointment_id, patient_id);
                        frm2.ShowDialog();
                        ListBills();
                        break;

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void loadPatientAppInfo()
        {
            try
            {
                DataTable dtPat = pat.getDetailedPatientRecordFromID(patient_id, appointment_id);
                txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
                txtPatName.Text = dtPat.Rows[0]["patient_name"].ToString();
                txtGender.Text = Utils.Gender[dtPat.Rows[0]["gender"].ToString()];
                txtDob.Text = Convert.ToDateTime(dtPat.Rows[0]["dob"].ToString()).ToShortDateString();
                txtAge.Text = dtPat.Rows[0]["age"].ToString();
                txtNationality.Text = dtPat.Rows[0]["nationality"].ToString();
                txtPhone.Text = dtPat.Rows[0]["phone"].ToString();
                txtAddress.Text = Utils.FormatAddress(dtPat.Rows[0]["address"].ToString(), dtPat.Rows[0]["city"].ToString(), dtPat.Rows[0]["state"].ToString(), dtPat.Rows[0]["zip"].ToString());
                if (dtPat.Rows[0]["meet_date"].ToString() != "" && dtPat.Rows[0]["meet_date"].ToString() != null)
                    txtMeetDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
                txtDoctor.Text = dtPat.Rows[0]["doctor_name"].ToString();
                txtDues.Text = dtPat.Rows[0]["dues"].ToString();
                txtAppID.Text = dtPat.Rows[0]["appointment_id"].ToString();
                lblHead1.Text = "PATIENT [" + txtPatNum.Text + "] BILLS FOR APPOINTMENT WITH " + txtDoctor.Text + " ON " + txtMeetDate.Text;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            return;
        }

        private void PopulateBillTypes()
        {
            try
            {
                cmbBillType.DataSource = bill.GetBillTypes(1);
                cmbBillType.DisplayMember = "name";
                cmbBillType.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            return;
        }

        private void frmAppointmentBill_Activated(object sender, EventArgs e)
        {
            ListBills();
        }

        private void ListBills()
        {
            try
            {
                dgvList.DataSource = bill.GetAppointmentAllBills(appointment_id, patient_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnListBills_Click(object sender, EventArgs e)
        {
            ListBills();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "bBtnBill":
                        if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "1")
                        {
                            frmConsultationBill frm = new frmConsultationBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "2")
                        {
                            frmProceduresBill frm = new frmProceduresBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "3")
                        {
                            frmOneTimeBill frm = new frmOneTimeBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
    }
}
