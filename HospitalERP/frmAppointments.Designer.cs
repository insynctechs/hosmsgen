namespace HospitalERP
{
    partial class frmAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dgvApp = new System.Windows.Forms.DataGridView();
            this.AID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APrevDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABtnDues = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnStatus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnBill = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ADues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDoc = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatNum = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnList = new System.Windows.Forms.Button();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVisitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PBtnHistory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatusCombo = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.dgvPatient);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvApp);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToDeleteRows = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPatient.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PID,
            this.PNum,
            this.Pname,
            this.PGender,
            this.PAge,
            this.PAddress,
            this.PPhone,
            this.PDoctor,
            this.PVisitDate,
            this.PBtnSelect,
            this.PBtnHistory});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvPatient, "dgvPatient");
            this.dgvPatient.GridColor = System.Drawing.Color.LightCyan;
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.ShowEditingIcon = false;
            this.dgvPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellContentClick);
            this.dgvPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPatient_RowHeaderMouseClick);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.cmbSearch);
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnSearch);
            this.flowLayoutPanel2.Controls.Add(this.btnRegister);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.LightCyan;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSearch, "cmbSearch");
            this.cmbSearch.Name = "cmbSearch";
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // dgvApp
            // 
            this.dgvApp.AllowUserToAddRows = false;
            this.dgvApp.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvApp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvApp.BackgroundColor = System.Drawing.Color.White;
            this.dgvApp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvApp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.AStatus,
            this.AStatusID,
            this.ABtnDues,
            this.ABtnStatus,
            this.ABtnDetails,
            this.ABtnBill,
            this.ABtnDelete,
            this.ADues});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApp.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dgvApp, "dgvApp");
            this.dgvApp.GridColor = System.Drawing.Color.LightCyan;
            this.dgvApp.MultiSelect = false;
            this.dgvApp.Name = "dgvApp";
            this.dgvApp.ReadOnly = true;
            this.dgvApp.RowHeadersVisible = false;
            this.dgvApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApp_CellContentClick);
            this.dgvApp.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApp_RowHeaderMouseClick);
            // 
            // AID
            // 
            this.AID.DataPropertyName = "id";
            resources.ApplyResources(this.AID, "AID");
            this.AID.Name = "AID";
            this.AID.ReadOnly = true;
            // 
            // APatID
            // 
            this.APatID.DataPropertyName = "patient_id";
            resources.ApplyResources(this.APatID, "APatID");
            this.APatID.Name = "APatID";
            this.APatID.ReadOnly = true;
            // 
            // ADocID
            // 
            this.ADocID.DataPropertyName = "doctor_id";
            resources.ApplyResources(this.ADocID, "ADocID");
            this.ADocID.Name = "ADocID";
            this.ADocID.ReadOnly = true;
            // 
            // APatNum
            // 
            this.APatNum.DataPropertyName = "patient_number";
            resources.ApplyResources(this.APatNum, "APatNum");
            this.APatNum.Name = "APatNum";
            this.APatNum.ReadOnly = true;
            // 
            // APatName
            // 
            this.APatName.DataPropertyName = "patient_name";
            resources.ApplyResources(this.APatName, "APatName");
            this.APatName.Name = "APatName";
            this.APatName.ReadOnly = true;
            // 
            // ADocName
            // 
            this.ADocName.DataPropertyName = "doctor_name";
            resources.ApplyResources(this.ADocName, "ADocName");
            this.ADocName.Name = "ADocName";
            this.ADocName.ReadOnly = true;
            // 
            // AToken
            // 
            this.AToken.DataPropertyName = "token";
            resources.ApplyResources(this.AToken, "AToken");
            this.AToken.Name = "AToken";
            this.AToken.ReadOnly = true;
            // 
            // APrevDate
            // 
            this.APrevDate.DataPropertyName = "prev_date";
            resources.ApplyResources(this.APrevDate, "APrevDate");
            this.APrevDate.Name = "APrevDate";
            this.APrevDate.ReadOnly = true;
            // 
            // AStatus
            // 
            this.AStatus.DataPropertyName = "status";
            resources.ApplyResources(this.AStatus, "AStatus");
            this.AStatus.Name = "AStatus";
            this.AStatus.ReadOnly = true;
            this.AStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AStatusID
            // 
            this.AStatusID.DataPropertyName = "status_id";
            resources.ApplyResources(this.AStatusID, "AStatusID");
            this.AStatusID.Name = "AStatusID";
            this.AStatusID.ReadOnly = true;
            // 
            // ABtnDues
            // 
            resources.ApplyResources(this.ABtnDues, "ABtnDues");
            this.ABtnDues.Name = "ABtnDues";
            this.ABtnDues.ReadOnly = true;
            this.ABtnDues.Text = "Bill Dues";
            this.ABtnDues.UseColumnTextForButtonValue = true;
            // 
            // ABtnStatus
            // 
            resources.ApplyResources(this.ABtnStatus, "ABtnStatus");
            this.ABtnStatus.Name = "ABtnStatus";
            this.ABtnStatus.ReadOnly = true;
            this.ABtnStatus.Text = "Change Status";
            this.ABtnStatus.UseColumnTextForButtonValue = true;
            // 
            // ABtnDetails
            // 
            resources.ApplyResources(this.ABtnDetails, "ABtnDetails");
            this.ABtnDetails.Name = "ABtnDetails";
            this.ABtnDetails.ReadOnly = true;
            this.ABtnDetails.Text = "View Details";
            this.ABtnDetails.UseColumnTextForButtonValue = true;
            // 
            // ABtnBill
            // 
            resources.ApplyResources(this.ABtnBill, "ABtnBill");
            this.ABtnBill.Name = "ABtnBill";
            this.ABtnBill.ReadOnly = true;
            this.ABtnBill.Text = "Generate Bills";
            this.ABtnBill.UseColumnTextForButtonValue = true;
            // 
            // ABtnDelete
            // 
            resources.ApplyResources(this.ABtnDelete, "ABtnDelete");
            this.ABtnDelete.Name = "ABtnDelete";
            this.ABtnDelete.ReadOnly = true;
            this.ABtnDelete.Text = "Cancel";
            this.ABtnDelete.UseColumnTextForButtonValue = true;
            // 
            // ADues
            // 
            this.ADues.DataPropertyName = "dues";
            resources.ApplyResources(this.ADues, "ADues");
            this.ADues.Name = "ADues";
            this.ADues.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblHead1
            // 
            resources.ApplyResources(this.lblHead1, "lblHead1");
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.Name = "lblHead1";
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(this.flowLayoutPanel6, "flowLayoutPanel6");
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.dtpAppDate);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // dtpAppDate
            // 
            this.dtpAppDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpAppDate, "dtpAppDate");
            this.dtpAppDate.Name = "dtpAppDate";
            this.dtpAppDate.ValueChanged += new System.EventHandler(this.dtpAppDate_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmbDoc);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbDoc
            // 
            this.cmbDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDoc, "cmbDoc");
            this.cmbDoc.Name = "cmbDoc";
            this.cmbDoc.SelectedIndexChanged += new System.EventHandler(this.cmbDoc_SelectedIndexChanged);
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.txtPatNum);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtPatNum
            // 
            resources.ApplyResources(this.txtPatNum, "txtPatNum");
            this.txtPatNum.Name = "txtPatNum";
            this.txtPatNum.TextChanged += new System.EventHandler(this.txtPatNum_TextChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.btnList);
            this.flowLayoutPanel5.Controls.Add(this.txtAppID);
            this.flowLayoutPanel5.Controls.Add(this.txtPatientID);
            resources.ApplyResources(this.flowLayoutPanel5, "flowLayoutPanel5");
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.Name = "btnList";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // txtAppID
            // 
            resources.ApplyResources(this.txtAppID, "txtAppID");
            this.txtAppID.Name = "txtAppID";
            // 
            // txtPatientID
            // 
            resources.ApplyResources(this.txtPatientID, "txtPatientID");
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.TextChanged += new System.EventHandler(this.txtPatientID_TextChanged);
            // 
            // PID
            // 
            this.PID.DataPropertyName = "id";
            resources.ApplyResources(this.PID, "PID");
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            // 
            // PNum
            // 
            this.PNum.DataPropertyName = "patient_number";
            resources.ApplyResources(this.PNum, "PNum");
            this.PNum.Name = "PNum";
            this.PNum.ReadOnly = true;
            // 
            // Pname
            // 
            this.Pname.DataPropertyName = "name";
            resources.ApplyResources(this.Pname, "Pname");
            this.Pname.Name = "Pname";
            this.Pname.ReadOnly = true;
            // 
            // PGender
            // 
            this.PGender.DataPropertyName = "gender";
            resources.ApplyResources(this.PGender, "PGender");
            this.PGender.Name = "PGender";
            this.PGender.ReadOnly = true;
            // 
            // PAge
            // 
            this.PAge.DataPropertyName = "age";
            resources.ApplyResources(this.PAge, "PAge");
            this.PAge.Name = "PAge";
            this.PAge.ReadOnly = true;
            // 
            // PAddress
            // 
            this.PAddress.DataPropertyName = "address1";
            resources.ApplyResources(this.PAddress, "PAddress");
            this.PAddress.Name = "PAddress";
            this.PAddress.ReadOnly = true;
            // 
            // PPhone
            // 
            this.PPhone.DataPropertyName = "phone";
            resources.ApplyResources(this.PPhone, "PPhone");
            this.PPhone.Name = "PPhone";
            this.PPhone.ReadOnly = true;
            // 
            // PDoctor
            // 
            this.PDoctor.DataPropertyName = "doctor_name";
            resources.ApplyResources(this.PDoctor, "PDoctor");
            this.PDoctor.Name = "PDoctor";
            this.PDoctor.ReadOnly = true;
            // 
            // PVisitDate
            // 
            this.PVisitDate.DataPropertyName = "meet_date";
            resources.ApplyResources(this.PVisitDate, "PVisitDate");
            this.PVisitDate.Name = "PVisitDate";
            this.PVisitDate.ReadOnly = true;
            // 
            // PBtnSelect
            // 
            resources.ApplyResources(this.PBtnSelect, "PBtnSelect");
            this.PBtnSelect.Name = "PBtnSelect";
            this.PBtnSelect.ReadOnly = true;
            this.PBtnSelect.Text = "Schedule";
            this.PBtnSelect.UseColumnTextForButtonValue = true;
            // 
            // PBtnHistory
            // 
            resources.ApplyResources(this.PBtnHistory, "PBtnHistory");
            this.PBtnHistory.Name = "PBtnHistory";
            this.PBtnHistory.ReadOnly = true;
            this.PBtnHistory.Text = "History";
            this.PBtnHistory.UseColumnTextForButtonValue = true;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.lblStatusCombo);
            this.flowLayoutPanel7.Controls.Add(this.cmbStatus);
            resources.ApplyResources(this.flowLayoutPanel7, "flowLayoutPanel7");
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            // 
            // lblStatusCombo
            // 
            resources.ApplyResources(this.lblStatusCombo, "lblStatusCombo");
            this.lblStatusCombo.Name = "lblStatusCombo";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbStatus, "cmbStatus");
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Name = "cmbStatus";
            // 
            // frmAppointments
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAppointments";
            this.Activated += new System.EventHandler(this.frmAppointments_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAppointments_FormClosed);
            this.Load += new System.EventHandler(this.frmAppointments_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvApp;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAppDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatNum;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.TextBox txtAppID;
        private System.Windows.Forms.ComboBox cmbDoc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn AID;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn APatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn APrevDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AStatusID;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnDues;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnStatus;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnDetails;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnBill;
        private System.Windows.Forms.DataGridViewButtonColumn ABtnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADues;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PVisitDate;
        private System.Windows.Forms.DataGridViewButtonColumn PBtnSelect;
        private System.Windows.Forms.DataGridViewButtonColumn PBtnHistory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label lblStatusCombo;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}