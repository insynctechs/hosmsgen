namespace HospitalERP
{
    partial class frmConsultations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoc = new System.Windows.Forms.ComboBox();
            this.lblStatusCombo = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.dgvApp = new System.Windows.Forms.DataGridView();
            this.AID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APrevDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABtnDues = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnBill = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnHistory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 128);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblHead1
            // 
            this.lblHead1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead1.AutoSize = true;
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHead1.Location = new System.Drawing.Point(3, 10);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead1.Size = new System.Drawing.Size(1002, 28);
            this.lblHead1.TabIndex = 30;
            this.lblHead1.Text = "SCHEDULED APPOINTMENTS";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.dtpAppDate);
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.cmbDoc);
            this.flowLayoutPanel3.Controls.Add(this.lblStatusCombo);
            this.flowLayoutPanel3.Controls.Add(this.cmbStatus);
            this.flowLayoutPanel3.Controls.Add(this.btnList);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(75, 63);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(858, 56);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date: ";
            // 
            // dtpAppDate
            // 
            this.dtpAppDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppDate.Location = new System.Drawing.Point(58, 3);
            this.dtpAppDate.Name = "dtpAppDate";
            this.dtpAppDate.Size = new System.Drawing.Size(94, 26);
            this.dtpAppDate.TabIndex = 1;
            this.dtpAppDate.ValueChanged += new System.EventHandler(this.dtpAppDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(158, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor: ";
            // 
            // cmbDoc
            // 
            this.cmbDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoc.FormattingEnabled = true;
            this.cmbDoc.Location = new System.Drawing.Point(228, 3);
            this.cmbDoc.Name = "cmbDoc";
            this.cmbDoc.Size = new System.Drawing.Size(200, 26);
            this.cmbDoc.TabIndex = 53;
            this.cmbDoc.SelectedIndexChanged += new System.EventHandler(this.cmbDoc_SelectedIndexChanged);
            // 
            // lblStatusCombo
            // 
            this.lblStatusCombo.AutoSize = true;
            this.lblStatusCombo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStatusCombo.Location = new System.Drawing.Point(434, 0);
            this.lblStatusCombo.Name = "lblStatusCombo";
            this.lblStatusCombo.Size = new System.Drawing.Size(60, 19);
            this.lblStatusCombo.TabIndex = 2;
            this.lblStatusCombo.Text = "Status: ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(500, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 26);
            this.cmbStatus.TabIndex = 53;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnList.Location = new System.Drawing.Point(706, 2);
            this.btnList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(140, 29);
            this.btnList.TabIndex = 54;
            this.btnList.Text = "REFRESH";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // dgvApp
            // 
            this.dgvApp.AllowUserToAddRows = false;
            this.dgvApp.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvApp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvApp.BackgroundColor = System.Drawing.Color.White;
            this.dgvApp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvApp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AID,
            this.APatID,
            this.ADocID,
            this.APatNum,
            this.APatName,
            this.ADocName,
            this.AToken,
            this.APrevDate,
            this.ADues,
            this.AStatus,
            this.ABtnDues,
            this.ABtnBill,
            this.ABtnDetails,
            this.ABtnHistory});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApp.GridColor = System.Drawing.Color.LightCyan;
            this.dgvApp.Location = new System.Drawing.Point(0, 128);
            this.dgvApp.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.dgvApp.MultiSelect = false;
            this.dgvApp.Name = "dgvApp";
            this.dgvApp.ReadOnly = true;
            this.dgvApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApp.Size = new System.Drawing.Size(1008, 602);
            this.dgvApp.TabIndex = 12;
            this.dgvApp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApp_CellContentClick);
            this.dgvApp.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApp_RowHeaderMouseClick);
            // 
            // AID
            // 
            this.AID.DataPropertyName = "id";
            this.AID.HeaderText = "ID";
            this.AID.Name = "AID";
            this.AID.ReadOnly = true;
            this.AID.Visible = false;
            // 
            // APatID
            // 
            this.APatID.DataPropertyName = "patient_id";
            this.APatID.HeaderText = "Patient ID";
            this.APatID.Name = "APatID";
            this.APatID.ReadOnly = true;
            this.APatID.Visible = false;
            // 
            // ADocID
            // 
            this.ADocID.DataPropertyName = "doctor_id";
            this.ADocID.HeaderText = "Doctor ID";
            this.ADocID.Name = "ADocID";
            this.ADocID.ReadOnly = true;
            this.ADocID.Visible = false;
            // 
            // APatNum
            // 
            this.APatNum.DataPropertyName = "patient_number";
            this.APatNum.HeaderText = "Patient Number";
            this.APatNum.Name = "APatNum";
            this.APatNum.ReadOnly = true;
            // 
            // APatName
            // 
            this.APatName.DataPropertyName = "patient_name";
            this.APatName.HeaderText = "Patient Name";
            this.APatName.Name = "APatName";
            this.APatName.ReadOnly = true;
            // 
            // ADocName
            // 
            this.ADocName.DataPropertyName = "doctor_name";
            this.ADocName.HeaderText = "Doctor";
            this.ADocName.Name = "ADocName";
            this.ADocName.ReadOnly = true;
            // 
            // AToken
            // 
            this.AToken.DataPropertyName = "token";
            this.AToken.HeaderText = "Token#";
            this.AToken.Name = "AToken";
            this.AToken.ReadOnly = true;
            // 
            // APrevDate
            // 
            this.APrevDate.DataPropertyName = "prev_date";
            this.APrevDate.HeaderText = "Prev. Appointment";
            this.APrevDate.Name = "APrevDate";
            this.APrevDate.ReadOnly = true;
            // 
            // ADues
            // 
            this.ADues.DataPropertyName = "dues";
            this.ADues.HeaderText = "Prev. Dues";
            this.ADues.Name = "ADues";
            this.ADues.ReadOnly = true;
            this.ADues.Visible = false;
            // 
            // AStatus
            // 
            this.AStatus.DataPropertyName = "status";
            this.AStatus.HeaderText = "Status";
            this.AStatus.Name = "AStatus";
            this.AStatus.ReadOnly = true;
            this.AStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ABtnDues
            // 
            this.ABtnDues.HeaderText = "";
            this.ABtnDues.Name = "ABtnDues";
            this.ABtnDues.ReadOnly = true;
            this.ABtnDues.Text = "Billed Dues";
            this.ABtnDues.ToolTipText = "Billed Dues";
            this.ABtnDues.UseColumnTextForButtonValue = true;
            // 
            // ABtnBill
            // 
            this.ABtnBill.HeaderText = "";
            this.ABtnBill.Name = "ABtnBill";
            this.ABtnBill.ReadOnly = true;
            this.ABtnBill.Text = "Generate Bill";
            this.ABtnBill.UseColumnTextForButtonValue = true;
            // 
            // ABtnDetails
            // 
            this.ABtnDetails.HeaderText = "";
            this.ABtnDetails.Name = "ABtnDetails";
            this.ABtnDetails.ReadOnly = true;
            this.ABtnDetails.Text = "View Details";
            this.ABtnDetails.UseColumnTextForButtonValue = true;
            // 
            // ABtnHistory
            // 
            this.ABtnHistory.HeaderText = "";
            this.ABtnHistory.Name = "ABtnHistory";
            this.ABtnHistory.ReadOnly = true;
            this.ABtnHistory.Text = "History";
            this.ABtnHistory.ToolTipText = "History";
            this.ABtnHistory.UseColumnTextForButtonValue = true;
            // 
            // frmConsultations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.dgvApp);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmConsultations";
            this.Text = "Consultations";
            this.Activated += new System.EventHandler(this.frmConsultations_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConsultations_FormClosed);
            this.Load += new System.EventHandler(this.frmConsultations_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAppDate;
        private System.Windows.Forms.Label lblStatusCombo;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridView dgvApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoc;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.DataGridViewTextBoxColumn AID;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn APrevDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADues;
        private System.Windows.Forms.DataGridViewTextBoxColumn AStatus;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnDues;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnBill;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnDetails;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnHistory;
    }
}