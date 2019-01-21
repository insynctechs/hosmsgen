using System;
using System.Data;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmRptPatient : Form
    {
        Patients pat = new Patients();
        OptionVals opt = new OptionVals();

        public frmRptPatient()
        {
            InitializeComponent();
        }

        private void frmRptPatient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPatient.uspReport_Patient' table. You can move, or remove it, as needed.
            //this.uspReport_PatientTableAdapter.Fill(this.DataSetPatient.uspReport_Patient);
            try
            {
                this.reportViewer.RefreshReport();
                PopulateSearch();
                this.uspReport_PatientTableAdapter.Connection.Close();
                this.uspReport_PatientTableAdapter.Connection.ConnectionString = Helpers.DBHelper.Constr;
                this.uspReport_PatientTableAdapter.Connection.Open();
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
                cmbSearch.DataSource = pat.SearchValues(1);
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            populateReport();

        }

        private void populateReport()
        {
            try
            {
                //MessageBox.Show(this.uspReport_PatientTableAdapter.Connection.ConnectionString);
                this.uspReport_PatientTableAdapter.ClearBeforeFill = true;
                string rpt = "";
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                if (dtOpt.Rows.Count > 0)
                    rpt = dtOpt.Rows[0]["op_value"].ToString();

                Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFromDate.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtToDate.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("clientTitle", rpt)
                };
                reportViewer.LocalReport.SetParameters(rparams);
                this.DataSetPatient.Clear();
                this.uspReport_PatientTableAdapter.Fill(this.DataSetPatient.uspReport_Patient, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), cmbSearch.SelectedValue.ToString(), txtSearch.Text);
                this.reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmRptPatient_Shown(object sender, EventArgs e)
        {
            populateReport();
        }

        private void frmRptPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            pat.Dispose();
            opt.Dispose();
        }
    }
}
