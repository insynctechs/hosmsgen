namespace HospitalERP
{
    partial class frmBilling
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
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.bID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBillNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPatNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBtnBill = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 123);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.dtpDate);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(157, 59);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(120, 61);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Bill Date: ";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(3, 22);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(94, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmbSearch);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(283, 59);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(224, 61);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search On";
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(3, 22);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(200, 21);
            this.cmbSearch.TabIndex = 5;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel4.Controls.Add(this.txtSearch);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(513, 59);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(170, 61);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 22, 3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 6;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel5.Controls.Add(this.chkDate);
            this.flowLayoutPanel5.Controls.Add(this.btnSearch);
            this.flowLayoutPanel5.Controls.Add(this.txtAppID);
            this.flowLayoutPanel5.Controls.Add(this.txtPatientID);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(691, 55);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(272, 65);
            this.flowLayoutPanel5.TabIndex = 2;
            // 
            // chkDate
            // 
            this.chkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.Location = new System.Drawing.Point(3, 3);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(248, 19);
            this.chkDate.TabIndex = 8;
            this.chkDate.Text = "Include Bill Date along with Field Search";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(3, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 37);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAppID
            // 
            this.txtAppID.Location = new System.Drawing.Point(125, 28);
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(20, 20);
            this.txtAppID.TabIndex = 4;
            this.txtAppID.Visible = false;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(151, 28);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(20, 20);
            this.txtPatientID.TabIndex = 4;
            this.txtPatientID.Visible = false;
            // 
            // lblHead1
            // 
            this.lblHead1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead1.AutoSize = true;
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel1.SetColumnSpan(this.lblHead1, 5);
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHead1.Location = new System.Drawing.Point(13, 10);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead1.Size = new System.Drawing.Size(982, 28);
            this.lblHead1.TabIndex = 30;
            this.lblHead1.Text = "BILL SEARCH";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bID,
            this.bPatID,
            this.bAppID,
            this.bBillNum,
            this.bDate,
            this.bPatNum,
            this.bPatName,
            this.bAmount,
            this.bPaid,
            this.bBalance,
            this.bTypeID,
            this.bStatusID,
            this.bType,
            this.bStatus,
            this.bBtnBill});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.LightCyan;
            this.dgvList.Location = new System.Drawing.Point(0, 123);
            this.dgvList.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1008, 607);
            this.dgvList.TabIndex = 13;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // bID
            // 
            this.bID.DataPropertyName = "id";
            this.bID.HeaderText = "ID";
            this.bID.Name = "bID";
            this.bID.ReadOnly = true;
            this.bID.Visible = false;
            // 
            // bPatID
            // 
            this.bPatID.DataPropertyName = "patient_id";
            this.bPatID.HeaderText = "Patient ID";
            this.bPatID.Name = "bPatID";
            this.bPatID.ReadOnly = true;
            this.bPatID.Visible = false;
            // 
            // bAppID
            // 
            this.bAppID.DataPropertyName = "appointment_id";
            this.bAppID.HeaderText = "Appointment ID";
            this.bAppID.Name = "bAppID";
            this.bAppID.ReadOnly = true;
            this.bAppID.Visible = false;
            // 
            // bBillNum
            // 
            this.bBillNum.DataPropertyName = "bill_number";
            this.bBillNum.HeaderText = "Bill Number";
            this.bBillNum.Name = "bBillNum";
            this.bBillNum.ReadOnly = true;
            // 
            // bDate
            // 
            this.bDate.DataPropertyName = "bill_date";
            this.bDate.HeaderText = "Date";
            this.bDate.Name = "bDate";
            this.bDate.ReadOnly = true;
            // 
            // bPatNum
            // 
            this.bPatNum.DataPropertyName = "patient_number";
            this.bPatNum.HeaderText = "Patient Number";
            this.bPatNum.Name = "bPatNum";
            this.bPatNum.ReadOnly = true;
            // 
            // bPatName
            // 
            this.bPatName.DataPropertyName = "patient_name";
            this.bPatName.HeaderText = "Patient Name";
            this.bPatName.Name = "bPatName";
            this.bPatName.ReadOnly = true;
            // 
            // bAmount
            // 
            this.bAmount.DataPropertyName = "bill_amount";
            this.bAmount.HeaderText = "Bill Amount";
            this.bAmount.Name = "bAmount";
            this.bAmount.ReadOnly = true;
            // 
            // bPaid
            // 
            this.bPaid.DataPropertyName = "bill_paid";
            this.bPaid.HeaderText = "Bill Paid";
            this.bPaid.Name = "bPaid";
            this.bPaid.ReadOnly = true;
            // 
            // bBalance
            // 
            this.bBalance.DataPropertyName = "bill_balance";
            this.bBalance.HeaderText = "Balance";
            this.bBalance.Name = "bBalance";
            this.bBalance.ReadOnly = true;
            // 
            // bTypeID
            // 
            this.bTypeID.DataPropertyName = "bill_type";
            this.bTypeID.HeaderText = "Type ID";
            this.bTypeID.Name = "bTypeID";
            this.bTypeID.ReadOnly = true;
            this.bTypeID.Visible = false;
            // 
            // bStatusID
            // 
            this.bStatusID.DataPropertyName = "bill_status";
            this.bStatusID.HeaderText = "Status ID";
            this.bStatusID.Name = "bStatusID";
            this.bStatusID.ReadOnly = true;
            this.bStatusID.Visible = false;
            // 
            // bType
            // 
            this.bType.DataPropertyName = "bill_type_name";
            this.bType.HeaderText = "Type";
            this.bType.Name = "bType";
            this.bType.ReadOnly = true;
            // 
            // bStatus
            // 
            this.bStatus.DataPropertyName = "bill_status_name";
            this.bStatus.HeaderText = "Status";
            this.bStatus.Name = "bStatus";
            this.bStatus.ReadOnly = true;
            // 
            // bBtnBill
            // 
            this.bBtnBill.HeaderText = "";
            this.bBtnBill.Name = "bBtnBill";
            this.bBtnBill.ReadOnly = true;
            this.bBtnBill.Text = "Open";
            this.bBtnBill.UseColumnTextForButtonValue = true;
            // 
            // frmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBilling";
            this.Text = "Bills";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBilling_FormClosed);
            this.Load += new System.EventHandler(this.frmBilling_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAppID;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bBillNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPatNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bType;
        private System.Windows.Forms.DataGridViewTextBoxColumn bStatus;
        private System.Windows.Forms.DataGridViewButtonColumn bBtnBill;
    }
}