using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmConsultationDetails : Form
    {

        ConsultationDetails objCD = new ConsultationDetails();
        Appointments objApp = new Appointments();
        Medicines objMed = new Medicines();
        OptionVals opt = new OptionVals();

        //DataSet ds;
        //SqlDataAdapter adap;
        //SqlCommandBuilder scb;
        public frmConsultationDetails()
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

        public frmConsultationDetails(int aptid, int patid)
        {
            try
            {
                InitializeComponent();
                txtAppID.Text = aptid.ToString();
                txtPatientID.Text = patid.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmConsultationDetails_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                dgvProc.AutoGenerateColumns = false;
                dgvInv.AutoGenerateColumns = false;
                dgvApptHistory.AutoGenerateColumns = false;
                dgvHistoryProcedures.AutoGenerateColumns = false;
                dgvMedicine.AutoGenerateColumns = false;
                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void getProcedureList()
        {
            try
            {
                dgvProc.DataSource = objCD.getProceduresFromApptID(Convert.ToInt32(txtAppID.Text));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void getInvestigationList()
        {
            try
            {
                dgvInv.DataSource = objCD.getInvestigationsFromApptID(Convert.ToInt32(txtAppID.Text));
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void getMedicineList()
        {
            try
            {
                dgvMedicine.DataSource = objMed.getMedicinesFromApptID(Convert.ToInt32(txtAppID.Text));
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
                dgvApptHistory.DataSource = objCD.getApptHistory(Convert.ToInt32(txtAppID.Text),Convert.ToInt32(txtPatientID.Text));                
                ShowProceduresHistory(0);

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
                DataTable dt = objCD.getRecordFromID(Convert.ToInt32(txtAppID.Text));
                txtPatientID.Text = dt.Rows[0]["patient_id"].ToString();
                txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
                txtPatientName.Text = dt.Rows[0]["patient_name"].ToString();
                txtGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                txtDob.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
                txtAge.Text = dt.Rows[0]["age"].ToString();
                txtPhone.Text = dt.Rows[0]["phone"].ToString();
                txtNationality.Text = dt.Rows[0]["nationality"].ToString();
                txtReferredBy.Text = dt.Rows[0]["referred_doctor_name"].ToString();
                if (dt.Rows[0]["prev_date"].ToString() != "")
                {
                    txtLastVisitDate.Text = Utils.FormatDateShort(dt.Rows[0]["prev_date"].ToString());
                }
                txtMeetDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());
                txtDues.Text = dt.Rows[0]["dues"].ToString();
                txtMedicalNotes.Text = dt.Rows[0]["history"].ToString();
                txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
                txtDischarge.Text = dt.Rows[0]["discharge_summary"].ToString();
                txtApptNotes.Text = dt.Rows[0]["notes"].ToString();
                txtDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());
                txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();
                cmbAppStatus.SelectedValue = dt.Rows[0]["status"];
                txtAddress.Text = Utils.FormatAddress(dt.Rows[0]["address"].ToString(), dt.Rows[0]["city"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["zip"].ToString());
                if (dt.Rows[0]["status_edit_lock"].ToString() != "")
                {                    
                    if (dt.Rows[0]["status_edit_lock"].ToString() == "True")
                        EnableEditableButtons(false);
                    else
                        EnableEditableButtons(true);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void EnableEditableButtons(bool val)
        {
            try
            {
                if (LoggedUser.type_id != 1 && LoggedUser.type_id != 2)
                {
                    btnSave.Enabled = val;
                    btnSaveProcedure.Enabled = val;
                    btnAddNew.Enabled = val;
                    cmbAppStatus.Enabled = val;
                    btnSaveMedicine.Enabled = val;
                    //btnPrint.Enabled = val;
                    btnAddMed.Enabled = val;
                    colBtnEdit.Visible = val;
                    colDel.Visible = val;
                    btnProcEdit.Visible = val;
                    btnProcDelete.Visible = val;

                    if (LoggedUser.staff_type == "Doctor")
                    {
                        btnSave.Enabled = true;
                        btnSaveMedicine.Enabled = true;
                        //btnPrint.Enabled = val;
                        btnAddMed.Enabled = true;
                        colBtnEdit.Visible = true;
                        colDel.Visible = true;

                        if (val == false)
                            cmbAppStatus.Enabled = false;
                    }
                }
                if (cmbAppStatus.SelectedValue.ToString() == "7") //cancel
                {
                    btnRefer.Enabled = false;
                    //btnConsent.Enabled = false;
                    btnGenBill.Enabled = false;
                    btnMedicalReport.Enabled = false;
                    btnSickLeave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSaveProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    if (txtApptProcID.Text.Trim() == "") //add data
                    {
                        rtn = objCD.addProcedures(Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbProcedure.SelectedValue.ToString()), txtProcNotes.Text.Trim(), Convert.ToDecimal(txtFee.Text), Convert.ToInt32(cmbStatus.SelectedValue.ToString()));
                        if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                        else if (rtn == 0)
                            ShowStatus(0, "Name must be unique!");
                        else if (rtn == 1)
                        {

                            ShowStatus(1, "Record succesfully added!");
                            clearFormFields();
                            getProcedureList();
                        }
                    }
                    else //edit record
                    {
                        rtn = objCD.editProcedures(Convert.ToInt32(txtApptProcID.Text.Trim()), Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbProcedure.SelectedValue.ToString()), txtProcNotes.Text.Trim(), Convert.ToDecimal(txtFee.Text), Convert.ToInt32(cmbStatus.SelectedValue.ToString()));
                        if (rtn == 0)
                            ShowStatus(0, "This name already exists. Please provide unique name!");
                        else if (rtn == 1)
                        {
                            ShowStatus(1, "Record succesfully updated!");
                            clearFormFields();
                            getProcedureList();
                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void clearFormFields()
        {
            try
            {
                txtApptProcID.Text = "";
                txtFee.Text = "";
                cmbProcedure.SelectedValue = 0;
                cmbStatus.SelectedValue = 0;
                txtProcNotes.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void clearFormInvFields()
        {
            try
            {
                txtAppInvId.Text = "";
                txtInvFee.Text = "";
                cmbInvestigation.SelectedValue = 0;
                cmbInvStatus.SelectedValue = 0;
                txtInvNotes.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void clearMedFormFields()
        {
            try
            {
                txtAppMedId.Text = "";
                cmbMedicine.SelectedIndex = 0;
                txtPrescription.Text = "";
                txtType.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvProc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtApptProcID.Text = dgvProc.Rows[e.RowIndex].Cells["cid"].Value.ToString();
                DataTable dt = objCD.getProceduresFromProcID(Convert.ToInt32(txtApptProcID.Text));
                txtFee.Text = dt.Rows[0]["fee"].ToString();
                cmbProcedure.SelectedValue = dt.Rows[0]["procedure_id"].ToString();
                cmbStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                txtProcNotes.Text = dt.Rows[0]["notes"].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtApptProcID.Text == "") //load fees from procedure table
                {
                    txtFee.Text = objCD.getProcedureFees(Convert.ToInt32(cmbProcedure.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //to save medical notes and known allergies in patient table and
                //to save appointment notes in appointment table
                int rtn = objCD.saveDiagnosis(Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim()), txtMedicalNotes.Text.Trim(), txtAllergies.Text.Trim(), txtApptNotes.Text.Trim(), Convert.ToInt16(cmbAppStatus.SelectedValue), txtDischarge.Text.Trim());

                if (rtn == 1)
                {
                    ShowStatus(1, "Record succesfully updated");

                }
                else if (rtn == -1)
                {
                    ShowStatus(0, "Some error occurred... Record cannot be added.");
                }
                getConsultationDetails();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowStatus(int success, string msg)
        {
            try
            {
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK);
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

        private void cmbProcedure_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbProcedure.SelectedIndex == 0 && tabConsult.SelectedIndex == 1)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbProcedure, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbProcedure, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal d;
                if (tabConsult.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(txtFee.Text))
                    {
                        e.Cancel = true;
                        //txtFee.Focus();
                        errorProvider.SetError(txtFee, "Required");
                    }
                    else if (!decimal.TryParse(txtFee.Text, out d))
                    {
                        e.Cancel = true;
                        //txtFee.Focus();
                        errorProvider.SetError(txtFee, "Invalid Decimal Number");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(txtFee, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbStatus.SelectedIndex == 0 && tabConsult.SelectedIndex == 1)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbStatus, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbStatus, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnAddNewProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                frmProcedures fp = new frmProcedures(600, 500);
                //fp.MdiParent = this.MdiParent;
                fp.ShowDialog(this);
                cmbProcedure.DataSource = objCD.ProceduresCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmConsultationDetails_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmConsultationDetails_Shown(object sender, EventArgs e)
        {
            try
            {
                //cmbProcedure.DataSource = objCD.ProceduresCombo(0);
                //cmbStatus.DataSource = objCD.StatusCombo(0);
                PopulateAppointmentStatusCombo();
                getConsultationDetails();
                //Buttons are disabled when
                //prev dates , completed status and users not doctors and super admin  and for cancelled appontments
                if (Utils.DaysBetweenDates(txtMeetDate.Text, DateTime.Now.ToShortDateString()) > 0 || (cmbAppStatus.SelectedValue.ToString() =="2") || (cmbAppStatus.SelectedValue.ToString() == "7")) /*|| (LoggedUser.type_id !=1 && LoggedUser.type_id != 3)*/
                {
                    EnableEditableButtons(false);
                }
                else
                {
                    EnableEditableButtons(true);
                }
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

                        break;
                    case 1:
                        cmbProcedure.DataSource = objCD.ProceduresCombo(0);
                        cmbProcedure.DisplayMember = "name";
                        cmbProcedure.ValueMember = "id";
                        cmbStatus.DataSource = objCD.StatusCombo(0);
                        getProcedureList();
                        break;

                    case 2:
                        cmbInvestigation.DataSource = objCD.InvestigationsCombo(0);
                        cmbInvestigation.DisplayMember = "name";
                        cmbInvestigation.ValueMember = "id";
                        cmbInvStatus.DataSource = objCD.InvStatusCombo(0);
                        getInvestigationList();
                        break;


                    case 3:
                        
                        DataTable dtMed = objMed.MedicinesCombo(0);
                        if (dtMed.Rows.Count > 0)
                        {
                            cmbMedicine.DataSource = dtMed;
                            cmbMedicine.DisplayMember = "name";
                            cmbMedicine.ValueMember = "id";
                            getMedicineList();
                        }
                        break;
                        
                    case 4:
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

        private void PopulateAppointmentStatusCombo()
        {
            try
            {
                cmbAppStatus.DataSource = objApp.getAppointmentStatus();
                cmbAppStatus.DisplayMember = "name";
                cmbAppStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
           
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

        private void btnSickLeave_Click(object sender, EventArgs e)
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

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = objCD.getRecordFromID(Convert.ToInt32(txtAppID.Text));
                string status = dt.Rows[0]["status"].ToString();
                if (status == "2" && Utils.DaysBetweenDates(txtMeetDate.Text, DateTime.Now.ToShortDateString()) >= 0)
                {
                    frmOneTimeBill frm = new frmOneTimeBill(Int32.Parse(txtAppID.Text.ToString()), Int32.Parse(txtPatientID.Text));
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bills can be generated/viewed for today's/past completed appointments only. \n Please change the status to completed before generating the bill.");
               
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmConsultationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            objCD.Dispose();
            objApp.Dispose();
        }

        private void btnConsent_Click(object sender, EventArgs e)
        {
            try
            {
               // frmConsentForm fcon = new frmConsentForm(Int32.Parse(txtDoctorID.Text.Trim()), Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim())); //
                //fcon.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void tbPgProc_Click(object sender, EventArgs e)
        {

        }


        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sdet = "";
            string[] strArr = null;

            try
            {
                    sdet = objMed.getMedicinePrescription(Convert.ToInt32(cmbMedicine.SelectedValue.ToString()));
                    strArr =sdet.Split(new string[] { "^>$<" }, StringSplitOptions.None);
                    txtPrescription.Text = strArr[0];
                    txtType.Text = strArr[1];
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString()+sdet+"\n"+strArr);
            }
        }

        
        private void btnSaveMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    if (txtAppMedId.Text.Trim() == "") //add data
                    {
                        rtn = objMed.addMedicines(Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbMedicine.SelectedValue.ToString()), txtPrescription.Text.Trim());
                        if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                        else if (rtn == 0)
                            ShowStatus(0, "Name must be unique!");
                        else if (rtn == 1)
                        {

                            //ShowStatus(1, "Record successfully added!");
                            clearMedFormFields();
                            getMedicineList();
                        }
                    }
                    else //edit record
                    {
                        rtn = objMed.editMedicines(Convert.ToInt32(txtAppMedId.Text.Trim()), Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbMedicine.SelectedValue.ToString()), txtPrescription.Text.Trim());
                        if (rtn == 0)
                            ShowStatus(0, "This name already exists. Please provide unique name!");
                        else if (rtn == 1)
                        {
                            //ShowStatus(1, "Record successfully updated!");
                            clearMedFormFields();
                            getMedicineList();
                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbMedicine_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbMedicine.SelectedIndex == 0 && tabConsult.SelectedIndex == 3)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbMedicine, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbMedicine, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }


        private void txtPrescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPrescription.Text.Trim()=="" && tabConsult.SelectedIndex==3)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(txtPrescription, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtPrescription, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvMedicine.Columns[e.ColumnIndex].Name)
                {
                    case "colBtnEdit":
                        txtAppMedId.Text = dgvMedicine.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                        cmbMedicine.SelectedValue = dgvMedicine.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtPrescription.Text = dgvMedicine.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtType.Text = dgvMedicine.Rows[e.RowIndex].Cells[2].Value.ToString();
                        break;
                    case "colDel":
                        DeletePatientMedicine(Int32.Parse(dgvMedicine.Rows[e.RowIndex].Cells["colID"].Value.ToString()));
                        getMedicineList();
                        break;


                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info("frmConsultationDetails\r\n" + ex.ToString());
            }
        }

        private void DeletePatientMedicine(int pat_med_id)
        {
            try
            {
                int ret = objMed.DeletePatientMedicine(pat_med_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }


        private void DeletePatientProcedure(int pat_proc_id)
        {
            try
            {
                int ret = objCD.DeletePatientProcedure(pat_proc_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void DeletePatientInvestigation(int pat_proc_id)
        {
            try
            {
                int ret = objCD.DeletePatientInvestigation(pat_proc_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedicinePrint fm = new frmMedicinePrint(Int32.Parse(txtAppID.Text.Trim()));
                fm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnAddMed_Click(object sender, EventArgs e)
        {
            frmMedicine fmed = new frmMedicine(600, 500);
            fmed.ShowDialog(this);                        
            cmbMedicine.DataSource = objMed.MedicinesCombo(0);
        }

        private void cmbMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ActiveControl = btnSaveMedicine;
            }
        }

        private void dgvProc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvProc.Columns[e.ColumnIndex].Name)
                {
                    case "btnProcEdit":
                        txtApptProcID.Text = dgvProc.Rows[e.RowIndex].Cells["cid"].Value.ToString();
                        DataTable dt = objCD.getProceduresFromProcID(Convert.ToInt32(txtApptProcID.Text));
                        txtFee.Text = dt.Rows[0]["fee"].ToString();
                        cmbProcedure.SelectedValue = dt.Rows[0]["procedure_id"].ToString();
                        cmbStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                        txtProcNotes.Text = dt.Rows[0]["notes"].ToString();
                        break;

                    case "btnProcDelete":
                        DeletePatientProcedure(Int32.Parse(dgvProc.Rows[e.RowIndex].Cells["cid"].Value.ToString()));
                        getProcedureList();
                        break;


                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info("frmConsultationDetails\r\n" + ex.ToString());
            }
        }

        private void cmbProcedure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ActiveControl = txtFee;
            }
        }

        private void cmbMedicine_Leave(object sender, EventArgs e)
        {
           
                this.ActiveControl = btnSaveMedicine;
           
        }

        

        private void cmbMedicine_DropDownClosed(object sender, EventArgs e)
        {
            string sdet = "";
            string[] strArr = null;

            try
            {
                sdet = objMed.getMedicinePrescription(Convert.ToInt32(cmbMedicine.SelectedValue.ToString()));
                strArr = sdet.Split(new string[] { "^>$<" }, StringSplitOptions.None);
                txtPrescription.Text = strArr[0];
                txtType.Text = strArr[1];
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString() + sdet + "\n" + strArr);
            }
        }

        private void btnDues_Click(object sender, EventArgs e)
        {
           
            try
            {
                frmPatientDues fcf = new frmPatientDues(Int32.Parse(txtDoctorID.Text.Trim()), Int32.Parse(txtAppID.Text.Trim()), Int32.Parse(txtPatientID.Text.Trim())); //
                fcf.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbInvestigation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbInvestigation.SelectedIndex == 0 && tabConsult.SelectedIndex == 2)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbInvestigation, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbInvestigation, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbInvestigation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAppInvId.Text == "") //load fees from investigation table
                {
                    txtInvFee.Text = objCD.getInvestigationFees(Convert.ToInt32(cmbInvestigation.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnInvClick_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    if (txtAppInvId.Text.Trim() == "") //add data
                    {
                        rtn = objCD.addInvestigations(Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbInvestigation.SelectedValue.ToString()), txtInvNotes.Text.Trim(), Convert.ToDecimal(txtInvFee.Text), Convert.ToInt32(cmbInvStatus.SelectedValue.ToString()));
                        if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                        else if (rtn == 0)
                            ShowStatus(0, "Name must be unique!");
                        else if (rtn == 1)
                        {

                            ShowStatus(1, "Record succesfully added!");
                            clearFormInvFields();
                            getInvestigationList();
                        }
                    }
                    else //edit record
                    {
                        rtn = objCD.editInvestigations(Convert.ToInt32(txtAppInvId.Text.Trim()), Convert.ToInt32(txtPatientID.Text), Convert.ToInt32(txtDoctorID.Text), Convert.ToInt32(txtAppID.Text), Convert.ToInt32(cmbInvestigation.SelectedValue.ToString()), txtInvNotes.Text.Trim(), Convert.ToDecimal(txtInvFee.Text), Convert.ToInt32(cmbInvStatus.SelectedValue.ToString()));
                        if (rtn == 0)
                            ShowStatus(0, "This name already exists. Please provide unique name!");
                        else if (rtn == 1)
                        {
                            ShowStatus(1, "Record succesfully updated!");
                            clearFormInvFields();
                            getInvestigationList();
                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnInvAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmInvestigations fp = new frmInvestigations(600, 500);
                //fp.MdiParent = this.MdiParent;
                fp.ShowDialog(this);
                cmbInvestigation.DataSource = objCD.InvestigationsCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtInvFee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal d;
                if (tabConsult.SelectedIndex == 2)
                {
                    if (string.IsNullOrEmpty(txtInvFee.Text))
                    {
                        e.Cancel = true;
                        //txtFee.Focus();
                        errorProvider.SetError(txtInvFee, "Required");
                    }
                    else if (!decimal.TryParse(txtInvFee.Text, out d))
                    {
                        e.Cancel = true;
                        //txtFee.Focus();
                        errorProvider.SetError(txtInvFee, "Invalid Decimal Number");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(txtInvFee, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbInvStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbInvStatus.SelectedIndex == 0 && tabConsult.SelectedIndex == 2)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbInvStatus, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbInvStatus, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvInv.Columns[e.ColumnIndex].Name)
                {
                    case "btnInvEdit":
                        txtAppInvId.Text = dgvInv.Rows[e.RowIndex].Cells["inv_id"].Value.ToString();
                        DataTable dt = objCD.getInvestigationsFromInvID(Convert.ToInt32(txtAppInvId.Text));
                        txtInvFee.Text = dt.Rows[0]["fee"].ToString();
                        cmbInvestigation.SelectedValue = dt.Rows[0]["investigation_id"].ToString();
                        cmbInvStatus.SelectedValue = dt.Rows[0]["status"].ToString();
                        txtInvNotes.Text = dt.Rows[0]["notes"].ToString();
                        break;

                    case "btnInvDelete":
                        DeletePatientInvestigation(Int32.Parse(dgvInv.Rows[e.RowIndex].Cells["inv_id"].Value.ToString()));
                        getInvestigationList();
                        break;


                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info("frmConsultationDetails\r\n" + ex.ToString());
            }
        }
    }
}
