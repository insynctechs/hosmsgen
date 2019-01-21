using System;
using System.Windows.Forms;
using HospitalERP.Helpers;
using System.Linq;

namespace HospitalERP
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnBillingRpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmRptBilling>().Count() == 1)
                    Application.OpenForms.OfType<frmRptBilling>().First().BringToFront();
                else
                {

                    frmRptBilling frm = new frmRptBilling();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnPatientRpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.OfType<frmRptPatient>().Count() == 1)
                    Application.OpenForms.OfType<frmRptPatient>().First().BringToFront();
                else
                {
                 
                    frmRptPatient frm = new frmRptPatient();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
        }
    }
}
