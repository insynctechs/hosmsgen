using System;
using System.Windows.Forms;
using System.Drawing;
using HospitalERP.Procedures;
using System.Data;
using System.Linq;
using HospitalERP.Helpers;
using System.Collections.Generic;
namespace HospitalERP
{
    public partial class frmUserRoles : Form
    {
        UserRoles UR = new UserRoles();
        Menus mn = new Menus();
       
        private bool updatingTreeView;

        public frmUserRoles()
        {
            InitializeComponent();
        }

        private void frmUserRoles_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            txtSearch.Visible = false;
            dgvList.AutoGenerateColumns = false;
        }
        private void PopulateSearch()
        {
            try
            {
                cmbSearch.DataSource = UR.SearchValues();
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

        private void ShowRecords()
        {
            try
            {
                DataTable dtRecords = UR.GetRecords(cmbSearch.SelectedValue.ToString(), txtSearch.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int rtn = -1;
                    // int nodeCount = trvMenu.SelectedNode.GetNodeCount(true);
                    //check tree nodes are checked
                    /*TreeNode tn = trvMenu.SelectedNode;
                    if (tn == null)
                    */
                    /*int nodeCount = trvMenu.SelectedNode.Nodes.Count;
                      
                    if(nodeCount<=0)
                        ShowStatus(0, "Please select atleast one accessible menu item.");
                    else*/
                    if (txtID.Text.Trim() == "") //add data
                    {
                  
                        rtn = UR.addTypes(txtName.Text.Trim(), txtDesc.Text.Trim(), chkActive.Checked);
                        //int ret = UpdateMenuAccess();
                        if (rtn == 0)
                            ShowStatus(0, "Type name should be unique");
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
                        rtn = UR.editTypes(Int32.Parse(txtID.Text.Trim()), txtName.Text, txtDesc.Text, chkActive.Checked);
                        int ret = UpdateMenuAccess();
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
                CommonLogger.Info(ex.ToString());
            }
        }

        private int UpdateMenuAccess()
        {
            DataTable dtChkMenu = new DataTable();
            try
            {     
                dtChkMenu.Columns.Add("id");
                foreach (TreeNode node in trvMenu.Nodes)
                {
                    if (node.Checked == true)
                    {
                        //dtChkMenu.Rows.Add("id");
                        dtChkMenu.Rows.Add(new object[] { node.Name.Replace("trvn", "") });

                    }
                    dtChkMenu = TraverseRecursiveToGetChecked(node, dtChkMenu);

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            if (dtChkMenu.Rows.Count > 0)
            {
                int ret = mn.UpdateUserTypeMenus(dtChkMenu, Int32.Parse(txtID.Text));
                return ret;
            }
            else
                return 0;
        }

        private DataTable TraverseRecursiveToGetChecked(TreeNode treeNode, DataTable dtChkMenu)
        {
            try
            {
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        //dtChkMenu.Rows.Add("id");
                        dtChkMenu.Rows.Add(new object[] { tn.Name.Replace("trvn", "") });

                    }
                    dtChkMenu = TraverseRecursiveToGetChecked(tn, dtChkMenu);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
            return dtChkMenu;
        }

        private void SetMenuChecksOnEdit()
        {
            try
            {
                DataTable dtCheckMenu = mn.GetUserTypeMenus(Int32.Parse(txtID.Text));
                if (dtCheckMenu.Rows.Count > 0)
                {
                    foreach (TreeNode node in trvMenu.Nodes)
                    {
                        TraverseRecursiveToSetChecked(node, dtCheckMenu);

                    }
                }

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void TraverseRecursiveToSetChecked(TreeNode treeNode, DataTable dtChkMenu)
        {
            try
            {
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    int id = Int32.Parse(tn.Name.Replace("trvn", ""));
                    bool contains = dtChkMenu.AsEnumerable().Any(row => id == row.Field<int>("menu_id"));
                    if (contains)
                    {
                        tn.Checked = true;

                    }
                    TraverseRecursiveToSetChecked(tn, dtChkMenu);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }


        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtName.Text.Trim()) && txtID.Text == "")
                {
                    e.Cancel = true;
                    txtName.Focus();
                    errorProvider.SetError(txtName, "Required");
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
                txtID.Text = dgvList.Rows[index].Cells["colID"].Value.ToString();
                txtName.Text = dgvList.Rows[index].Cells["colName"].Value.ToString();
                txtDesc.Text = dgvList.Rows[index].Cells["colDescription"].Value.ToString();
                chkActive.Checked = (bool)dgvList.Rows[index].Cells["colActive"].Value;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "" && (cmbSearch.SelectedValue.ToString() != "All" && cmbSearch.SelectedValue.ToString() != "active"))
                MessageBox.Show("Please input search value");
            else
                ShowRecords();
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
                chkActive.Checked = true;
                txtID.Text = "";
                UncheckAllNodes(trvMenu.Nodes);
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

        public void BuildTree(DataTable dt, TreeView trv, Boolean expandAll)
        {
            try
            {
                trv.Nodes.Clear();
                TreeNode node = default(TreeNode);
                TreeNode subNode = default(TreeNode);
                foreach (DataRow row in dt.Rows)
                {

                    if (Int32.Parse(row["parent_id"].ToString()) == 0)
                    {
                        node = new TreeNode(row["menu_text"].ToString());
                        node.Name = "trvn" + row["id"].ToString();
                        trv.Nodes.Add(node);
                    }
                    else
                    {
                        //node = trv.Nodes.("trvn" + row["parent_id"].ToString(), true);
                        node = SearchNode("trvn" + row["parent_id"].ToString(), trv);
                        if (node != null)
                        {

                            subNode = new TreeNode(row["menu_text"].ToString());
                            subNode.Name = "trvn" + row["id"].ToString();
                            node.Nodes.Add(subNode);
                        }
                        else
                        {
                            node = new TreeNode(row["menu_text"].ToString());
                            node.Name = "trvn" + row["id"].ToString();
                            trv.Nodes.Add(node);
                        }
                    }


                }
                if (expandAll)
                {
                    trv.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private TreeNode SearchNode(string nodeparent, TreeView trv)
        {
            try
            {
                foreach (TreeNode node in trv.Nodes)
                {
                    if (node.Name == nodeparent)
                    {
                        return node;

                    }

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
            return null;
            
        }

        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = true;
                    CheckChildren(node, true);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = false;
                    CheckChildren(node, false);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            try
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    CheckChildren(node, isChecked);
                    node.Checked = isChecked;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void trvMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (updatingTreeView)
                    return;
                updatingTreeView = true;
                SelectChildrenOnParentSelect(e.Node, e.Node.Checked);
                SelectParentOnChildSelect(e.Node, e.Node.Checked);

                updatingTreeView = false;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void SelectParentOnChildSelect(TreeNode node, Boolean isChecked)
        {
            try
            {
                var parent = node.Parent;

                if (parent == null)
                    return;

                if (isChecked)
                {
                    parent.Checked = true; // we should always check parent
                    SelectParentOnChildSelect(parent, true);
                }
                else
                {
                    if (parent.Nodes.Cast<TreeNode>().All(n => n.Checked))
                    {
                        parent.Checked = true;
                        return; // do not uncheck parent if there other checked nodes
                    }
                    else if (parent.Nodes.Cast<TreeNode>().Any(n => n.Checked))
                    {
                        parent.Checked = true;
                        return; // do not uncheck parent if there other checked nodes
                    }
                    else
                    {
                        parent.Checked = false;
                        return; // do not uncheck parent if there other checked nodes
                    }

                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        
        private void SelectChildrenOnParentSelect(TreeNode node, Boolean isChecked)
        {
            try
            {
                bool checkChildren = (node.Checked);
                if (node.Nodes.Count == 0)
                {
                    return;
                }
                if (checkChildren == true)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = true; // !childNode.Checked;
                    }
                }
                if (checkChildren == false)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = false; // !childNode.Checked;
                    }
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
                if (txtID.Text.Trim() != "")
                {
                    SetMenuChecksOnEdit();
                    if (Int32.Parse(txtID.Text.Trim()) < 4)
                        txtName.ReadOnly = true;

                }
                else
                    txtName.ReadOnly = false;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmUserRoles_Shown(object sender, EventArgs e)
        {
            try
            {
                PopulateSearch();
                DataTable dtMenu = mn.GetMenuActive(true);
                BuildTree(dtMenu, trvMenu, true);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmUserRoles_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utils.toggleChildCloseButton(this.MdiParent, 1);
                mn.Dispose();
                UR.Dispose();
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

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbActive.Visible == true && cmbSearch.SelectedValue.ToString() == "active")
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
                else if (cmbSearch.SelectedValue.ToString() == "active")
                {
                    txtSearch.Visible = false;
                    cmbActive.Visible = true;
                    txtSearch.Text = cmbActive.SelectedValue.ToString();
                }
                else if(cmbSearch.SelectedIndex >0)
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
