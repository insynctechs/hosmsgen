namespace HospitalERP
{
    partial class frmRptProcedure
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
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uspReport_ProcedureTableAdapter = new HospitalERP.DataSetProcedureTableAdapters.uspReport_ProcedureTableAdapter();
            this.dataSetProcedure = new HospitalERP.DataSetProcedure();
            this.uspReport_ProcedureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProcedure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_ProcedureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(218, 13);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(124, 20);
            this.dtToDate.TabIndex = 11;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(368, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(94, 13);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(118, 20);
            this.dtFromDate.TabIndex = 10;
            this.dtFromDate.Value = new System.DateTime(2018, 2, 5, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(581, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HospitalERP.ReportProcedure.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(959, 403);
            this.reportViewer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 403);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtToDate);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.dtFromDate);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 47);
            this.panel2.TabIndex = 7;
            // 
            // uspReport_ProcedureTableAdapter
            // 
            this.uspReport_ProcedureTableAdapter.ClearBeforeFill = true;
            // 
            // dataSetProcedure
            // 
            this.dataSetProcedure.DataSetName = "DataSetProcedure";
            this.dataSetProcedure.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspReport_ProcedureBindingSource
            // 
            this.uspReport_ProcedureBindingSource.DataMember = "uspReport_Procedure";
            this.uspReport_ProcedureBindingSource.DataSource = this.dataSetProcedure;
            // 
            // frmRptProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmRptProcedure";
            this.Text = "Procedure Report";
            this.Load += new System.EventHandler(this.frmRptProcedure_Load);
            this.Shown += new System.EventHandler(this.frmRptProcedure_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProcedure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspReport_ProcedureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnSearch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DataSetProcedureTableAdapters.uspReport_ProcedureTableAdapter uspReport_ProcedureTableAdapter;
        private DataSetProcedure dataSetProcedure;
        private System.Windows.Forms.BindingSource uspReport_ProcedureBindingSource;
    }
}