using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
/*
//referred URLs
//https://www.topazsystems.com/sigplusnet.html
//https://www.topazsystems.com/dotnet.html
//https://www.topazsystems.com/software/download/sigplusnet.pdf
*/
namespace HospitalERP
{
    public partial class frmMedicinePrint : Form
    {
        public int doctor_id = 0;
        public int appoint_id = 0;
        public int patient_id = 0;
        Medicines objMed = new Medicines();
        ConsultationDetails objCD = new ConsultationDetails();
        Appointments appt = new Appointments();
        OptionVals opt = new OptionVals();

        public frmMedicinePrint()
        {
            InitializeComponent();
        }

        public frmMedicinePrint(int app_id)
        {
            InitializeComponent();            
            appoint_id = app_id;            
        }
        
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getConsultationDetails()
        {
            try
            {                
                DataTable dt = objCD.getRecordFromID(appoint_id);
                lblRegNo.Text = dt.Rows[0]["patient_number"].ToString();
                lblName.Text = dt.Rows[0]["patient_name"].ToString();
                lblGender.Text = Utils.Gender[dt.Rows[0]["gender"].ToString()];
                lblAge.Text = dt.Rows[0]["age"].ToString();
                lblDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());                                
                lblDate.Text = Utils.FormatDateShort(DateTime.Today.ToString());
                dgvMedicine.AutoGenerateColumns = false;
                dgvMedicine.DataSource = objMed.getMedicinesFromApptID(appoint_id);

                string med = "";
                foreach (DataGridViewRow row in dgvMedicine.Rows)
                {
                    med += row.Cells["med_name"].Value + "  " + row.Cells["med_prescription"].Value + "\r\n";

                }
                lblMedicine.Text = med;

            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int rtn = -1;
            try
            {
               
                printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
                printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;
                //MessageBox.Show(printDialog1.PrinterSettings.DefaultPageSettings.Margins.Bottom.ToString());
                if (chkLetterHead.Checked == true)
                {
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


                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void frmConsentForm_Load(object sender, EventArgs e)
        {
            getConsultationDetails();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //if (chkLetterHead.Checked == true)
                //  lblClinic.Visible = false;
                //txtOtherDetails.BorderStyle = BorderStyle.None;

                Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
                panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
                //if (chkLetterHead.Checked == true)
                //  lblClinic.Visible = true;

                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
