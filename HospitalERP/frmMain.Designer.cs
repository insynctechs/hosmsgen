namespace HospitalERP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInvestigation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMedicine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProcType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInvestigationType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMedType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUserRole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStaffGen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReg = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConsultations = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPatSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBillSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBillingReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPatientRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.miProcedureReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miServerDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miLicensingKey = new System.Windows.Forms.ToolStripMenuItem();
            this.sendErrorLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnApp = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.tblLoginPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lnkChangePwd = new System.Windows.Forms.LinkLabel();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.btnChildClose = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblLoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Calibri", 11F);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMain,
            this.menuItemStaffs,
            this.menuItemPatients,
            this.menuItemBill,
            this.menuItemReports,
            this.menuItemHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(1344, 31);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            // 
            // menuItemMain
            // 
            this.menuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDept,
            this.menuItemProc,
            this.menuItemInvestigation,
            this.menuItemMedicine,
            this.menuItemStaffType,
            this.menuItemProcType,
            this.menuItemInvestigationType,
            this.menuItemMedType,
            this.menuItemUserRole,
            this.menuItemOpt});
            this.menuItemMain.Name = "menuItemMain";
            this.menuItemMain.Size = new System.Drawing.Size(61, 27);
            this.menuItemMain.Text = "Main";
            // 
            // menuItemDept
            // 
            this.menuItemDept.Name = "menuItemDept";
            this.menuItemDept.Size = new System.Drawing.Size(236, 28);
            this.menuItemDept.Text = "Departments";
            this.menuItemDept.Click += new System.EventHandler(this.menuItemDept_Click);
            // 
            // menuItemProc
            // 
            this.menuItemProc.Name = "menuItemProc";
            this.menuItemProc.Size = new System.Drawing.Size(236, 28);
            this.menuItemProc.Text = "Procedures";
            this.menuItemProc.Click += new System.EventHandler(this.menuItemProc_Click);
            // 
            // menuItemInvestigation
            // 
            this.menuItemInvestigation.Name = "menuItemInvestigation";
            this.menuItemInvestigation.Size = new System.Drawing.Size(236, 28);
            this.menuItemInvestigation.Text = "Investigations";
            this.menuItemInvestigation.Click += new System.EventHandler(this.menuItemInves_Click);
            // 
            // menuItemMedicine
            // 
            this.menuItemMedicine.Name = "menuItemMedicine";
            this.menuItemMedicine.Size = new System.Drawing.Size(236, 28);
            this.menuItemMedicine.Text = "Medicines";
            this.menuItemMedicine.Click += new System.EventHandler(this.menuItemMedicine_Click);
            // 
            // menuItemStaffType
            // 
            this.menuItemStaffType.Name = "menuItemStaffType";
            this.menuItemStaffType.Size = new System.Drawing.Size(236, 28);
            this.menuItemStaffType.Text = "Staff Types";
            this.menuItemStaffType.Click += new System.EventHandler(this.menuItemStaffType_Click);
            // 
            // menuItemProcType
            // 
            this.menuItemProcType.Name = "menuItemProcType";
            this.menuItemProcType.Size = new System.Drawing.Size(236, 28);
            this.menuItemProcType.Text = "Procedure Types";
            this.menuItemProcType.Click += new System.EventHandler(this.menuItemProcType_Click);
            // 
            // menuItemInvestigationType
            // 
            this.menuItemInvestigationType.Name = "menuItemInvestigationType";
            this.menuItemInvestigationType.Size = new System.Drawing.Size(236, 28);
            this.menuItemInvestigationType.Text = "Investigation Types";
            this.menuItemInvestigationType.Click += new System.EventHandler(this.menuItemInvesType_Click);
            // 
            // menuItemMedType
            // 
            this.menuItemMedType.Name = "menuItemMedType";
            this.menuItemMedType.Size = new System.Drawing.Size(236, 28);
            this.menuItemMedType.Text = "Medicine Types";
            this.menuItemMedType.Click += new System.EventHandler(this.menuItemMedType_Click);
            // 
            // menuItemUserRole
            // 
            this.menuItemUserRole.Name = "menuItemUserRole";
            this.menuItemUserRole.Size = new System.Drawing.Size(236, 28);
            this.menuItemUserRole.Text = "User Roles";
            this.menuItemUserRole.Click += new System.EventHandler(this.menuItemUserRoles_Click);
            // 
            // menuItemOpt
            // 
            this.menuItemOpt.Name = "menuItemOpt";
            this.menuItemOpt.Size = new System.Drawing.Size(236, 28);
            this.menuItemOpt.Text = "Options";
            this.menuItemOpt.Click += new System.EventHandler(this.menuItemOpt_Click);
            // 
            // menuItemStaffs
            // 
            this.menuItemStaffs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDocs,
            this.menuItemStaffGen});
            this.menuItemStaffs.Name = "menuItemStaffs";
            this.menuItemStaffs.Size = new System.Drawing.Size(65, 27);
            this.menuItemStaffs.Text = "Staffs";
            // 
            // menuItemDocs
            // 
            this.menuItemDocs.Name = "menuItemDocs";
            this.menuItemDocs.Size = new System.Drawing.Size(216, 28);
            this.menuItemDocs.Text = "Doctors ";
            this.menuItemDocs.Click += new System.EventHandler(this.menuItemDocs_Click);
            // 
            // menuItemStaffGen
            // 
            this.menuItemStaffGen.Name = "menuItemStaffGen";
            this.menuItemStaffGen.Size = new System.Drawing.Size(216, 28);
            this.menuItemStaffGen.Text = "General";
            this.menuItemStaffGen.Click += new System.EventHandler(this.menuItemStaffOthers_Click);
            // 
            // menuItemPatients
            // 
            this.menuItemPatients.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApp,
            this.menuItemReg,
            this.menuItemConsultations,
            this.menuItemPatSearch});
            this.menuItemPatients.Name = "menuItemPatients";
            this.menuItemPatients.Size = new System.Drawing.Size(85, 27);
            this.menuItemPatients.Text = "Patients";
            // 
            // menuItemApp
            // 
            this.menuItemApp.Name = "menuItemApp";
            this.menuItemApp.Size = new System.Drawing.Size(218, 28);
            this.menuItemApp.Text = "Appointments";
            this.menuItemApp.Click += new System.EventHandler(this.menuItemApp_Click);
            // 
            // menuItemReg
            // 
            this.menuItemReg.Name = "menuItemReg";
            this.menuItemReg.Size = new System.Drawing.Size(218, 28);
            this.menuItemReg.Text = "New Registration";
            this.menuItemReg.Click += new System.EventHandler(this.menuItemReg_Click);
            // 
            // menuItemConsultations
            // 
            this.menuItemConsultations.Name = "menuItemConsultations";
            this.menuItemConsultations.Size = new System.Drawing.Size(218, 28);
            this.menuItemConsultations.Text = "Consultations";
            this.menuItemConsultations.Visible = false;
            this.menuItemConsultations.Click += new System.EventHandler(this.menuItemConsultations_Click);
            // 
            // menuItemPatSearch
            // 
            this.menuItemPatSearch.Name = "menuItemPatSearch";
            this.menuItemPatSearch.Size = new System.Drawing.Size(218, 28);
            this.menuItemPatSearch.Text = "Search";
            this.menuItemPatSearch.Click += new System.EventHandler(this.menuItemPatSearch_Click);
            // 
            // menuItemBill
            // 
            this.menuItemBill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBillSearch});
            this.menuItemBill.Name = "menuItemBill";
            this.menuItemBill.Size = new System.Drawing.Size(67, 27);
            this.menuItemBill.Text = "Billing";
            // 
            // menuItemBillSearch
            // 
            this.menuItemBillSearch.Name = "menuItemBillSearch";
            this.menuItemBillSearch.Size = new System.Drawing.Size(138, 28);
            this.menuItemBillSearch.Text = "Search";
            this.menuItemBillSearch.Click += new System.EventHandler(this.menuItemBillSearch_Click);
            // 
            // menuItemReports
            // 
            this.menuItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBillingReport,
            this.menuItemPatientRpt,
            this.miProcedureReport});
            this.menuItemReports.Name = "menuItemReports";
            this.menuItemReports.Size = new System.Drawing.Size(82, 27);
            this.menuItemReports.Text = "Reports";
            // 
            // menuItemBillingReport
            // 
            this.menuItemBillingReport.Name = "menuItemBillingReport";
            this.menuItemBillingReport.Size = new System.Drawing.Size(222, 28);
            this.menuItemBillingReport.Text = "Billing Report";
            this.menuItemBillingReport.Click += new System.EventHandler(this.menuitemBillingReport_Click);
            // 
            // menuItemPatientRpt
            // 
            this.menuItemPatientRpt.Name = "menuItemPatientRpt";
            this.menuItemPatientRpt.Size = new System.Drawing.Size(222, 28);
            this.menuItemPatientRpt.Text = "Patient Report";
            this.menuItemPatientRpt.Click += new System.EventHandler(this.miPatientRpt_Click);
            // 
            // miProcedureReport
            // 
            this.miProcedureReport.Name = "miProcedureReport";
            this.miProcedureReport.Size = new System.Drawing.Size(222, 28);
            this.miProcedureReport.Text = "Procedure Report";
            this.miProcedureReport.Visible = false;
            this.miProcedureReport.Click += new System.EventHandler(this.miProcedureReport_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout,
            this.miServerDetails,
            this.miLicensingKey,
            this.sendErrorLogToolStripMenuItem});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(57, 27);
            this.menuItemHelp.Text = "Help";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(199, 28);
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miServerDetails
            // 
            this.miServerDetails.Name = "miServerDetails";
            this.miServerDetails.Size = new System.Drawing.Size(199, 28);
            this.miServerDetails.Text = "Server Details";
            this.miServerDetails.Visible = false;
            this.miServerDetails.Click += new System.EventHandler(this.miServerDetails_Click);
            // 
            // miLicensingKey
            // 
            this.miLicensingKey.Name = "miLicensingKey";
            this.miLicensingKey.Size = new System.Drawing.Size(199, 28);
            this.miLicensingKey.Text = "Licensing Key";
            this.miLicensingKey.Visible = false;
            // 
            // sendErrorLogToolStripMenuItem
            // 
            this.sendErrorLogToolStripMenuItem.Name = "sendErrorLogToolStripMenuItem";
            this.sendErrorLogToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.sendErrorLogToolStripMenuItem.Text = "Send Error Log";
            this.sendErrorLogToolStripMenuItem.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 170);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.09406F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.90594F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 305F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAppName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblLoginPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1344, 170);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel1.Controls.Add(this.btnApp);
            this.flowLayoutPanel1.Controls.Add(this.btnReg);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(295, 25);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 90);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::HospitalERP.Properties.Resources.dashboard_icon;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(4, 4);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(191, 71);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnApp
            // 
            this.btnApp.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApp.ForeColor = System.Drawing.Color.White;
            this.btnApp.Image = global::HospitalERP.Properties.Resources.calendar;
            this.btnApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApp.Location = new System.Drawing.Point(203, 4);
            this.btnApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(209, 71);
            this.btnApp.TabIndex = 0;
            this.btnApp.Text = "APPOINTMENTS";
            this.btnApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApp.UseVisualStyleBackColor = false;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            // 
            // btnReg
            // 
            this.btnReg.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.ForeColor = System.Drawing.Color.White;
            this.btnReg.Image = global::HospitalERP.Properties.Resources.registration;
            this.btnReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReg.Location = new System.Drawing.Point(420, 4);
            this.btnReg.Margin = new System.Windows.Forms.Padding(4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(267, 71);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "PATIENT REGISTRATION";
            this.btnReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAppName.Location = new System.Drawing.Point(4, 0);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.lblAppName.Size = new System.Drawing.Size(218, 78);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "INTAB ERP";
            // 
            // tblLoginPanel
            // 
            this.tblLoginPanel.AutoSize = true;
            this.tblLoginPanel.Controls.Add(this.lblEmpID);
            this.tblLoginPanel.Controls.Add(this.lnkChangePwd);
            this.tblLoginPanel.Controls.Add(this.linkLogout);
            this.tblLoginPanel.Controls.Add(this.btnChildClose);
            this.tblLoginPanel.Location = new System.Drawing.Point(1042, 4);
            this.tblLoginPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tblLoginPanel.Name = "tblLoginPanel";
            this.tblLoginPanel.Size = new System.Drawing.Size(261, 162);
            this.tblLoginPanel.TabIndex = 8;
            // 
            // lblEmpID
            // 
            this.lblEmpID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmpID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lblEmpID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.ForeColor = System.Drawing.Color.Aqua;
            this.lblEmpID.Location = new System.Drawing.Point(4, 0);
            this.lblEmpID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(253, 46);
            this.lblEmpID.TabIndex = 2;
            this.lblEmpID.Text = "Super Admin";
            this.lblEmpID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkChangePwd
            // 
            this.lnkChangePwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkChangePwd.BackColor = System.Drawing.Color.Gainsboro;
            this.lnkChangePwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkChangePwd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChangePwd.ForeColor = System.Drawing.Color.White;
            this.lnkChangePwd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkChangePwd.LinkColor = System.Drawing.Color.CadetBlue;
            this.lnkChangePwd.Location = new System.Drawing.Point(4, 46);
            this.lnkChangePwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkChangePwd.Name = "lnkChangePwd";
            this.lnkChangePwd.Padding = new System.Windows.Forms.Padding(0, 0, 13, 0);
            this.lnkChangePwd.Size = new System.Drawing.Size(253, 32);
            this.lnkChangePwd.TabIndex = 0;
            this.lnkChangePwd.TabStop = true;
            this.lnkChangePwd.Text = "Change Password";
            this.lnkChangePwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkChangePwd.VisitedLinkColor = System.Drawing.Color.Orange;
            this.lnkChangePwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangePwd_LinkClicked);
            // 
            // linkLogout
            // 
            this.linkLogout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLogout.BackColor = System.Drawing.Color.Gainsboro;
            this.linkLogout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.linkLogout.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.linkLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLogout.LinkColor = System.Drawing.Color.CadetBlue;
            this.linkLogout.Location = new System.Drawing.Point(4, 78);
            this.linkLogout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(253, 32);
            this.linkLogout.TabIndex = 0;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLogout.VisitedLinkColor = System.Drawing.Color.DarkGoldenrod;
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // btnChildClose
            // 
            this.btnChildClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChildClose.AutoSize = true;
            this.btnChildClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.btnChildClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChildClose.FlatAppearance.BorderSize = 0;
            this.btnChildClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.btnChildClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.btnChildClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChildClose.Image = global::HospitalERP.Properties.Resources.close;
            this.btnChildClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChildClose.Location = new System.Drawing.Point(4, 114);
            this.btnChildClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnChildClose.Name = "btnChildClose";
            this.btnChildClose.Size = new System.Drawing.Size(223, 44);
            this.btnChildClose.TabIndex = 9;
            this.btnChildClose.UseVisualStyleBackColor = false;
            this.btnChildClose.Visible = false;
            this.btnChildClose.Click += new System.EventHandler(this.btnChildClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 898);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "INTAB ERP";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Hospital_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tblLoginPanel.ResumeLayout(false);
            this.tblLoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffs;
        private System.Windows.Forms.ToolStripMenuItem menuItemPatients;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffType;
        private System.Windows.Forms.ToolStripMenuItem menuItemProcType;
        private System.Windows.Forms.ToolStripMenuItem menuItemDocs;
        private System.Windows.Forms.ToolStripMenuItem menuItemStaffGen;
        private System.Windows.Forms.ToolStripMenuItem menuItemBill;
        private System.Windows.Forms.ToolStripMenuItem menuItemReports;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.ToolStripMenuItem menuItemApp;
        private System.Windows.Forms.ToolStripMenuItem menuItemReg;
        private System.Windows.Forms.ToolStripMenuItem menuItemPatSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemProc;
        private System.Windows.Forms.ToolStripMenuItem menuItemUserRole;
        private System.Windows.Forms.ToolStripMenuItem menuItemDept;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpt;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.LinkLabel lnkChangePwd;
        private System.Windows.Forms.ToolStripMenuItem menuItemConsultations;
        private System.Windows.Forms.ToolStripMenuItem menuItemBillSearch;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnApp;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.FlowLayoutPanel tblLoginPanel;
        private System.Windows.Forms.Button btnChildClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemBillingReport;
        private System.Windows.Forms.ToolStripMenuItem menuItemPatientRpt;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miLicensingKey;
        private System.Windows.Forms.ToolStripMenuItem sendErrorLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miServerDetails;
        private System.Windows.Forms.ToolStripMenuItem menuItemMedicine;
        private System.Windows.Forms.ToolStripMenuItem menuItemMedType;
        private System.Windows.Forms.ToolStripMenuItem menuItemInvestigation;
        private System.Windows.Forms.ToolStripMenuItem menuItemInvestigationType;
        private System.Windows.Forms.ToolStripMenuItem miProcedureReport;
    }
}