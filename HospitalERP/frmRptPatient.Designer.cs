namespace HospitalERP
{
    partial class frmRptPatient
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uspReport_PatientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPatient = new HospitalERP.DataSetPatient();
            this.uspReport_PatientTableAdapter = new HospitalERP.DataSetPatientTableAdapters.uspReport_PatientTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_PatientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(125, 16);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(156, 22);
            this.dtFromDate.TabIndex = 10;
            this.dtFromDate.Value = new System.DateTime(2018, 2, 5, 0, 0, 0, 0);
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(291, 16);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(164, 22);
            this.dtToDate.TabIndex = 11;
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.LightCyan;
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(501, 15);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 27, 4);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(253, 24);
            this.cmbSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(781, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 27, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(1065, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 40, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsPatient";
            reportDataSource1.Value = this.uspReport_PatientBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HospitalERP.ReportPatient.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1271, 357);
            this.reportViewer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 357);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSearch);
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.dtFromDate);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 58);
            this.panel2.TabIndex = 5;
            // 
            // uspReport_PatientBindingSource
            // 
            this.uspReport_PatientBindingSource.DataMember = "uspReport_Patient";
            this.uspReport_PatientBindingSource.DataSource = this.DataSetPatient;
            // 
            // DataSetPatient
            // 
            this.DataSetPatient.DataSetName = "DataSetPatient";
            this.DataSetPatient.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspReport_PatientTableAdapter
            // 
            this.uspReport_PatientTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 415);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRptPatient";
            this.Text = "Patient Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRptPatient_FormClosed);
            this.Load += new System.EventHandler(this.frmRptPatient_Load);
            this.Shown += new System.EventHandler(this.frmRptPatient_Shown);
            this.Enter += new System.EventHandler(this.frmRptPatient_Enter);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_PatientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource uspReport_PatientBindingSource;
        private DataSetPatient DataSetPatient;
        private DataSetPatientTableAdapters.uspReport_PatientTableAdapter uspReport_PatientTableAdapter;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}