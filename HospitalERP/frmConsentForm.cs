using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class frmConsentForm : Form
    {
        public int doctor_id = 0;
        public int appoint_id = 0;
        public int patient_id = 0;
        private string strMySig = "";
        ConsultationDetails objCD = new ConsultationDetails();
        Appointments appt = new Appointments();
        OptionVals opt = new OptionVals();
        public frmConsentForm()
        {
            InitializeComponent();
        }

        public frmConsentForm(int doc_id,int app_id,int pat_id)
        {
            InitializeComponent();
            doctor_id = doc_id;
            appoint_id = app_id;
            patient_id = pat_id;
        }


        private void cmdSign_Click(object sender, EventArgs e)
        {
            try
            {
                //sigPlusNET1.SetTabletState(1);
                //MessageBox.Show("sign clicked");
                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        

        private void cmdClear_Click(object sender, EventArgs e)
        {
            try
            {
                //sigPlusNET1.ClearTablet();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
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
                lblDoB.Text = Utils.FormatDateShort(dt.Rows[0]["dob"].ToString());
                lblAge.Text = dt.Rows[0]["age"].ToString();
                lblMobileNo.Text = dt.Rows[0]["phone"].ToString();
                lblNationality.Text = dt.Rows[0]["nationality"].ToString();
                //lblTreatmentDetails.Text = dt.Rows[0]["history"].ToString();
                //txtAllergies.Text = dt.Rows[0]["allergies"].ToString();
                lblTreatmentDetails.Text = dt.Rows[0]["notes"].ToString();
                //txtDoctor.Text = Utils.FormatDoctorName(dt.Rows[0]["doctor_name"].ToString());
                //txtDoctorID.Text = dt.Rows[0]["doctor_id"].ToString();                
                lblAddress.Text = Utils.FormatAddress(dt.Rows[0]["address"].ToString(), dt.Rows[0]["city"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["zip"].ToString());
                strMySig = dt.Rows[0]["signature"].ToString();

                //sigPlusNET1.SetSigString(strMySig);
                if (dt.Rows[0]["consent_date"].ToString() != "")
                    lblDate.Text = Utils.FormatDateShort(dt.Rows[0]["consent_date"].ToString());
                else
                    lblDate.Text = Utils.FormatDateShort(DateTime.Today.ToString());
                txtOtherDetails.Text = dt.Rows[0]["consent_details"].ToString();
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
                //strMySig = sigPlusNET1.GetSigString();
                rtn = appt.editAppointmentSignature(appoint_id, strMySig, txtOtherDetails.Text.Trim(), Convert.ToDateTime(lblDate.Text));

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rtn = -1;
            try
            {
               
                //strMySig = sigPlusNET1.GetSigString();
                rtn = appt.editAppointmentSignature(appoint_id, strMySig, txtOtherDetails.Text.Trim(), Convert.ToDateTime(lblDate.Text));
                if(rtn>0)
                    MessageBox.Show("Signature saved successfully!","Information", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Error in saving signature!", "Information", MessageBoxButtons.OK);
                //sigPlusNET1.SetTabletState(0);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //sigPlusNET1.SetTabletState(0);
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
                cmdSign.Visible = false;
                cmdClear.Visible = false;
                //lblOther.Visible = false;
                txtOtherDetails.BorderStyle = BorderStyle.None;

                Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
                panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
                //if (chkLetterHead.Checked == true)
                //  lblClinic.Visible = true;

                cmdSign.Visible = true;
                cmdClear.Visible = true;
                //lblOther.Visible = true;
                txtOtherDetails.BorderStyle = BorderStyle.FixedSingle;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
