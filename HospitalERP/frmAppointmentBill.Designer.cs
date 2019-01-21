namespace HospitalERP
{
    partial class frmAppointmentBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.btnListBills = new System.Windows.Forms.Button();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDob = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMeetDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDues = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.bID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBillNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCreatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bBtnBill = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel15.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel15, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel9, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 243);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel10.Controls.Add(this.label7);
            this.flowLayoutPanel10.Controls.Add(this.cmbBillType);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(64, 189);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(290, 41);
            this.flowLayoutPanel10.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Choose Bill Type";
            // 
            // cmbBillType
            // 
            this.cmbBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Location = new System.Drawing.Point(119, 3);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(138, 26);
            this.cmbBillType.TabIndex = 1;
            // 
            // lblHead1
            // 
            this.lblHead1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead1.AutoSize = true;
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel1.SetColumnSpan(this.lblHead1, 3);
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHead1.Location = new System.Drawing.Point(18, 10);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblHead1.Size = new System.Drawing.Size(972, 28);
            this.lblHead1.TabIndex = 32;
            this.lblHead1.Text = "PATIENT DETAILS";
            this.lblHead1.UseWaitCursor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtPatNum);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtPatName);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtPhone);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.txtAddress);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 52);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 129);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Number : ";
            // 
            // txtPatNum
            // 
            this.txtPatNum.BackColor = System.Drawing.Color.White;
            this.txtPatNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel1.SetFlowBreak(this.txtPatNum, true);
            this.txtPatNum.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatNum.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtPatNum.Location = new System.Drawing.Point(129, 3);
            this.txtPatNum.Name = "txtPatNum";
            this.txtPatNum.ReadOnly = true;
            this.txtPatNum.Size = new System.Drawing.Size(110, 18);
            this.txtPatNum.TabIndex = 1;
            this.txtPatNum.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patient Name      : ";
            // 
            // txtPatName
            // 
            this.txtPatName.BackColor = System.Drawing.Color.White;
            this.txtPatName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel1.SetFlowBreak(this.txtPatName, true);
            this.txtPatName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtPatName.Location = new System.Drawing.Point(129, 27);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.ReadOnly = true;
            this.txtPatName.Size = new System.Drawing.Size(201, 18);
            this.txtPatName.TabIndex = 1;
            this.txtPatName.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact Phone    :";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtPhone.Location = new System.Drawing.Point(129, 51);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(150, 18);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Address                 : ";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtAddress.Location = new System.Drawing.Point(129, 75);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(203, 50);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TabStop = false;
            // 
            // flowLayoutPanel15
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel15, 2);
            this.flowLayoutPanel15.Controls.Add(this.btnGenerateBill);
            this.flowLayoutPanel15.Controls.Add(this.btnListBills);
            this.flowLayoutPanel15.Controls.Add(this.txtAppID);
            this.flowLayoutPanel15.Location = new System.Drawing.Point(360, 187);
            this.flowLayoutPanel15.Name = "flowLayoutPanel15";
            this.flowLayoutPanel15.Size = new System.Drawing.Size(492, 43);
            this.flowLayoutPanel15.TabIndex = 35;
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnGenerateBill.Enabled = false;
            this.btnGenerateBill.ForeColor = System.Drawing.Color.White;
            this.btnGenerateBill.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGenerateBill.Location = new System.Drawing.Point(3, 3);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(200, 36);
            this.btnGenerateBill.TabIndex = 2;
            this.btnGenerateBill.Text = "GENERATE BILL";
            this.btnGenerateBill.UseVisualStyleBackColor = false;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // btnListBills
            // 
            this.btnListBills.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnListBills.ForeColor = System.Drawing.Color.White;
            this.btnListBills.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListBills.Location = new System.Drawing.Point(209, 3);
            this.btnListBills.Name = "btnListBills";
            this.btnListBills.Size = new System.Drawing.Size(197, 36);
            this.btnListBills.TabIndex = 3;
            this.btnListBills.Text = "REFRESH BILLS";
            this.btnListBills.UseVisualStyleBackColor = false;
            this.btnListBills.Click += new System.EventHandler(this.btnListBills_Click);
            // 
            // txtAppID
            // 
            this.txtAppID.Location = new System.Drawing.Point(412, 3);
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(51, 25);
            this.txtAppID.TabIndex = 36;
            this.txtAppID.Visible = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.txtGender);
            this.flowLayoutPanel4.Controls.Add(this.label8);
            this.flowLayoutPanel4.Controls.Add(this.txtDob);
            this.flowLayoutPanel4.Controls.Add(this.label12);
            this.flowLayoutPanel4.Controls.Add(this.txtAge);
            this.flowLayoutPanel4.Controls.Add(this.label5);
            this.flowLayoutPanel4.Controls.Add(this.txtNationality);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(360, 52);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(263, 122);
            this.flowLayoutPanel4.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gender           : ";
            // 
            // txtGender
            // 
            this.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel4.SetFlowBreak(this.txtGender, true);
            this.txtGender.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtGender.Location = new System.Drawing.Point(102, 3);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(119, 18);
            this.txtGender.TabIndex = 1;
            this.txtGender.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Date of Birth : ";
            // 
            // txtDob
            // 
            this.txtDob.BackColor = System.Drawing.SystemColors.Window;
            this.txtDob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel4.SetFlowBreak(this.txtDob, true);
            this.txtDob.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtDob.Location = new System.Drawing.Point(105, 27);
            this.txtDob.Name = "txtDob";
            this.txtDob.ReadOnly = true;
            this.txtDob.Size = new System.Drawing.Size(81, 18);
            this.txtDob.TabIndex = 1;
            this.txtDob.TabStop = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "Age                   : ";
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.Window;
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel4.SetFlowBreak(this.txtAge, true);
            this.txtAge.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtAge.Location = new System.Drawing.Point(102, 51);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(40, 18);
            this.txtAge.TabIndex = 1;
            this.txtAge.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nationality    : ";
            // 
            // txtNationality
            // 
            this.txtNationality.BackColor = System.Drawing.Color.White;
            this.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNationality.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtNationality.Location = new System.Drawing.Point(102, 75);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.ReadOnly = true;
            this.txtNationality.Size = new System.Drawing.Size(152, 18);
            this.txtNationality.TabIndex = 1;
            this.txtNationality.TabStop = false;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.label11);
            this.flowLayoutPanel9.Controls.Add(this.txtDoctor);
            this.flowLayoutPanel9.Controls.Add(this.label9);
            this.flowLayoutPanel9.Controls.Add(this.txtMeetDate);
            this.flowLayoutPanel9.Controls.Add(this.label6);
            this.flowLayoutPanel9.Controls.Add(this.txtDues);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(653, 52);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(310, 122);
            this.flowLayoutPanel9.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Doctor           : ";
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.Color.White;
            this.txtDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel9.SetFlowBreak(this.txtDoctor, true);
            this.txtDoctor.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtDoctor.Location = new System.Drawing.Point(99, 3);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(188, 18);
            this.txtDoctor.TabIndex = 1;
            this.txtDoctor.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Visit Date     : ";
            // 
            // txtMeetDate
            // 
            this.txtMeetDate.BackColor = System.Drawing.Color.White;
            this.txtMeetDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel9.SetFlowBreak(this.txtMeetDate, true);
            this.txtMeetDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtMeetDate.Location = new System.Drawing.Point(99, 27);
            this.txtMeetDate.Name = "txtMeetDate";
            this.txtMeetDate.ReadOnly = true;
            this.txtMeetDate.Size = new System.Drawing.Size(100, 18);
            this.txtMeetDate.TabIndex = 1;
            this.txtMeetDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Billed Dues  : ";
            // 
            // txtDues
            // 
            this.txtDues.BackColor = System.Drawing.Color.White;
            this.txtDues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowLayoutPanel9.SetFlowBreak(this.txtDues, true);
            this.txtDues.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDues.ForeColor = System.Drawing.Color.Red;
            this.txtDues.Location = new System.Drawing.Point(99, 51);
            this.txtDues.Name = "txtDues";
            this.txtDues.ReadOnly = true;
            this.txtDues.Size = new System.Drawing.Size(100, 18);
            this.txtDues.TabIndex = 1;
            this.txtDues.TabStop = false;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bID,
            this.bAppID,
            this.bBillNum,
            this.bDate,
            this.bPatID,
            this.bAmount,
            this.bPaid,
            this.bBalance,
            this.bNotes,
            this.bStatusID,
            this.bTypeID,
            this.bCreatorID,
            this.bType,
            this.bStatus,
            this.bBtnBill});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.LightCyan;
            this.dgvList.Location = new System.Drawing.Point(0, 243);
            this.dgvList.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1008, 507);
            this.dgvList.TabIndex = 12;
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
            // bPatID
            // 
            this.bPatID.DataPropertyName = "patient_id";
            this.bPatID.HeaderText = "Patient ID";
            this.bPatID.Name = "bPatID";
            this.bPatID.ReadOnly = true;
            this.bPatID.Visible = false;
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
            // bNotes
            // 
            this.bNotes.DataPropertyName = "notes";
            this.bNotes.HeaderText = "Notes";
            this.bNotes.Name = "bNotes";
            this.bNotes.ReadOnly = true;
            this.bNotes.Visible = false;
            // 
            // bStatusID
            // 
            this.bStatusID.DataPropertyName = "bill_status";
            this.bStatusID.HeaderText = "Status ID";
            this.bStatusID.Name = "bStatusID";
            this.bStatusID.ReadOnly = true;
            this.bStatusID.Visible = false;
            // 
            // bTypeID
            // 
            this.bTypeID.DataPropertyName = "bill_type";
            this.bTypeID.HeaderText = "Type ID";
            this.bTypeID.Name = "bTypeID";
            this.bTypeID.ReadOnly = true;
            this.bTypeID.Visible = false;
            // 
            // bCreatorID
            // 
            this.bCreatorID.DataPropertyName = "bill_created_userid";
            this.bCreatorID.HeaderText = "Done By";
            this.bCreatorID.Name = "bCreatorID";
            this.bCreatorID.ReadOnly = true;
            this.bCreatorID.Visible = false;
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
            // frmAppointmentBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 750);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAppointmentBill";
            this.Text = "Appointment\'s Bills";
            this.Activated += new System.EventHandler(this.frmAppointmentBill_Activated);
            this.Load += new System.EventHandler(this.frmAppointmentBill_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel15.ResumeLayout(false);
            this.flowLayoutPanel15.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDues;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel15;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.Button btnListBills;
        private System.Windows.Forms.TextBox txtAppID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn bID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bBillNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn bNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn bStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bCreatorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bType;
        private System.Windows.Forms.DataGridViewTextBoxColumn bStatus;
        private System.Windows.Forms.DataGridViewButtonColumn bBtnBill;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMeetDate;
    }
}