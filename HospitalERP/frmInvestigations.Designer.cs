﻿namespace HospitalERP
{
    partial class frmInvestigations
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabSub = new System.Windows.Forms.TabControl();
            this.tabPgAdd = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHead1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbProcType = new System.Windows.Forms.ComboBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPgList = new System.Windows.Forms.TabPage();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.cmbActive = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabSub.SuspendLayout();
            this.tabPgAdd.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.tabPgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSub
            // 
            this.tabSub.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSub.Controls.Add(this.tabPgAdd);
            this.tabSub.Controls.Add(this.tabPgList);
            this.tabSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSub.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSub.Location = new System.Drawing.Point(0, 0);
            this.tabSub.Margin = new System.Windows.Forms.Padding(40, 12, 40, 12);
            this.tabSub.Multiline = true;
            this.tabSub.Name = "tabSub";
            this.tabSub.Padding = new System.Drawing.Point(20, 10);
            this.tabSub.SelectedIndex = 0;
            this.tabSub.ShowToolTips = true;
            this.tabSub.Size = new System.Drawing.Size(1344, 729);
            this.tabSub.TabIndex = 1;
            this.tabSub.SelectedIndexChanged += new System.EventHandler(this.tabSub_SelectedIndexChanged);
            // 
            // tabPgAdd
            // 
            this.tabPgAdd.BackColor = System.Drawing.Color.White;
            this.tabPgAdd.Controls.Add(this.tableLayoutPanel2);
            this.tabPgAdd.Location = new System.Drawing.Point(4, 50);
            this.tabPgAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPgAdd.Name = "tabPgAdd";
            this.tabPgAdd.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPgAdd.Size = new System.Drawing.Size(1336, 675);
            this.tabPgAdd.TabIndex = 0;
            this.tabPgAdd.Text = "Add";
            this.tabPgAdd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.lblHead1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblActive, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtDesc, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkActive, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbProcType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtFee, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel7, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(33, 4, 33, 18);
            this.tableLayoutPanel2.RowCount = 24;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1328, 667);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblHead1
            // 
            this.lblHead1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead1.AutoSize = true;
            this.lblHead1.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel2.SetColumnSpan(this.lblHead1, 3);
            this.lblHead1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead1.ForeColor = System.Drawing.Color.DimGray;
            this.lblHead1.Location = new System.Drawing.Point(37, 16);
            this.lblHead1.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.lblHead1.Name = "lblHead1";
            this.lblHead1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblHead1.Size = new System.Drawing.Size(1233, 35);
            this.lblHead1.TabIndex = 29;
            this.lblHead1.Text = "INVESTIGATIONS";
            this.lblHead1.UseWaitCursor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(375, 192);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(332, 30);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description:";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(37, 583);
            this.lblActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(63, 23);
            this.lblActive.TabIndex = 4;
            this.lblActive.Text = "Active:";
            // 
            // txtDesc
            // 
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Location = new System.Drawing.Point(375, 232);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(781, 307);
            this.txtDesc.TabIndex = 4;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(375, 587);
            this.chkActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(18, 17);
            this.chkActive.TabIndex = 6;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Controls.Add(this.btnSave);
            this.flowLayoutPanel3.Controls.Add(this.btnClear);
            this.flowLayoutPanel3.Controls.Add(this.btnCancel);
            this.flowLayoutPanel3.Controls.Add(this.txtID);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(375, 612);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(587, 48);
            this.flowLayoutPanel3.TabIndex = 57;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 41);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(112, 4);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 41);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(243, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(27, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 41);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(351, 4);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(60, 30);
            this.txtID.TabIndex = 59;
            this.txtID.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Salmon;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatus, 2);
            this.lblStatus.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(37, 86);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 25, 4, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(27, 6, 27, 6);
            this.lblStatus.Size = new System.Drawing.Size(56, 37);
            this.lblStatus.TabIndex = 58;
            this.lblStatus.Visible = false;
            // 
            // cmbProcType
            // 
            this.cmbProcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcType.FormattingEnabled = true;
            this.cmbProcType.Location = new System.Drawing.Point(375, 152);
            this.cmbProcType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProcType.Name = "cmbProcType";
            this.cmbProcType.Size = new System.Drawing.Size(332, 30);
            this.cmbProcType.TabIndex = 2;
            this.cmbProcType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProcType_Validating);
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(375, 547);
            this.txtFee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(332, 30);
            this.txtFee.TabIndex = 5;
            this.txtFee.Validating += new System.ComponentModel.CancelEventHandler(this.txtFee_Validating);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label3);
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(37, 152);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(267, 32);
            this.flowLayoutPanel5.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 62;
            this.label5.Text = "Type:";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label6);
            this.flowLayoutPanel6.Controls.Add(this.label7);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(37, 192);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(267, 32);
            this.flowLayoutPanel6.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 23);
            this.label7.TabIndex = 62;
            this.label7.Text = "Name:";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.label8);
            this.flowLayoutPanel7.Controls.Add(this.label9);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(37, 547);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(267, 32);
            this.flowLayoutPanel7.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(4, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 23);
            this.label9.TabIndex = 62;
            this.label9.Text = "Fee:";
            // 
            // tabPgList
            // 
            this.tabPgList.BackColor = System.Drawing.Color.White;
            this.tabPgList.Controls.Add(this.dgvList);
            this.tabPgList.Controls.Add(this.flowLayoutPanel2);
            this.tabPgList.Controls.Add(this.flowLayoutPanel1);
            this.tabPgList.Location = new System.Drawing.Point(4, 50);
            this.tabPgList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPgList.Name = "tabPgList";
            this.tabPgList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPgList.Size = new System.Drawing.Size(1336, 675);
            this.tabPgList.TabIndex = 1;
            this.tabPgList.Text = "Search/List";
            this.tabPgList.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colDesc,
            this.colTypeID,
            this.colTypeName,
            this.colFee,
            this.colActive,
            this.colBtnEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.LightCyan;
            this.dgvList.Location = new System.Drawing.Point(4, 102);
            this.dgvList.Margin = new System.Windows.Forms.Padding(27, 4, 27, 4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1328, 516);
            this.dgvList.TabIndex = 10;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            this.dgvList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_RowHeaderMouseClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 618);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1328, 53);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cmbSearch);
            this.flowLayoutPanel1.Controls.Add(this.cmbActive);
            this.flowLayoutPanel1.Controls.Add(this.txtSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 25);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1328, 98);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(40, 6, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.LightCyan;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(127, 29);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 27, 4);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(199, 32);
            this.cmbSearch.TabIndex = 9;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // cmbActive
            // 
            this.cmbActive.FormattingEnabled = true;
            this.cmbActive.Location = new System.Drawing.Point(357, 29);
            this.cmbActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.Size = new System.Drawing.Size(160, 32);
            this.cmbActive.TabIndex = 12;
            this.cmbActive.Visible = false;
            this.cmbActive.SelectedIndexChanged += new System.EventHandler(this.cmbActive_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(525, 29);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 27, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 32);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(821, 29);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 36);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.DataPropertyName = "id";
            this.colID.FillWeight = 5F;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "name";
            this.colName.FillWeight = 20F;
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 20;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDesc
            // 
            this.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesc.DataPropertyName = "description";
            this.colDesc.FillWeight = 40F;
            this.colDesc.HeaderText = "Description";
            this.colDesc.MinimumWidth = 40;
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            // 
            // colTypeID
            // 
            this.colTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTypeID.DataPropertyName = "type";
            this.colTypeID.FillWeight = 5F;
            this.colTypeID.HeaderText = "Type ID";
            this.colTypeID.Name = "colTypeID";
            this.colTypeID.ReadOnly = true;
            this.colTypeID.Visible = false;
            // 
            // colTypeName
            // 
            this.colTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTypeName.DataPropertyName = "type_name";
            this.colTypeName.FillWeight = 10F;
            this.colTypeName.HeaderText = "Type Name";
            this.colTypeName.MinimumWidth = 10;
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.ReadOnly = true;
            // 
            // colFee
            // 
            this.colFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFee.DataPropertyName = "fee";
            this.colFee.FillWeight = 5F;
            this.colFee.HeaderText = "Fee";
            this.colFee.Name = "colFee";
            this.colFee.ReadOnly = true;
            // 
            // colActive
            // 
            this.colActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colActive.DataPropertyName = "active";
            this.colActive.FillWeight = 5F;
            this.colActive.HeaderText = "Active";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colBtnEdit
            // 
            this.colBtnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBtnEdit.FillWeight = 5F;
            this.colBtnEdit.HeaderText = "";
            this.colBtnEdit.Name = "colBtnEdit";
            this.colBtnEdit.ReadOnly = true;
            this.colBtnEdit.Text = "Edit";
            this.colBtnEdit.UseColumnTextForButtonValue = true;
            // 
            // frmInvestigations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.ControlBox = false;
            this.Controls.Add(this.tabSub);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmInvestigations";
            this.Text = "Investigations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInvestigations_FormClosed);
            this.Load += new System.EventHandler(this.frmInvestigations_Load);
            this.Shown += new System.EventHandler(this.frmInvestigations_Shown);
            this.tabSub.ResumeLayout(false);
            this.tabPgAdd.ResumeLayout(false);
            this.tabPgAdd.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.tabPgList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSub;
        private System.Windows.Forms.TabPage tabPgAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblHead1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbProcType;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.TabPage tabPgList;
        
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnEdit;
    }
}