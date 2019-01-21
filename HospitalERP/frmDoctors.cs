using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
using System.Collections.Generic;

namespace HospitalERP
{
    public partial class frmDoctors : Form
    {
        
        Doctors doc = new Doctors();

        public frmDoctors()
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

        private void frmDoctors_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                PopulateSearch();
                GetDepartmentsCombo(0);
                if (txtID.Text == "")
                {
                    lblempid.Visible = false;
                    txtempid.Visible = false;
                }
                else
                {
                    lblempid.Visible = false;
                    txtempid.Visible = false;
                }
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
                cmbSearch.DataSource = doc.SearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";

                //populate cmbactive
                Dictionary<int, string> activeDictionary = new Dictionary<int, string>();
                activeDictionary.Add(1, "True");
                activeDictionary.Add(0, "False");

                cmbActive.DataSource = new BindingSource(activeDictionary, null);
                cmbActive.DisplayMember = "Value";
                cmbActive.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void ShowDoctors()
        {
            try
            {
                DataTable dtRecords = doc.GetDoctors(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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
             
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearControls()
        {
            try
            {
                txtID.Text = "";
                txtempid.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtDesignation.Text = "";
                txtQualification.Text = "";
                txtSpecialization.Text = "";
                rbGender1.Checked = true;
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
                chkActive.Checked = true;
                txtFee.Text = "";
                cmbDept.SelectedIndex = 0;
                txtUSERID.Text = "";
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int logged_in_user = LoggedUser.id;
                    int rtn = -1;
                    char gender;
                    if (rbGender1.Checked == true)
                        gender = 'M';
                    else
                        gender = 'F';
                    if (txtID.Text.Trim() == "") //add data
                    {

                        rtn = doc.addDoctors(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(cmbDept.SelectedValue.ToString()), txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text));

                        if (rtn == 0)
                            ShowStatus(0, "Type name should be unique");
                        else if (rtn == 1)
                        {
                            ShowStatus(1, "Record successfully added");
                            clearControls();
                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added.");
                        }
                    }
                    else //edit record
                    {
                        rtn = doc.editDoctors(Int32.Parse(txtID.Text.Trim()), Int32.Parse(txtUSERID.Text.Trim()), txtFirstName.Text, txtLastName.Text, Convert.ToInt32(cmbDept.SelectedValue.ToString()), txtDesignation.Text, txtQualification.Text, txtSpecialization.Text, gender, Convert.ToDateTime(dtpDob.Text), txtNationality.Text, txtPathaka.Text, Convert.ToDateTime(dtpPathakaExpiry.Text), txtAddress.Text, txtCity.Text, txtDistrict.Text, txtZip.Text, txtPhone.Text, txtEmail.Text, chkActive.Checked, Convert.ToDouble(txtFee.Text), logged_in_user);
                        //if (rtn == 0)
                        //  lblStatus.Text = "This name already exists. Please provide unique name.";
                        //else
                        if (rtn == 1)
                        {
                            ShowStatus(1, "Record successfully updated");
                            clearControls();

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "" && (cmbSearch.SelectedValue.ToString() != "All" && cmbSearch.SelectedValue.ToString() != "D.active"))
                MessageBox.Show("Please input search value");
            else
                ShowDoctors();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    e.Cancel = true;
                    txtFirstName.Focus();
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

        private void cmbDept_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbDept.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbDept, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbDept, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            decimal d;
            try
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
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void GetDepartmentsCombo(int tid)
        {
            try
            {
                cmbDept.DataSource = doc.GetDepartmentsCombo(tid);
                cmbDept.ValueMember = "Value";
                cmbDept.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvDept_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                setFormFields(Int32.Parse(txtID.Text));
                tabDoctors.SelectedIndex = 0;
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
                DataTable dt = doc.getRecordFromID(id);
                txtempid.Text = dt.Rows[0]["emp_id"].ToString();
                txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                txtLastName.Text = dt.Rows[0]["last_name"].ToString();
                txtDesignation.Text = dt.Rows[0]["designation"].ToString();
                txtQualification.Text = dt.Rows[0]["qualification"].ToString();
                txtSpecialization.Text = dt.Rows[0]["specialization"].ToString();
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
                chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["active"].ToString());
                txtFee.Text = dt.Rows[0]["consultation_fee"].ToString();
                GetDepartmentsCombo(Convert.ToInt32(dt.Rows[0]["department_id"].ToString()));
                cmbDept.SelectedValue = dt.Rows[0]["department_id"].ToString();
                txtUSERID.Text = dt.Rows[0]["user_id"].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtDesignation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDesignation.Text))
                {
                    e.Cancel = true;
                    txtFirstName.Focus();
                    errorProvider.SetError(txtDesignation, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtDesignation, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void tabDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabDoctors.SelectedIndex)
                {
                    case 0:
                        if (txtID.Text == "")
                        {
                            lblempid.Visible = false;
                            txtempid.Visible = false;
                        }
                        else
                        {
                            lblempid.Visible = true;
                            txtempid.Visible = true;
                        }
                        break;
                    case 1:
                        clearControls();
                        ShowDoctors();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "colBtnEdit":
                        txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                        setFormFields(Int32.Parse(txtID.Text));
                        tabDoctors.SelectedIndex = 0;
                        break;

                    case "colBtnResetPwd":

                        txtID.Text = dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                        DialogResult m = MessageBox.Show("Are you sure you want to reset the password for this Doctor", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (m == DialogResult.Yes)
                        {

                            try
                            {
                                string def_pwd = "12345";
                                int rtn = 0;
                                using (OptionVals objOpt = new OptionVals())
                                {
                                    DataTable dtOpt = objOpt.GetOptionFromName("DEFAULT_PWD");
                                    if (dtOpt.Rows.Count > 0)
                                        def_pwd = dtOpt.Rows[0]["op_value"].ToString();
                                    dtOpt = null;
                                }
                                using (Users objUsers = new Users())
                                {

                                    rtn = objUsers.SetPassword(dgvList.Rows[e.RowIndex].Cells["colEmpID"].Value.ToString(), def_pwd, 3);
                                    if (rtn == 0)
                                        MessageBox.Show("Error in changing password", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (rtn == 1)
                                    {
                                        MessageBox.Show("Password successfully reset to default value - " + def_pwd, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                CommonLogger.Info(ex.ToString());
                            }
                            finally
                            {

                            }
                        }
                        else if (m == DialogResult.No)
                        {
                            // Do something else
                        }

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
            try
            {
                clearControls();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmDoctors_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utils.toggleChildCloseButton(this.MdiParent, 1);
                doc.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbActive.Visible == true && cmbSearch.SelectedValue.ToString() == "D.active")
                    txtSearch.Text = cmbActive.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                if (cmbSearch.SelectedValue.ToString().ToUpper() == "ALL")
                {
                    txtSearch.Visible = false;
                    cmbActive.Visible = false;
                }
                else if (cmbSearch.SelectedValue.ToString() == "D.active")
                {
                    txtSearch.Visible = false;
                    cmbActive.Visible = true;
                    txtSearch.Text = cmbActive.SelectedValue.ToString();
                }
                else if (cmbSearch.SelectedIndex > 0)
                {
                    txtSearch.Visible = true;
                    cmbActive.Visible = false;
                }

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
