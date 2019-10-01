using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmPatient : Form
    {       
        Patients pat = new Patients();
        private bool errorfocus = false;
        private int default_tab = 0;
        DateTime dateToday = DateTime.Now;
        int ageInYears = 0;
        int ageInMonths = 0;
        int months = 0;
       
        public frmPatient()
        {
            InitializeComponent();
        }

        public frmPatient(int selecttab)
        {
            InitializeComponent();
            default_tab = selecttab;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {

                    int logged_in_user = LoggedUser.id;
                    int rtn = -1;
                    int exists = -1;
                    char gender;
                    if (rbGender1.Checked == true)
                        gender = 'M';
                    else
                        gender = 'F';
                    /*
                    char patient_type;
                    if (rbInpatient.Checked == true)
                        patient_type = 'I';
                    else
                        patient_type = 'O';
                        */
                    if (txtID.Text.Trim() == "") //add data
                    {
                        dtpPathakaExpiry.Visible = true;
                        exists = pat.existPatients(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text.Trim(), txtPhone.Text.Trim());
                        if (exists <= 0)
                        {
                            rtn = pat.addPatients(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user, Convert.ToInt32(txtAgeYr.Text));

                            if (rtn >= 1)
                            {
                                ShowStatus(1, "Record succesfully added. ");
                                clearFormFields();
                                if (chkAppointment.Checked == true)
                                {
                                    frmReferToDoctor frt = new frmReferToDoctor(rtn);
                                    frt.ShowDialog(this);
                                    /*
                                     * SJ COMMENTED ON 12FEB2019
                                     * Instead of redirecting to appt form, 
                                    if (LoggedUser.type_name.ToUpper() == "DOCTOR")
                                    {
                                        if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                                            Application.OpenForms.OfType<frmConsultations>().First().BringToFront();
                                        else
                                        {
                                            frmConsultations frm = new frmConsultations();
                                            frm.MdiParent = this.ParentForm;
                                            frm.Show();
                                        }
                                    }
                                    else
                                    {

                                        if (Application.OpenForms.OfType<frmAppointments>().Count() == 1)
                                            Application.OpenForms.OfType<frmAppointments>().First().BringToFront();
                                        else
                                        {
                                            frmAppointments app = new frmAppointments(rtn);
                                            app.MdiParent = this.ParentForm;
                                            app.Show();
                                        }
                                    }
                                    */
                                }

                            }
                            else if (rtn == -1)
                            {
                                ShowStatus(0, "Some error occurred... Record cannot be added.");
                            }
                        }
                        else
                            ShowStatus(0, "Patient already exists, cannot be added.");
                    }
                    else //edit record
                    {

                        rtn = pat.editPatients(Int32.Parse(txtID.Text), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user, Int32.Parse(txtAgeYr.Text));

                        if (rtn > -1)
                        {
                            ShowStatus(1, "Record succesfully updated");
                            clearFormFields();

                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added.");
                        }
                    }

                }
                //dtpPathakaExpiry.Visible = false;
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
                txtID.Text = "";
                txtPatNum.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                rbGender1.Checked = false;
                rbGender2.Checked = false;
      
                txtNationality.Text = "";
                txtPathaka.Text = "";

                txtAddress.Text = "";
                txtCity.Text = "";
                txtDistrict.Text = "";
                txtZip.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtAllergies.Text = "";
                txtHistory.Text = "";
                txtAgeYr.Text = "";
                txtAgeMn.Text = "";
                dtpDob.Value = DateTime.Today;
                dtpPathakaExpiry.Value = DateTime.Today;

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
                lblStatus.Visible = true;
                if (success == 1)
                {
                    lblStatus.BackColor = Color.YellowGreen;
                    lblStatus.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblStatus.BackColor = Color.Salmon;
                    lblStatus.ForeColor = Color.DarkRed;
                }
                lblStatus.Text = msg;
                var t = new Timer();
                t.Interval = 5000; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    lblStatus.Hide();
                    t.Stop();
                };
                t.Start();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            try
            {
                dgvList.AutoGenerateColumns = false;
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                PopulateSearch();
                if (default_tab > 0)
                    tabSub.SelectedIndex = default_tab;
                dtpDob.Value = DateTime.Today;
                dtpDob.MaxDate = DateTime.Today;
                dtpPathakaExpiry.MaxDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void PopulateSearch()
        {
            try
            {
                cmbSearch.DataSource = pat.SearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowRecords()
        {
            try
            {
                DataTable dtRecords = pat.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                dgvList.DataSource = dtRecords;
                if (dtRecords.Rows.Count == 0)
                {
                    MessageBox.Show(Utils.FormatZeroSearch());
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {

                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtFirstName.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtFirstName, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtFirstName, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dtpDob_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtpDob.Value.Date == dateToday.Date)
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        dtpDob.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(dtpDob, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(dtpDob, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtNationality_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNationality.Text.Trim()))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtNationality.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtNationality, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtNationality, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }



        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPhone.Text.Trim()) || txtPhone.Text.Length != 10)
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtPhone.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtPhone, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtPhone, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                    chkAppointment.Visible = true;
                else
                    chkAppointment.Visible = false;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabSub.SelectedIndex)
                {
                    case 0:

                        break;
                    case 1:
                        clearFormFields();
                        ShowRecords();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                setFormFields(Convert.ToInt32(txtID.Text));
                tabSub.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void setFormFields(int id)
        {
            try
            {
                DataTable dt = pat.getRecordFromID(id);
                txtPatNum.Text = dt.Rows[0]["patient_number"].ToString();
                txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                txtLastName.Text = dt.Rows[0]["last_name"].ToString();
                txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
                txtHistory.Text = dt.Rows[0]["history"].ToString();
                if (dt.Rows[0]["gender"].ToString() == "M")
                    rbGender1.Checked = true;
                else
                    rbGender2.Checked = true;               
                dtpDob.Text = dt.Rows[0]["dob"].ToString();
                txtNationality.Text = dt.Rows[0]["nationality"].ToString();
                txtPathaka.Text = dt.Rows[0]["legal_id"].ToString();
                dtpPathakaExpiry.Text = dt.Rows[0]["legal_id_expiry"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
                txtCity.Text = dt.Rows[0]["city"].ToString();
                txtDistrict.Text = dt.Rows[0]["state"].ToString();
                txtZip.Text = dt.Rows[0]["zip"].ToString();
                txtPhone.Text = dt.Rows[0]["phone"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                // New Implementation 26-March-2019               
                populateAndReturnAgeField();
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

        private void deletePatient(int id)
        {

            try
            {
                int rtn = pat.DeletePatient(id);

                if (rtn > -1)
                {
                    //ShowStatus(1, "Record succesfully deleted");
                    MessageBox.Show("Record succesfully deleted");
                    

                }
                else if (rtn == -1)
                {
                    //ShowStatus(0, "This patient associated to appointments... Record cannot delete.");
                    MessageBox.Show("This patient associated to appointments... Record cannot delete.");
                }
                ShowRecords();

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "colBtnEdit":
                        txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                        setFormFields(Convert.ToInt32(txtID.Text));
                        tabSub.SelectedIndex = 0;
                        break;
                    case "colBtnDel":
                        deletePatient(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString()));
                        

                        break;
                    case "PBtnHistory":
                        ViewPatientHistory(dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString(), dgvList.Rows[e.RowIndex].Cells["PatNum"].Value.ToString());

                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFormFields();
        }

        private void frmPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utils.toggleChildCloseButton(this.MdiParent, 1);
                pat.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }



        /* DOB & AGE MAPPING SPECIFIC METHODS */
        // To restrict non-numreic and non-control keystrokes for Age field inputs.
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        // To changes date of birth with respect to input in textbox for age in years.
        // Only numneric input for years upto 150 is considered.
        private void txtAgeYr_Leave(object sender, EventArgs e)
        {   
            int input;         
                if (int.TryParse(txtAgeYr.Text, out input) && input < 150)
                {
                    if (ageInYears > 0)              
                        months -= (ageInYears * 12);
                    ageInYears = input;
                    months += ageInYears * 12;
                    dtpDob.Value = dateToday.AddDays(-(dateToday.Day - 1)).AddMonths(-months);
                }
        }

        // Only numneric input for months from 1 to 11 are considered.
        private void txtAgeMn_Leave(object sender, EventArgs e)
        {   
            int input;         
                if (int.TryParse(txtAgeMn.Text, out input) && input < 12)
                {
                    if (ageInMonths > 0)
                        months -= ageInMonths;
                    ageInMonths = input;
                    months += ageInMonths;
                    dtpDob.Value = dateToday.AddDays(-(dateToday.Day - 1)).AddMonths(-months);
                }
        }

        private void dtpDob_Leave(object sender, EventArgs e)
        {
            populateAndReturnAgeField();
        }

        // To populate years, months textboxes in Age field with respect to value in Date of birth field.
        // Returns age in years and months as string in format "YY.MM"
        private string populateAndReturnAgeField() {
            int years = 0;
            int months = 0;
            if (dtpDob.Value < dateToday)
            {
                years = new DateTime(dateToday.Subtract(dtpDob.Value).Ticks).Year - 1;
                months = new DateTime(dateToday.Subtract(dtpDob.Value).Ticks).Month - 1;
                txtAgeYr.Text = years.ToString();
                txtAgeMn.Text = months.ToString();
            }
            else {
                // Implementation for future dates.
            }
            return years + "." + months;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void txtAgeYr_Validating(object sender, CancelEventArgs e)
        {
            try
            {   
                // year field allows non-blank input upto 149.
                if (string.IsNullOrEmpty(txtAgeYr.Text.Trim()) || Convert.ToInt32(txtAgeYr.Text) >= 150)
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtAgeYr.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtAgeYr, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtAgeYr, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtAgeMn_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // month field allows non-blank input upto 11. 
                if (string.IsNullOrEmpty(txtAgeMn.Text.Trim()) || Convert.ToInt32(txtAgeMn.Text) > 11)
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtAgeMn.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtAgeMn, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtAgeMn, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
