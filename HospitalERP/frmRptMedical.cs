using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;

namespace HospitalERP
{
    public partial class frmRptMedical : Form
    {
      
        ConsultationDetails objCD = new ConsultationDetails();
        private static int appointment_id = 0;
        OptionVals opt = new OptionVals();

        public frmRptMedical()
        {
            InitializeComponent();
        }
        public frmRptMedical(int aptid)
        {
            InitializeComponent();
            appointment_id = aptid;
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
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
                    PrinterSettings values = new PrinterSettings();
                    printDialog1.Document = printDocument1;
                    printDocument1.Print();

                }
                printDocument1.Dispose();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmRptMedical_Shown(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            try
            {
                DataTable dt = objCD.getMedicalReportFromID(appointment_id);
                DataTable dtProc = objCD.getProceduresFromApptID(appointment_id);

                lblName.Text = dt.Rows[0]["patient_name"].ToString();
                lblRegNo.Text = dt.Rows[0]["patient_number"].ToString();
                lblAge.Text = dt.Rows[0]["age"].ToString();
                lblGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                lblDate.Text = Utils.FormatDateShort(dt.Rows[0]["appointment_date"].ToString());
                lblAddress.Text = dt.Rows[0]["address"].ToString();
                lblNationality.Text = dt.Rows[0]["nationality"].ToString();
                lblDescription.Text = dt.Rows[0]["discharge_summary"].ToString();
                lblDoctor.Text = dt.Rows[0]["doctor_name"].ToString();
                string proc = "";
                for (int r = 0; r < dtProc.Rows.Count; r++)
                {
                    if (r > 0)
                        proc += ", ";

                    proc += dtProc.Rows[r]["name"].ToString();
                }
                lblProcedures.Text = proc;
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                if (dtOpt.Rows.Count > 0)
                    lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
    }
}
