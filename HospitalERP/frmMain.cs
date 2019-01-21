using System;
using System.Data;
using System.Linq;
using HospitalERP.Procedures;
using System.Windows.Forms;
using HospitalERP.Helpers;

namespace HospitalERP
{    
    public partial class frmMain : Form
    {

        Users usr = new Users();
        Menus mn = new Menus();
        
        public frmMain()
        {
            try
            {
                InitializeComponent();
                LoggedUser.id = 1;
                LoggedUser.emp_id = "ADMIN";
                LoggedUser.type_id = 1;
                LoggedUser.type_name = "SUPER ADMIN";
                LoggedUser.phone = "";
                LoggedUser.last_log_date = "";
                LoggedUser.name = "ADMIN";
                LoggedUser.staff_id = 0;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        public frmMain(string empid)
        {
            InitializeComponent();
            try
            {
               
                DataTable dtUser = usr.GetLoggedUser(empid);
                lblEmpID.Text = empid;
                if (dtUser.Rows.Count > 0)
                {                    
                    LoggedUser.setLoggedUser(dtUser);
                    usr.SetLoginDate(empid);
                    lblEmpID.Text = LoggedUser.name;
                    if (LoggedUser.type_id == 1)
                        lblEmpID.Text = "SUPER ADMIN";
                }
                else
                {
                           
                }

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void Hospital_Load(object sender, EventArgs e)
        {
            try
            {
                MdiClient CtlMdi;
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        string type = ctl.GetType().ToString();
                        if (type.Equals("System.Windows.Forms.MdiClient"))
                        {
                            CtlMdi = (MdiClient)ctl;
                            CtlMdi.BackColor = System.Drawing.Color.White;
                        }
                    }
                    catch (Exception a)
                    {
                        CommonLogger.Info(a.ToString());
                    }
                }
                if (LoggedUser.id > 0)
                {
                    SetMenuItems();
                    lnkChangePwd.Visible = true;
                    tblLoginPanel.Visible = true;
                }
                else
                {
                    lnkChangePwd.Visible = false;
                    tblLoginPanel.Visible = false;
                }
                frmDashboard frm = new frmDashboard();
                frm.MdiParent = this;
                frm.Show();
            }
            catch(Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        

        private void menuItemStaffOthers_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmStaffs>().Count() == 1)
                    Application.OpenForms.OfType<frmStaffs>().First().BringToFront();
                else
                {
                    frmStaffs frm = new frmStaffs();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemDocs_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmDoctors>().Count() == 1)
                    Application.OpenForms.OfType<frmDoctors>().First().BringToFront();
                else
                {
                    frmDoctors frm = new frmDoctors();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemStaffType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmStaffTypes>().Count() == 1)
                    Application.OpenForms.OfType<frmStaffTypes>().First().BringToFront();
                else
                {
                    frmStaffTypes frm = new frmStaffTypes();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmDepartments>().Count() == 1)
                    Application.OpenForms.OfType<frmDepartments>().First().BringToFront();
                else
                {
                    frmDepartments frm = new frmDepartments();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmProcedures>().Count() == 1)
                    Application.OpenForms.OfType<frmProcedures>().First().BringToFront();
                else
                {
                    frmProcedures frm = new frmProcedures();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemUserRoles_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmUserRoles>().Count() == 1)
                    Application.OpenForms.OfType<frmUserRoles>().First().BringToFront();
                else
                {
                    frmUserRoles frm = new frmUserRoles();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemProcType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmProcTypes>().Count() == 1)
                    Application.OpenForms.OfType<frmProcTypes>().First().BringToFront();
                else
                {
                    frmProcTypes frm = new frmProcTypes();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemOpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmOptions>().Count() == 1)
                    Application.OpenForms.OfType<frmOptions>().First().BringToFront();
                else
                {
                    frmOptions frm = new frmOptions();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                closeChildren(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        static void closeChildren(Form parent)
        {
            try
            {
                foreach (var child in parent.MdiChildren)
                {
                    closeChildren(child);
                    child.Dispose();
                    child.Close();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void SetMenuItems()
        {
            try
            {
                DataTable dtMenu = mn.GetUserTypeMenusRemoveList(LoggedUser.type_id);
                foreach (DataRow dr in dtMenu.Rows)
                {
                    string menu_name = dr["menu_name"].ToString();
                    MainMenu.Items.RemoveByKey(menu_name);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                    Application.OpenForms.OfType<frmPatient>().First().BringToFront();
                else
                {
                    frmPatient frm = new frmPatient();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void menuItemApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.type_name.ToUpper() == "DOCTOR")
                {
                    if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                        Application.OpenForms.OfType<frmConsultations>().First().BringToFront();
                    else
                    {
                        frmConsultations frm = new frmConsultations();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }
                else
                {

                    if (Application.OpenForms.OfType<frmAppointments>().Count() == 1)
                        Application.OpenForms.OfType<frmAppointments>().First().BringToFront();
                    else
                    {
                        frmAppointments frm = new frmAppointments();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        

        private void menuItemBillSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmBilling>().Count() == 1)
                    Application.OpenForms.OfType<frmBilling>().First().BringToFront();
                else
                {
                    frmBilling frm = new frmBilling();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemPatSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                    Application.OpenForms.OfType<frmPatient>().First().BringToFront();
                else
                {
                    frmPatient frm = new frmPatient(1);
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void menuItemConsultations_Click(object sender, EventArgs e)
        {

        }

        private void lnkChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmChangePassword frm = new frmChangePassword();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmDashboard>().Count() == 1)
                    Application.OpenForms.OfType<frmDashboard>().First().BringToFront();
                else
                {
                    frmDashboard frm = new frmDashboard();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnChildClose_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ActiveMdiChild.Dispose();
                this.ActiveMdiChild.Close();
                int childCount = getChildCount();
                if (childCount == 0)
                    btnChildClose.Visible = false;
                else
                    btnChildClose.Visible = true;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() != typeof(frmDashboard) && form.GetType() != typeof(frmMain) && form.GetType() != typeof(frmLogin))
                    {
                        btnChildClose.Visible = true;
                        //MessageBox.Show(form.GetType().Name);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        public void DisposeAllButThis(Form form)
        {
            try
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.GetType() == form.GetType()
                        && frm != form)
                    {
                        frm.Dispose();
                        frm.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        

        public int getChildCount()
        {
            int childCount = 0;
            try
            {
                
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.GetType() != typeof(frmDashboard) && frm.GetType() != typeof(frmMain) && frm.GetType() != typeof(frmLogin))
                    {
                        childCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
            return childCount;
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.type_name.ToUpper() == "DOCTOR")
                {
                    if (Application.OpenForms.OfType<frmConsultations>().Count() == 1)
                        Application.OpenForms.OfType<frmConsultations>().First().BringToFront();
                    else
                    {
                        frmConsultations frm = new frmConsultations();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }
                else
                {

                    if (Application.OpenForms.OfType<frmAppointments>().Count() == 1)
                        Application.OpenForms.OfType<frmAppointments>().First().BringToFront();
                    else
                    {
                        frmAppointments frm = new frmAppointments();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                    Application.OpenForms.OfType<frmPatient>().First().BringToFront();
                else
                {
                    frmPatient frm = new frmPatient();
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void menuitemBillingReport_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptBilling rep = new frmRptBilling();
                rep.MdiParent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void miPatientRpt_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptPatient fmPat = new frmRptPatient();
                fmPat.MdiParent = this;
                fmPat.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void miSickLeaveRpt_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptSickLeave rsl = new frmRptSickLeave();
                rsl.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            try
            {
              
                frmAbout fab = new frmAbout();
                fab.ShowDialog(this);
            }
            catch(Exception ex)
            {
                //CommonLogger.Error("frmMain", ex);
                CommonLogger.Info(ex.ToString());
            }

        }

        private void miServerDetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmDbConfig fdc = new frmDbConfig();
                fdc.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void menuItemMedType_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedicineTypes fdc = new frmMedicineTypes();
                fdc.MdiParent = this;
                fdc.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void menuItemMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedicine fm = new frmMedicine();
                fm.MdiParent = this;
                fm.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
    }
}
