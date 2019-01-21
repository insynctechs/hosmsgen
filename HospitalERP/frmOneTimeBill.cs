using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
using System.Text.RegularExpressions;
namespace HospitalERP
{
    public partial class frmOneTimeBill : Form
    {
        public int appointment_id = 0;
        public int patient_id = 0;
        public int bill_id = 0;
        public double bill_total = 0;
        public double bill_paid = 0;
        public double bill_paid_load = 0;
        public double bill_balance = 0;
        public DataTable dtProc;
        public int bill_status = 0;

        
        Bill bill = new Bill();
        Appointments app = new Appointments();
        Patients pat = new Patients();
        ConsultationDetails objCD = new ConsultationDetails();
        OptionVals opt = new OptionVals();
        DataTable dtPat;
        DataTable dtBill;

        public int cell_modified = 0;
        public frmOneTimeBill()
        {
            InitializeComponent();
        }

        public frmOneTimeBill(int app_id, int pat_id)
        {
            try
            {
                InitializeComponent();
                appointment_id = app_id;
                patient_id = pat_id;
                loadPatientAppInfo();
                PopulateStatusCombo();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        public frmOneTimeBill(int b_id)
        {
            try
            {
                InitializeComponent();
                bill_id = b_id;
                dtBill = bill.GetBill(bill_id);
                appointment_id = Int32.Parse(dtBill.Rows[0]["appointment_id"].ToString());
                patient_id = Int32.Parse(dtBill.Rows[0]["patient_id"].ToString());
                loadPatientAppInfo();
                PopulateStatusCombo();
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
                cmbBillStatus.DataSource = bill.GetBillStatus();
                cmbBillStatus.DisplayMember = "name";
                cmbBillStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void loadPatientAppInfo()
        {
            try
            {
                dtPat = pat.getDetailedPatientRecordFromID(patient_id, appointment_id);
                txtPatNum.Text = dtPat.Rows[0]["patient_number"].ToString();
                txtPatName.Text = dtPat.Rows[0]["patient_name"].ToString();
                string gender = dtPat.Rows[0]["gender"].ToString();
                txtGender.Text = Utils.Gender[gender].ToString();
                txtAge.Text = dtPat.Rows[0]["age"].ToString();
                txtNationality.Text = dtPat.Rows[0]["nationality"].ToString();
                txtAddress.Text = Utils.FormatAddress(dtPat.Rows[0]["address"].ToString(), dtPat.Rows[0]["city"].ToString(), dtPat.Rows[0]["state"].ToString(), dtPat.Rows[0]["zip"].ToString());
                //txtMeetDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
                txtDoctor.Text = dtPat.Rows[0]["doctor_name"].ToString();
                txtToken.Text = dtPat.Rows[0]["token"].ToString().PadLeft(3, '0');
                txtAppId.Text = dtPat.Rows[0]["appointment_id"].ToString().PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

            return;
        }
        private void dgvInv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if ((e.RowIndex == -1 || e.RowIndex == dgvInv.RowCount - 1) && e.ColumnIndex >= 0)
                {
                    //if (dgvInv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                    //{
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Black, 1))
                    {
                        System.Drawing.Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));

                        //e.Graphics.DrawRectangle(p, rect);

                    }
                    e.Handled = true;
                    dgvInv.Rows[dgvInv.Rows.Count-1].Cells[3].ReadOnly = true;
                    // }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmOneTimeBill_Load(object sender, EventArgs e)
        {
            try
            {
                dgvInv.AutoGenerateColumns = false;
                DataTable dtOpt = opt.GetOptionFromName("CLINIC_NAME");
                if (dtOpt.Rows.Count > 0)
                    lblClinic.Text = dtOpt.Rows[0]["op_value"].ToString();

                bill_total = 0;
                int k = 1;

                //displaying data to grid view
                dgvInv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                //if this appointment has bill details then get records from details table
                //else for initial loading take from appt procedures
                dtProc = bill.getBillDetails(appointment_id);
                if (dtProc == null || dtProc.Rows.Count<=0) //no recs in billing details
                {
                    dtProc = objCD.getProceduresInvoiceFromApptID(appointment_id);
                    bill_total += Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString());
                    k = 2;                  
                    dgvInv.Rows.Add(new object[] { "1", "Consultation Fees and Charges", Utils.FormatAmount(Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString())) });
                }
                

                foreach (DataRow row in dtProc.Rows)
                {
                    dgvInv.Rows.Add(new object[] { k, row["name"].ToString(), Utils.FormatAmount(Convert.ToDouble(row["fee"].ToString())) });                    
                    bill_total += Convert.ToDouble(row["fee"].ToString());
                    k++;                    
                }

                
                txtTotal.Text = Utils.FormatAmount(bill_total);

                if (bill_id == 0)
                {
                    dtBill = bill.GetAppointmentBill(appointment_id, patient_id, 3);
                    if (dtBill.Rows.Count == 0)
                    {
                        if (!(LoggedUser.id > 0))
                            LoggedUser.id = 1;
       
                        bill_id = bill.AddBill(appointment_id, patient_id, Convert.ToDecimal(bill_total), 3, LoggedUser.id);

                        
                        if (bill_id > 0)
                        {
                            dtBill = bill.GetBill(bill_id);
                        }
                        else
                        {
                            MessageBox.Show("Error in Creating Bill");
                        }
                    }
                    else
                    {
                        bill_id = Int32.Parse(dtBill.Rows[0]["id"].ToString());
                    }
                }
                if (bill_id > 0)
                {
                    txtInvNum.Text = dtBill.Rows[0]["bill_number"].ToString();
                    txtDate.Text = Convert.ToDateTime(dtPat.Rows[0]["meet_date"].ToString()).ToShortDateString();
                    bill_total = Convert.ToDouble(dtBill.Rows[0]["bill_amount"].ToString());
                    bill_paid = Convert.ToDouble(dtBill.Rows[0]["bill_paid"].ToString());
                    bill_paid_load = bill_paid;
                    txtPaid.Text = Utils.FormatAmount(bill_paid);
                    bill_balance = Convert.ToDouble(dtBill.Rows[0]["bill_balance"].ToString());
                    txtBalance.Text = Utils.FormatAmount(bill_balance);
                    lblTime.Text = dtBill.Rows[0]["bill_date"].ToString();
                    int creator = Int32.Parse(dtBill.Rows[0]["bill_created_userid"].ToString());
                    //txtPrevDues.Text = dtBill.Rows[0]["bill_due"].ToString();
                    if (dtBill.Rows[0]["bill_due"].ToString() != "")
                    {
                        txtPrevDues.Text = Utils.FormatAmount(Convert.ToDouble(dtBill.Rows[0]["bill_due"].ToString()));
                        txtTotal.Text = Utils.FormatAmount(bill_total + Convert.ToDouble(txtPrevDues.Text));
                    }
                    else
                    {
                        txtPrevDues.Text = "0.000";
                        txtTotal.Text = Utils.FormatAmount(bill_total);
                    }
                        DataTable dtUser = bill.GetBillCreatedUser(creator);
                    if (dtUser != null)
                        txtLoggedUser.Text = dtUser.Rows[0]["staff_name"].ToString();
                    cmbBillStatus.SelectedValue = dtBill.Rows[0]["bill_status"].ToString();
                    bill_status = Int32.Parse(dtBill.Rows[0]["bill_status"].ToString()) ;
                }

                editBillDetails();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvInv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex!=-1 )
                {
                    setTotalAmount();
                   
                }
                cell_modified = 1;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void setTotalAmount()
        {
            decimal fee_total = 0;
            try
            {
                for (int m = 0; m < dgvInv.RowCount - 1; m++)
                   fee_total += Convert.ToDecimal(dgvInv.Rows[m].Cells["Amount"].Value.ToString());
                if(txtPrevDues.Text.Trim() != "")
                    fee_total += Convert.ToDecimal(txtPrevDues.Text.ToString());
                txtTotal.Text = fee_total.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bill_total = Convert.ToDouble(txtTotal.Text);
                bill_balance = bill_total - bill_paid;
                txtBalance.Text = Utils.FormatAmount(bill_balance);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtPaid.Text, @"[^0-9\.]"))
                {
                    MessageBox.Show("Bill Paid Amount should be numeric.");
                    txtPaid.Text = "0.000";
                }
                bill_paid = Convert.ToDouble(txtPaid.Text);
                bill_balance = bill_total - bill_paid;
                if (bill_balance < 0)
                    MessageBox.Show("Bill Paid Amount should not be greater than Bill Total.", "Information", MessageBoxButtons.OK);
                else
                    txtBalance.Text = Utils.FormatAmount(bill_balance);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if((txtPaid.Text.Trim()=="" || Convert.ToDouble(txtPaid.Text) == 0.000 ) && Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 5 && Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 2) //not cancelled AND pending
                {
                    MessageBox.Show("Bill Paid Amount should be greater than 0.");
                }
                else if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) == 4 && bill_balance != 0)
                {
                    MessageBox.Show("The entire bill needs to be paid fully for 'Paid' Status");
                }
                else if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 4 && bill_balance == 0)
                {
                    MessageBox.Show("Please change the status to 'Paid'");
                }
                //else if (Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 2 && Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 3 && bill_balance != 0)
                else if (bill_balance != bill_total && Int32.Parse(cmbBillStatus.SelectedValue.ToString()) != 3 && bill_balance != 0)
                {
                    MessageBox.Show("Please change the status to 'Partial-Paid'");
                }
                else if(bill_balance<0)
                {
                    MessageBox.Show("Bill Paid should not be greater than Bill Total");
                }
                else
                {
                    if (!(LoggedUser.id > 0))
                        LoggedUser.id = 1;
                    int res = bill.editBill(bill_id, Convert.ToDecimal(bill_total), Convert.ToDecimal(bill_paid), Convert.ToDecimal(bill_balance), Int32.Parse(cmbBillStatus.SelectedValue.ToString()), LoggedUser.id);
                    if (res > 0)
                    {
                        bill_paid_load = bill_paid;
                        bill_status = Int32.Parse(cmbBillStatus.SelectedValue.ToString());
                        MessageBox.Show("Bill Saved Succesfully", "Information", MessageBoxButtons.OK);
                        enableOrDisableButtons();
                    }

                    if (cell_modified == 1)                     
                    {
                        //SJ commented. 
                        //edit in patient_procedures table
                        //res = objCD.editProceduresFees(dtProc);

                        //edit bill details table
                        editBillDetails();
                        cell_modified = 0;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void editBillDetails()
        {
            try
            {
                //edit bill details table
                DataTable dtRec = new DataTable();
                dtRec.Columns.Add("appointment_id", typeof(int));
                dtRec.Columns.Add("item_no", typeof(int));
                dtRec.Columns.Add("item_name", typeof(string));
                dtRec.Columns.Add("item_amount", typeof(float));
                dtRec.Columns.Add("billing_id", typeof(int));
                foreach (DataGridViewRow row in dgvInv.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        dtRec.Rows.Add(appointment_id, Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), Convert.ToDouble(row.Cells[2].Value.ToString()), bill_id);

                }
                int res = bill.UpdateBillDetails(dtRec, appointment_id);
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cell_modified == 1 || bill_paid_load != bill_paid) && btnSave.Enabled==true)
                {
                    MessageBox.Show("Please save the bill before printing.");
                }
                else
                {
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    dgvInv.Columns["btnDel"].Visible = false;
                    dgvInv.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    txtPaid.BorderStyle = BorderStyle.None;
                    printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
                    printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A5;
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
                        // Create a new instance of Margins with 1-inch margins.
                        //Margins margins = new Margins(300, 300, 300, 300);
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
                    dgvInv.Columns["btnDel"].Visible = true;
                    dgvInv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                    txtPaid.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cell_modified == 1 || bill_paid_load != bill_paid || bill_status == 1) && btnSave.Enabled == true)
                {
                    MessageBox.Show("Please save the bill before closing.");

                }
                else
                    this.Close();
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
                if (chkLetterHead.Checked == true)
                    lblClinic.Visible = false;
                Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height, panelContent.CreateGraphics());
                panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));
                RectangleF bounds = e.PageSettings.PrintableArea;
                float factor = ((float)bmp.Height / (float)bmp.Width);
                e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
                if (chkLetterHead.Checked == true)
                    lblClinic.Visible = true;
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void dgvInv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  dgvInv.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            //if (!headerText.Equals("Amount")) return;
            int cnt = dgvInv.Rows.Count;
            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()) && e.RowIndex!=cnt-1)
            {
                MessageBox.Show( "Please input value","Information",MessageBoxButtons.OK);
                e.Cancel = true;
            }

            if (headerText== "Item Amount" && Regex.IsMatch(e.FormattedValue.ToString(), @"[^0-9\.]"))
            {
                dgvInv.EditingControl.Text = "0.000";
                MessageBox.Show("Amount should be numeric.");
                
                

            }
        }

        private void dgvInv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvInv.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void cmbBillStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBillStatus.SelectedValue.ToString() == "4")
            {
                foreach (DataGridViewRow row in dgvInv.Rows)
                {
                    row.Cells[2].ReadOnly = true;
                    row.Cells[1].ReadOnly = true;
                    row.Cells[0].ReadOnly = true;
                }
            }
            else 
            {
                foreach (DataGridViewRow row in dgvInv.Rows)
                {
                    row.Cells[0].ReadOnly = false;
                    row.Cells[1].ReadOnly = false;
                    row.Cells[2].ReadOnly = false;                    
                }
            }
        }

        private void dgvInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                 if (dgvInv.Columns[e.ColumnIndex].Name == "btnDel")
                 { 
                    if (dgvInv.Rows.Count > 2)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Delete Bill Item", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            dgvInv.Rows.RemoveAt(e.RowIndex);
                            setTotalAmount();
                            resetSerialNumbers(e.RowIndex);
                            editBillDetails();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                       
                        
                        //MessageBox.Show("Record Deleted ", "Information", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete this item. Bill needs atleast one item.", "Information", MessageBoxButtons.OK);
                    }
                }
               


            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void frmOneTimeBill_Shown(object sender, EventArgs e)
        {
            enableOrDisableButtons();
            cell_modified = 0;
        }

        private void enableOrDisableButtons()
        {
            try
            {
                if (dtBill.Rows[0]["bill_status"].ToString() == "4" || dtBill.Rows[0]["bill_status"].ToString() == "5")
                {
                    // if bill status is paid/cancelled
                    txtPaid.ReadOnly = true;
                    dgvInv.ReadOnly = true;
                    btnSave.Enabled = false;
                    dgvInv.Columns["btnDel"].Visible = false;
                    txtPaid.Enabled = false;
                }
                else
                {
                    txtPaid.ReadOnly = false;
                    dgvInv.ReadOnly = false;
                    btnSave.Enabled = true;
                    dgvInv.Columns["btnDel"].Visible = true;
                    txtPaid.Enabled = true;
                }
                //SJ COMMENTED FOR TEMPORARY - 15 NOV 2018
                
                int ret = app.GetBillLockStatus(appointment_id);
                if (ret > 0)
                {
                    btnSave.Enabled = false;
                    
                }
                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void dgvInv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = dgvInv.RowCount;
        }

        private void resetSerialNumbers(int index)
        {
            for(int i=index; i< dgvInv.Rows.Count-1; i++)
            {
                dgvInv.Rows[i].Cells[0].Value = (i+1).ToString();
            }
        }

        private void frmOneTimeBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            bill.Dispose();
            objCD.Dispose();
            opt.Dispose();
            pat.Dispose();
            opt.Dispose();
            
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmOneTimeBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((cell_modified == 1 || bill_paid_load != bill_paid || bill_status==1 ) && btnSave.Enabled == true)
                {
                    MessageBox.Show("Please save the bill before closing.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
