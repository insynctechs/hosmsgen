using System;
using System.Data;
using System.Linq;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
using System.Windows.Forms;

namespace HospitalERP
{
    public partial class frmDashboard : Form
    {
        Users usr = new Users();
        Menus mn = new Menus();

        public frmDashboard()
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

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                if (LoggedUser.id > 0)
                {
                    SetMenuItems();

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
               
                string[] console1 = new string[] {"btnDashReg","btnDashApp","btnDashBill" };
                string[] console2 = new string[] { "btnDashDocs", "btnDashStaffGen", "btnDashStaffType", "btnDashDept", "btnDashProc", "btnDashProcType" };
                string[] console3 = new string[] { "btnDashUserRole", "btnDashOpt", "btnDashReports"};
                foreach (DataRow dr in dtMenu.Rows)
                {
                    string menu_name = dr["menu_name"].ToString();
                    string btn_name = menu_name.Replace("menuItem", "btnDash");
                    if (flowPanelDashMain.Controls.ContainsKey(btn_name))
                    {
                        flowPanelDashMain.Controls.RemoveByKey(btn_name);
                        console1 = console1.Where(val => val != btn_name).ToArray();
                        console2 = console2.Where(val => val != btn_name).ToArray();
                        console3 = console3.Where(val => val != btn_name).ToArray();
                    }
                }
                if(console1.Length==0)
                {
                    lblPatientServices.Visible = false;
                }
                if (console2.Length == 0)
                {
                    lblPatientConsole.Visible = false;
                }
                if (console3.Length == 0)
                {
                    lblAdminServices.Visible = false;
                }

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmDashboard_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnDashBillSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmBilling>().Count() == 1)
                    Application.OpenForms.OfType<frmBilling>().First().BringToFront();
                else
                {
                    frmBilling frm = new frmBilling();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashApp_Click(object sender, EventArgs e)
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
                        frm.MdiParent = this.MdiParent;
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
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnDashReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmPatient>().Count() == 1)
                    Application.OpenForms.OfType<frmPatient>().First().BringToFront();
                else
                {
                    frmPatient frm = new frmPatient(1);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashDocs_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmDoctors>().Count() == 1)
                    Application.OpenForms.OfType<frmDoctors>().First().BringToFront();
                else
                {
                    frmDoctors frm = new frmDoctors();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashStffGen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmStaffs>().Count() == 1)
                    Application.OpenForms.OfType<frmStaffs>().First().BringToFront();
                else
                {
                    frmStaffs frm = new frmStaffs();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashStaffType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmStaffTypes>().Count() == 1)
                    Application.OpenForms.OfType<frmStaffTypes>().First().BringToFront();
                else
                {
                    frmStaffTypes frm = new frmStaffTypes();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmDepartments>().Count() == 1)
                    Application.OpenForms.OfType<frmDepartments>().First().BringToFront();
                else
                {
                    frmDepartments frm = new frmDepartments();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmProcedures>().Count() == 1)
                    Application.OpenForms.OfType<frmProcedures>().First().BringToFront();
                else
                {
                    frmProcedures frm = new frmProcedures();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnDashUserRoles_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmUserRoles>().Count() == 1)
                    Application.OpenForms.OfType<frmUserRoles>().First().BringToFront();
                else
                {
                    frmUserRoles frm = new frmUserRoles();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashOpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmOptions>().Count() == 1)
                    Application.OpenForms.OfType<frmOptions>().First().BringToFront();
                else
                {
                    frmOptions frm = new frmOptions();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnDashReports_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmReports>().Count() == 1)
                Application.OpenForms.OfType<frmReports>().First().BringToFront();
                else {
            frmReports frm = new frmReports();
            frm.MdiParent = this.MdiParent;
            frm.Show();}
        }

        private void btnDashProcType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmProcTypes>().Count() == 1)
                    Application.OpenForms.OfType<frmProcTypes>().First().BringToFront();
                else
                {
                    frmProcTypes frm = new frmProcTypes();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Shown(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.id > 0)
                {
                    lblUEmpID.Text = LoggedUser.emp_id;
                    lblUName.Text = LoggedUser.name;
                    lblURole.Text = LoggedUser.type_name;
                    lblUDesig.Text = LoggedUser.designation;
                    lblUDept.Text = LoggedUser.department;
                    lblUNationality.Text = LoggedUser.nationality;
                    if (LoggedUser.gender != "" && LoggedUser.gender != null)
                        lblUGender.Text = Utils.Gender[LoggedUser.gender].ToString();
                    else
                        lblUGender.Text = "";
                    lblUType.Text = LoggedUser.staff_type;
                    lblULastLog.Text = LoggedUser.last_log_date.ToString();
                    if (LoggedUser.dob != null)
                        lblUDob.Text = LoggedUser.dob.ToString();
                    else
                        lblUDob.Text = "";
                    lblUPhone.Text = LoggedUser.phone;


                }
                OptionVals opt = new OptionVals();
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                if (dtOpt.Rows.Count > 0)
                    lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void lnkChangePwd2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void lnkLogout2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.MdiParent.Close();
        }

        private void btnDashMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmMedicine>().Count() == 1)
                    Application.OpenForms.OfType<frmMedicine>().First().BringToFront();
                else
                {
                    frmMedicine frm = new frmMedicine();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnDashMedType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmMedicineTypes>().Count() == 1)
                    Application.OpenForms.OfType<frmMedicineTypes>().First().BringToFront();
                else
                {
                    frmMedicineTypes frm = new frmMedicineTypes();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
