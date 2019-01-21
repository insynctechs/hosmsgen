using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
using System.Text.RegularExpressions;

namespace HospitalERP
{
    public partial class frmRptSickLeave : Form
    {
        ConsultationDetails objCD = new ConsultationDetails();
        OptionVals opt = new OptionVals();
        public int appointment_id = 0;
        public int patient_id = 0;
        private bool errorfocus = false;
        

        public frmRptSickLeave()
        {
            InitializeComponent();
        }


        public frmRptSickLeave(int aptid, int patid)
        {
            try
            {
                InitializeComponent();
                appointment_id = aptid;
                patient_id = patid;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }
        private void frmRptSickLeave_Load(object sender, EventArgs e)
        {
            //reportViewer.Hide();
            try
            {
                DataTable dt = objCD.getRecordFromID(appointment_id);
                txtPatientNo.Text = dt.Rows[0]["patient_number"].ToString();
                txtPatientName.Text = dt.Rows[0]["patient_name"].ToString();
                txtGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                //txtDob.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
                txtAge.Text = dt.Rows[0]["age"].ToString();
                txtAppDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());
                txtDoctorName.Text = dt.Rows[0]["doctor_name"].ToString();
                //txtNationality.Text = dt.Rows[0]["nationality"].ToString();
                //this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void btnReportViewer_Click(object sender, EventArgs e)
        {
            /*
            this.reportViewer.Show();
            
            Microsoft.Reporting.WinForms.ReportParameter[] rparams = new Microsoft.Reporting.WinForms.ReportParameter[]
               {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dtFrom.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dtTo.Value.Date.ToShortDateString()),
                new Microsoft.Reporting.WinForms.ReportParameter("appDate", txtAppDate.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("fromTime", txtFromTime.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("toTime", txtToTime.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("patientName", txtPatientName.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("doctorName", txtDoctorName.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("age", txtAge.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("gender", txtGender.Text)
               };
            reportViewer.LocalReport.SetParameters(rparams);
            this.reportViewer.RefreshReport();
            */
        
        }

        private void frmRptSickLeave_Shown(object sender, EventArgs e)
        {

            DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
            if (dtOpt.Rows.Count > 0)
                lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
                    printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;

                    int top = 100; int bottom = 100;
                    DataTable dtOpt = opt.GetOptionFromName("PRINT_LETTERHEAD_MARGIN_TOP");
                    if (dtOpt.Rows.Count > 0)
                        top = Int32.Parse(dtOpt.Rows[0]["op_value"].ToString());
                    dtOpt = opt.GetOptionFromName("PRINT_LETTERHEAD_MARGIN_BOTTOM");
                    if (dtOpt.Rows.Count > 0)
                        bottom = Int32.Parse(dtOpt.Rows[0]["op_value"].ToString());
                    printDialog1.PrinterSettings.DefaultPageSettings.Margins.Top = top;
                    printDialog1.PrinterSettings.DefaultPageSettings.Margins.Bottom = bottom;
                    printDocument1.DefaultPageSettings.Margins.Top = top;
                    printDocument1.DefaultPageSettings.Margins.Bottom = bottom;

                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        HideControls();
                        PrinterSettings values = new PrinterSettings();
                        printDialog1.Document = printDocument1;
                        printDocument1.Print();
                        ShowControls();
                    }
                    printDocument1.Dispose();
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void HideControls()
        {
            try
            {
                lblSickDetails.Text = txtSickDetails.Text;
                txtSickDetails.Hide();
                lblSickDetails.Show();

                lblFrom.Text = dtFrom.Value.ToString("dd MMMM yyyy");
                lblTo.Text = dtTo.Value.ToString("dd MMMM yyyy");
                dtFrom.Hide();
                lblFrom.Show();
                dtTo.Hide();
                lblTo.Show();

                lblFromTime.Text = txtFromTime.Text;
                //lblToTime.Text = txtToTime.Text;
                lblFromTime.Show();
                txtFromTime.Hide();
                //lblToTime.Show();
                //txtToTime.Hide();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowControls()
        {
            try
            {
                lblSickDetails.Text = "";
                txtSickDetails.Show();
                lblSickDetails.Hide();

                lblFrom.Text = "";
                lblTo.Text = "";
                dtFrom.Show();
                lblFrom.Hide();
                dtTo.Show();
                lblTo.Hide();

                lblFromTime.Text = "";
                //lblToTime.Text = "";
                lblFromTime.Hide();
                txtFromTime.Show();
                //lblToTime.Hide();
                //txtToTime.Show();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void ShowStatus(int success, string msg)
        {
            /*
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
            */
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
                panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFromTime_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFromTime.Text.Trim()))
                {

                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtFromTime.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtFromTime, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtFromTime, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtSickDetails_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSickDetails.Text.Trim()))
                {

                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        txtFromTime.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(txtSickDetails, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtSickDetails, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

   

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            findDateDiff();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            findDateDiff();
        }

        private void findDateDiff()
        {
            try
            {
                DateTime tDate1 = dtFrom.Value;
                DateTime tDate2 = dtTo.Value;
                TimeSpan tspan = tDate2 - tDate1;
                txtDays.Text = tspan.Days.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }
    }
}
