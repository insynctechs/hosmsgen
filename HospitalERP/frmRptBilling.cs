using System;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmRptBilling : Form
    {
        Bill bill = new Bill();
        OptionVals opt = new OptionVals();

        public frmRptBilling()
        {
            InitializeComponent();
        }

        private void frmRptBilling_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateStatusCombo();
                PopulateTypesCombo();
                this.uspReport_BillingTableAdapter.Connection.Close();
                this.uspReport_BillingTableAdapter.Connection.ConnectionString = Helpers.DBHelper.Constr;
                this.uspReport_BillingTableAdapter.Connection.Open();
                /*
                     Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                   {
                   new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString())
                   };
                   reportViewer.LocalReport.SetParameters(rparams);

                   // TODO: This line of code loads data into the 'DataSetBilling.uspReport_Billing' table. You can move, or remove it, as needed.
                   this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), Int32.Parse(cmbType.SelectedValue.ToString()),Int32.Parse(cmbStatus.SelectedValue.ToString()));
                   this.reportViewer.RefreshReport();
                   */

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void populateReport()
        {
            try
            {
                
                this.uspReport_BillingTableAdapter.ClearBeforeFill = true;
                /*reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsname", uspReport_BillingBindingSource));
                */ReportParameter[] rparams = new ReportParameter[3]; 
                rparams[0] = new ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()); 
                rparams[1] = new ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString());
                string rpt = "";
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                if (dtOpt.Rows.Count > 0)
                    rpt = dtOpt.Rows[0]["op_value"].ToString();

                rparams[2] = new ReportParameter("clientTitle", rpt);
                this.reportViewer.LocalReport.SetParameters(rparams);
                /*
                Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString())
                };
                reportViewer.LocalReport.se.SetParameters(rparams);*/
                this.DataSetBilling.Clear();
                this.uspReport_BillingTableAdapter.Fill(this.DataSetBilling.uspReport_Billing, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), Int32.Parse(cmbType.SelectedValue.ToString()), Int32.Parse(cmbStatus.SelectedValue.ToString()));
                this.reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
        private void PopulateStatusCombo()
        {
            try
            {
                cmbStatus.DataSource = bill.GetBillStatus(1);
                cmbStatus.DisplayMember = "name";
                cmbStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void PopulateTypesCombo()
        {
            try
            {
                cmbType.DataSource = bill.GetBillTypes(1);
                cmbType.DisplayMember = "name";
                cmbType.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            populateReport();
        }

        private void frmRptBilling_Shown(object sender, EventArgs e)
        {
            populateReport();
        }

        private void frmRptBilling_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            opt.Dispose();
            bill.Dispose();

        }
    }
}
