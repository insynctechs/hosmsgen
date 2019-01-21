using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmOptions : Form
    {
        OptionVals opt = new OptionVals();
        
        private bool errorfocus = false;
        public frmOptions()
        {
            InitializeComponent();
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
            try
            {
                if (txtSearch.Text.Trim() == "" && cmbSearch.SelectedValue.ToString() != "All" )
                    MessageBox.Show("Please input search value");
                else
                    ShowRecords();
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

                    int rtn = -1;
                    if (txtID.Text.Trim() == "") //add data
                    {
                        rtn = opt.InsertOption(txtName.Text.Trim().ToUpper(), txtDesc.Text.Trim(), txtVal.Text.Trim());
                        if (rtn == 0)
                            ShowStatus(0, "Name should be unique");
                        else if (rtn == 1)
                        {
                            ShowStatus(1, "Record succesfully added");
                            clearFormFields();

                        }
                        else if (rtn == -1)
                        {
                            ShowStatus(0, "Some error occurred... Record cannot be added.");
                        }
                    }
                    else //edit record
                    {
                        rtn = opt.editOptions(Int32.Parse(txtID.Text.Trim()), txtName.Text.Trim().ToUpper(), txtDesc.Text.Trim(), txtVal.Text.Trim());
                        if (rtn == 0)
                            ShowStatus(0, "This name already exists. Please provide unique name.");
                        else if (rtn == 1)
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
                ShowStatus(0, "Duplicate Entry... Record cannot be added.");
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            try
            {
                dgvList.AutoGenerateColumns = false;
                this.WindowState = FormWindowState.Maximized;
                PopulateSearch();
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
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
                DataTable dtRecords = opt.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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

        private void PopulateSearch()
        {
            try
            {
                cmbSearch.DataSource = opt.SearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
                
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

        private void clearFormFields()
        {
            try
            {

                txtName.Text = "";
                txtDesc.Text = "";
                txtVal.Text = "";
                txtID.Text = "";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            //PopulateProcTypeCombo(0);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() != "")
                    txtName.ReadOnly = true;
                else
                    txtName.ReadOnly = false;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtName.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtName, "Required");
                }
                else if (Regex.IsMatch(txtName.Text, @"[^\w\-]"))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtName.Focus();
                        errorfocus = true;
                    }

                    errorProvider.SetError(txtName, "Allowed characters are alphabets, digits, hyphen and underscore.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtName, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtVal_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtVal.Text))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtVal.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtVal, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtVal, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                setFormFields(e.RowIndex);
                tabSub.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void setFormFields(int index)
        {
            try
            {
                txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
                txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
                txtDesc.Text = dgvList.Rows[index].Cells["colDesc"].Value.ToString();
                txtVal.Text = dgvList.Rows[index].Cells["colVal"].Value.ToString();
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

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "colBtnEdit":
                        setFormFields(e.RowIndex);
                        tabSub.SelectedIndex = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmOptions_Shown(object sender, EventArgs e)
        {

        }

        private void frmOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            opt.Dispose();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            try
            {
                if (cmbSearch.SelectedValue.ToString().ToUpper() == "ALL")
                {
                    txtSearch.Visible = false;                  
                }               
                else if (cmbSearch.SelectedIndex > 0)
                {
                    txtSearch.Visible = true;                 
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
