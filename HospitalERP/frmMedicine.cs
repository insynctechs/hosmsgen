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
    public partial class frmMedicine : Form
    {
        Medicines med = new Medicines();
        public bool modal = false;
        public frmMedicine()
        {
            InitializeComponent();
        }

        public frmMedicine(int width, int height)
        {
            InitializeComponent();
            this.Size = new Size(width, height);
            modal = true;
        }

        private void frmMedicine_Load(object sender, EventArgs e)
        {
            try
            {
                if (modal == false)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    tabSub.TabPages.Remove(tabPgList);
                }
                dgvList.AutoGenerateColumns = false;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
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
                cmbSearch.DataSource = med.SearchValues();
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

        private void PopulateProcTypeCombo(int tid)
        {
            try
            {
                using (MedicineTypes medType = new MedicineTypes())
                {
                    cmbProcType.DataSource = medType.ProcTypesCombo(tid);
                    cmbProcType.ValueMember = "Value";
                    cmbProcType.DisplayMember = "Display";
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowProcedureTests()
        {
            try
            {
                DataTable dtRecords = med.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    //int cmbProcTypeVal = (int)cmbProcType.SelectedValue.ToString)();
                    if (txtID.Text.Trim() == "") //add data
                    {
                        rtn = med.InsertProcedure(txtName.Text, txtDesc.Text, Convert.ToInt32(cmbProcType.SelectedValue.ToString()), chkActive.Checked);
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

                            if (modal == true)
                            {
                                this.Close();
                            }
                        }
                    }
                    else //edit record
                    {
                        rtn = med.editProcedures(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, Convert.ToInt32(cmbProcType.SelectedValue.ToString()), chkActive.Checked);
                        if (rtn == 0)
                            ShowStatus(0, "This name already exists. Please provide unique name!");
                        else if (rtn == 1)
                        {
                            ShowStatus(1, "Record succesfully updated!");
                            clearFormFields();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "" && (cmbSearch.SelectedValue.ToString() != "All" && cmbSearch.SelectedValue.ToString() != "active"))
                MessageBox.Show("Please input search value");
            else
                ShowProcedureTests();
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



        private void tabSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabSub.SelectedIndex)
                {
                    case 0:
                        if (cmbProcType.SelectedIndex == 0)
                            PopulateProcTypeCombo(0);
                        break;
                    case 1:
                        ShowProcedureTests();
                        break;
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
                cmbProcType.SelectedIndex = 0;
                txtName.Text = "";
                txtDesc.Text = "";                
                chkActive.Checked = true;
                txtID.Text = "";
                //PopulateProcTypeCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbProcType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbProcType.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbProcType, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbProcType, null);
                }
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
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    e.Cancel = true;
                    //txtName.Focus();
                    errorProvider.SetError(txtName, "Required");
                }
                /*else if (med.GetRecords("p.name", txtName.Text.Trim()).Rows.Count > 0)
                {
                    e.Cancel = true;
                    //txtName.Focus();
                    errorProvider.SetError(txtName, "Name Already Exists!");
                }*/
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

        private void txtDesc_Validating(object sender, CancelEventArgs e)
        {            
            try
            {
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    e.Cancel = true;
                    //txtFee.Focus();
                    errorProvider.SetError(txtDesc, "Required");
                }                
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtDesc, null);
                }
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
                txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
                DataTable dt = med.getRecordFromID(Convert.ToInt32(txtID.Text));
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtDesc.Text = dt.Rows[0]["prescription"].ToString();                
                PopulateProcTypeCombo(Convert.ToInt32(dt.Rows[0]["type"].ToString()));
                cmbProcType.SelectedValue = dt.Rows[0]["type"].ToString();
                //cmbProcType.SelectedItem = cmbProcType.FindStringExact(cmbText);

                chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["active"].ToString());
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

        private void frmMedicine_Shown(object sender, EventArgs e)
        {
            try
            {
                PopulateSearch();
                PopulateProcTypeCombo(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmMedicine_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.IsMdiChild)
                    Utils.toggleChildCloseButton(this.MdiParent, 1);
                med.Dispose();
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

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbActive.Visible == true && cmbSearch.SelectedValue.ToString() == "p.active")
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
                else if (cmbSearch.SelectedValue.ToString() == "p.active")
                {
                    txtSearch.Visible = false;
                    cmbActive.Visible = true;
                    txtSearch.Text = cmbActive.SelectedValue.ToString();
                }
                else if(cmbSearch.SelectedIndex > 0)
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
