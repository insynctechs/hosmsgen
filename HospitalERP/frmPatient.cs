using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                    if (txtID.Text.Trim() == "") //add data
                    {
                        exists = pat.existPatients(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text.Trim(), txtPhone.Text.Trim());
                        if (exists <= 0)
                        {
                            rtn = pat.addPatients(txtFirstName.Text, txtLastName.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user);

                            if (rtn >= 1)
                            {
                                ShowStatus(1, "Record succesfully added. ");
                                clearFormFields();
                                if (chkAppointment.Checked == true)
                                {
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

                        rtn = pat.editPatients(Int32.Parse(txtID.Text), txtFirstName.Text, txtLastName.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, txtHistory.Text, txtAllergies.Text, logged_in_user);

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
                dtpDob.Text = "";
                txtNationality.Text = "";
                txtPathaka.Text = "";
                dtpPathakaExpiry.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtDistrict.Text = "";
                txtZip.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtAllergies.Text = "";
                txtHistory.Text = "";

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
                DateTime check;
                if (string.IsNullOrEmpty(dtpDob.Text))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        dtpDob.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(dtpDob, "Required");
                }
                else if(DateTime.TryParse(dtpDob.Text, out check) && check > DateTime.Now)
                {
                    e.Cancel = true;
                    errorfocus = true;
                    dtpDob.Focus();
                    errorProvider.SetError(dtpDob, "DoB should be less than current date");
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
                if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
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

        private void frmPatient_Shown(object sender, EventArgs e)
        {

        }
    }
}
