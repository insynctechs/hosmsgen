using System;
using System.Data;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
namespace HospitalERP
{
    public partial class frmBilling : Form
    {
        public int appointment_id=0;
        public int patient_id=0;
       
        Appointments app = new Appointments();
        Patients pat = new Patients();
        Bill bill = new Bill();

        public frmBilling()
        {
            try
            {
                InitializeComponent();
               
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        public frmBilling(int app_id, int pat_id)
        {
            try
            {
                InitializeComponent();
                appointment_id = app_id;
                patient_id = pat_id;
                
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
                dgvList.AutoGenerateColumns = false;
                PopulateSearchCombo();
                GetBills();
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }


        }

        private void PopulateSearchCombo()
        {
            try
            {
                cmbSearch.DataSource = bill.BillSearchValues();
                cmbSearch.ValueMember = "Value";
                cmbSearch.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void GetBills(int click=0)
        {
            try
            {
                DataTable dtRecords = bill.SearchBills(cmbSearch.SelectedValue.ToString(), txtSearch.Text, Convert.ToDateTime(dtpDate.Value), chkDate.Checked);
                dgvList.DataSource = dtRecords;
                if (dtRecords.Rows.Count == 0 && click == 1)
                {
                    MessageBox.Show(Utils.FormatZeroSearch());
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetBills(1);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvList.Columns[e.ColumnIndex].Name)
                {
                    case "bBtnBill":
                        if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "1")
                        {
                            frmConsultationBill frm = new frmConsultationBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "2")
                        {
                            frmProceduresBill frm = new frmProceduresBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        else if (dgvList.Rows[e.RowIndex].Cells["bTypeID"].Value.ToString() == "3")
                        {
                            frmOneTimeBill frm = new frmOneTimeBill(Int32.Parse(dgvList.Rows[e.RowIndex].Cells["bID"].Value.ToString()));
                            frm.ShowDialog();
                        }
                        GetBills();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmBilling_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.toggleChildCloseButton(this.MdiParent, 1);
            app.Dispose();
            pat.Dispose();
            bill.Dispose();
        }
    }
}
