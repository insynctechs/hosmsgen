using System;
using System.Windows.Forms;
using HospitalERP.Procedures;
using HospitalERP.Helpers;
using System.Data;

namespace HospitalERP
{
    public partial class frmReferToDoctor : Form
    {
        int doctor_id;
        int appointment_id;
        int patient_id;

        Bill bill = new Bill();
        DataTable dtPat;
        DataTable dtBill;

        private bool errorfocus = false;
        ConsultationDetails CD = new ConsultationDetails();
        Appointments app = new Appointments();
        public frmReferToDoctor()
        {
            InitializeComponent();
        }

        public frmReferToDoctor(int doc_id, int app_id, int pat_id)
        {
            InitializeComponent();
            doctor_id = doc_id;
            appointment_id = app_id;
            patient_id = pat_id;
        }

        private void frmReferToDoctor_Shown(object sender, EventArgs e)
        {
            //we need to pick all active doctors other than referring doctor
            cmbDoctor.DataSource = CD.DocCombo(doctor_id);
            cmbDoctor.ValueMember = "id";
            cmbDoctor.DisplayMember = "name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Double bill_total=0;
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    int ret = app.ReferAppointment(patient_id, Int32.Parse(cmbDoctor.SelectedValue.ToString()), Convert.ToDateTime(dtpDate.Text), Int32.Parse(Utils.ProcedureStatus["Scheduled"]),doctor_id,appointment_id);
                    if (ret >= 1)
                    {
                        /* SJ commented generating bill on 13Nov2018
                        DataTable dtBill = bill.GetAppointmentBill(appointment_id, patient_id, 3);
                        if (dtBill.Rows.Count == 0)
                        {
                            ConsultationDetails objCD = new ConsultationDetails();
                            DataTable dtProc = bill.getBillDetails(appointment_id);

                            if (dtProc == null || dtProc.Rows.Count <= 0) //no recs in billing details
                            {
                                Patients pat = new Patients();
                                DataTable dtPat = pat.getDetailedPatientRecordFromID(patient_id, appointment_id);
                                dtProc = objCD.getProceduresInvoiceFromApptID(appointment_id);
                                bill_total += Convert.ToDouble(dtPat.Rows[0]["doctor_fee"].ToString());                                          
                            }


                            foreach (DataRow row in dtProc.Rows)
                            {                               
                                bill_total += Convert.ToDouble(row["fee"].ToString());                                
                            }


                            int bill_id = bill.AddBill(appointment_id, patient_id, Convert.ToDecimal(bill_total), 3, LoggedUser.id);
                            
                        }*/
                        MessageBox.Show("Appointment scheduled successfully!");
                    }
                    else if (ret == 0)
                    {
                        MessageBox.Show("Appointment already scheduled!");
                    }
                    else
                    {
                        MessageBox.Show("Error in scheduling appointment!");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DateTime check;
                if (string.IsNullOrEmpty(dtpDate.Text))
                {
                    e.Cancel = true;
                    if (errorfocus == false)
                    {
                        dtpDate.Focus();
                        errorfocus = true;
                    }
                    errorProvider.SetError(dtpDate, "Required");
                }
                else if (Utils.DaysBetweenDates(dtpDate.Text, DateTime.Now.ToShortDateString()) > 0)
                {
                    
                    e.Cancel = true;
                    errorfocus = true;
                    dtpDate.Focus();
                    errorProvider.SetError(dtpDate, "Appointment date should be greater than or equal to current date");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(dtpDate, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }

        }

        private void cmbDoctor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (cmbDoctor.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    //cmbProcType.Focus();
                    errorProvider.SetError(cmbDoctor, "Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(cmbDoctor, null);
                }
            }
            catch (Exception ex)
            {
                CommonLogger.Info(ex.ToString());
            }
        }
    }
}
