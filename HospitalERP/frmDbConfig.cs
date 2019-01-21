using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using HospitalERP.Helpers;
using HospitalERP.Procedures;
using MySql.Data.MySqlClient;

namespace HospitalERP
{
    public partial class frmDbConfig : Form
    {
        Users usr = new Users();
        public frmDbConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                try
                {

                    bool valid = false;
                    //license key validation
                    string LicKey = txtLic1.Text.Trim()+"-"+txtLic2.Text.Trim()+"-"+txtLic3.Text.Trim()+"-"+txtLic4.Text.Trim();
                    //string connStr = "server=166.62.28.130;PORT=3306;user=homelinks_user;database=homelinks;password=homelinks_user@2017; SSL Mode = None;";
                    string connStr = "server=173.205.126.241;PORT=3306;user=insync8_inscusr;database=insync8_erp_lic;password=ZgP&8E19HsrS; SSL Mode = None;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    
                    string sql = "SELECT * FROM erp_license WHERE license_key='"+LicKey+"' and server_name='"+ MySql.Data.MySqlClient.MySqlHelper.EscapeString(txtServer.Text.Trim())+"' and user_name='"+txtUserName.Text.Trim()+"' and user_pwd='"+txtPassword.Text.Trim()+"'";
                    //sql = MySql.Data.MySqlClient.MySqlHelper.EscapeString(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows == false) //if no license records
                        valid = false;

                    while (rdr.Read())
                    {
                        if (rdr["activated"].ToString() == "1")
                        {
                            MessageBox.Show("You have already used your license. Cannot install more.", "Warning", MessageBoxButtons.OK);
                            valid = false;
                        }
                        else
                            valid = true;

                    }


                    if (valid == true)
                    {
                        //Update  registry with new connection string
                        //opening the subkey  
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP\dset\", true);

                        //if it does exist, retrieve the stored values  
                        if (key != null)
                        {
                            //chk the connection string is valid
                            //if yes insert the values to registry
                            //else give error msg
                            try
                            {
                                //var conn = new SqlConnection(strConn);
                                key.SetValue("srvr", txtServer.Text.Trim());
                                key.SetValue("catlog", "hospitalERP_db");
                                key.SetValue("usrkey", txtUserName.Text.Trim());
                                key.SetValue("usrval", txtPassword.Text.Trim());
                                key.SetValue("reset", "true");
                                key.Close();

                                int ret = usr.ValidateLogin("admin", "12345");
                                if (ret > 0)
                                {
                                    //opening the subkey  
                                    RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HospitalERP", true);
                                    key1.SetValue("first_run", false);
                                    key1.Close();
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Connection cannot be established!!! Please check the server details.", "Warning", MessageBoxButtons.OK);
                                    
                                
                            }
                            catch (Exception ex)
                            {
                                CommonLogger.Info(ex.ToString());
                            }
                            finally
                            {
                                rdr.Close();
                                conn.Close();
                            }

                        }

                    }
                    else
                        MessageBox.Show("Unauthorized Access!", "Warning", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void frmDbConfig_Load(object sender, EventArgs e)
        {
            // var settings = ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];
            // MessageBox.Show(settings.ConnectionString.ToString());
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtServer_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtServer.Text.Trim()))
                {
                    e.Cancel = true;
                    txtServer.Focus();
                    errorProvider.SetError(txtServer, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtServer, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    txtUserName.Focus();
                    errorProvider.SetError(txtUserName, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtUserName, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    e.Cancel = true;
                    txtPassword.Focus();
                    errorProvider.SetError(txtPassword, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtPassword, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtLic1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLic1.Text.Trim()))
                {
                    e.Cancel = true;
                    txtLic1.Focus();
                    errorProvider.SetError(txtLic1, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtLic1, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtLic2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLic2.Text.Trim()))
                {
                    e.Cancel = true;
                    txtLic2.Focus();
                    errorProvider.SetError(txtLic2, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtLic2, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtLic3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLic3.Text.Trim()))
                {
                    e.Cancel = true;
                    txtPassword.Focus();
                    errorProvider.SetError(txtLic3, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtLic3, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void txtLic4_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLic4.Text.Trim()))
                {
                    e.Cancel = true;
                    txtPassword.Focus();
                    errorProvider.SetError(txtLic4, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtLic4, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
