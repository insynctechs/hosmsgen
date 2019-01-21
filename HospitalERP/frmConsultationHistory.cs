using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmConsultationHistory : Form
    {        
        ConsultationDetails objCD = new ConsultationDetails();
        Appointments objApp = new Appointments();
        Patients pat = new Patients();
        //DataSet ds;
        //SqlDataAdapter adap;
        //SqlCommandBuilder scb;
        public frmConsultationHistory()
        {
            try
            {
                InitializeComponent();
              
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        public frmConsultationHistory(int patid)
        {
            try
            {
                InitializeComponent();
                txtPatientID.Text = patid.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmConsultationHistory_Load(object sender, EventArgs e)
        {
            try
            {
                dgvApptHistory.AutoGenerateColumns = false;
                dgvHistoryProcedures.AutoGenerateColumns = false;
                setGridViews();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void setGridViews()
        {
            try
            {                
                dgvApptHistory.DataSource = objCD.getApptHistory(0,Convert.ToInt32(txtPatientID.Text));                
                //ShowProceduresHistory(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowProceduresHistory(int index)
        {
            try
            {
                dgvApptHistory.Rows[index].Selected = true;
                int app_id = Convert.ToInt32(dgvApptHistory.Rows[index].Cells["colHistID"].Value);
                lblHeadProcHist.Text = "PROCEDURES DONE ON APPT. DATE " + Utils.FormatDateShort(dgvApptHistory.Rows[index].Cells["colHistDate"].Value.ToString());
                dgvHistoryProcedures.DataSource = objCD.getProceduresFromApptID(app_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void getConsultationDetails()
        {
            try
            {
                DataTable dt = pat.getRecordFromID(Convert.ToInt32(txtPatientID.Text));
                txtPatientID.Text = dt.Rows[0]["id"].ToString();
                txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
                txtPatientName.Text = dt.Rows[0]["name"].ToString().Trim();
                txtGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                txtDob.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
                txtAge.Text = dt.Rows[0]["age"].ToString();
                txtPhone.Text = dt.Rows[0]["phone"].ToString();
                txtNationality.Text = dt.Rows[0]["nationality"].ToString();

                /*if (dt.Rows[0]["prev_date"].ToString() != "")
                {
                    txtLastVisitDate.Text = Utils.FormatDateShort(dt.Rows[0]["prev_date"].ToString());
                }
                txtMeetDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());

                txtDues.Text = dt.Rows[0]["dues"].ToString();
                //txtMedicalNotes.Text = dt.Rows[0]["history"].ToString();
                //txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
                //txtApptNotes.Text = dt.Rows[0]["notes"].ToString();
                txtDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());
                txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();
                //cmbAppStatus.SelectedValue = dt.Rows[0]["status"];
                */
                txtAddress.Text = Utils.FormatAddress(dt.Rows[0]["address"].ToString(), dt.Rows[0]["city"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["zip"].ToString());
                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        

        


        private void dgvApptHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ShowProceduresHistory(e.RowIndex);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        

        private void frmConsultationHistory_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmConsultationHistory_Shown(object sender, EventArgs e)
        {
            try
            {
                            
                getConsultationDetails();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void tabConsult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabConsult.SelectedIndex)
                {
                    
                    case 0:
                        dgvHistoryProcedures.AutoGenerateColumns = false;
                        setGridViews();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvApptHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvApptHistory.Columns[e.ColumnIndex].Name)
                {
                    case "btnHistSelect":
                        ShowProceduresHistory(e.RowIndex);
                        break;
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
                frmRptSickLeave rsl = new frmRptSickLeave(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()));
                rsl.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnMedicalReport_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptMedical fm = new frmRptMedical(Int32.Parse(txtAppID.Text.Trim()));
                fm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            try
            {
                frmReferToDoctor frt = new frmReferToDoctor(Int32.Parse(txtDoctorID.Text.Trim()), Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()));
                frt.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
