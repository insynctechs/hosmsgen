using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmRptProcedure : Form
    {
        Patients pat = new Patients();
        OptionVals opt = new OptionVals();

        public frmRptProcedure()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmRptProcedure_Shown(object sender, EventArgs e)
        {
            populateReport();
        }

        private void populateReport()
        {
            try
            {
                //MessageBox.Show(this.uspReport_PatientTableAdapter.Connection.ConnectionString);
                this.uspReport_ProcedureTableAdapter.ClearBeforeFill = true;
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
                this.dataSetProcedure.Clear();
                this.uspReport_ProcedureTableAdapter.Fill(this.dataSetProcedure.uspReport_Procedure, Convert.ToDateTime(dtFromDate.Value), Convert.ToDateTime(dtToDate.Value), txtSearch.Text);
                this.reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmRptProcedure_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPatient.uspReport_Patient' table. You can move, or remove it, as needed.
            //this.uspReport_PatientTableAdapter.Fill(this.DataSetPatient.uspReport_Patient);
            try
            {
                this.reportViewer.RefreshReport();
                
                this.uspReport_ProcedureTableAdapter.Connection.Close();
                this.uspReport_ProcedureTableAdapter.Connection.ConnectionString = Helpers.DBHelper.Constr;
                this.uspReport_ProcedureTableAdapter.Connection.Open();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
    }
}
