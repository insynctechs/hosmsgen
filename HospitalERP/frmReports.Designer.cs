namespace HospitalERP
{
    partial class frmReports
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
            this.btnBillingRpt = new System.Windows.Forms.Button();
            this.btnPatientRpt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBillingRpt
            // 
            this.btnBillingRpt.BackColor = System.Drawing.Color.White;
            this.btnBillingRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBillingRpt.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnBillingRpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.btnBillingRpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btnBillingRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillingRpt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillingRpt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnBillingRpt.Image = global::HospitalERP.Properties.Resources.reports;
            this.btnBillingRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBillingRpt.Location = new System.Drawing.Point(19, 73);
            this.btnBillingRpt.Margin = new System.Windows.Forms.Padding(4);
            this.btnBillingRpt.Name = "btnBillingRpt";
            this.btnBillingRpt.Size = new System.Drawing.Size(269, 89);
            this.btnBillingRpt.TabIndex = 17;
            this.btnBillingRpt.Text = "Billing Report";
            this.btnBillingRpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillingRpt.UseVisualStyleBackColor = true;
            this.btnBillingRpt.Click += new System.EventHandler(this.btnBillingRpt_Click);
            // 
            // btnPatientRpt
            // 
            this.btnPatientRpt.BackColor = System.Drawing.Color.White;
            this.btnPatientRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatientRpt.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPatientRpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.btnPatientRpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btnPatientRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientRpt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientRpt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnPatientRpt.Image = global::HospitalERP.Properties.Resources.staff_types;
            this.btnPatientRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientRpt.Location = new System.Drawing.Point(308, 73);
            this.btnPatientRpt.Margin = new System.Windows.Forms.Padding(4);
            this.btnPatientRpt.Name = "btnPatientRpt";
            this.btnPatientRpt.Size = new System.Drawing.Size(265, 89);
            this.btnPatientRpt.TabIndex = 18;
            this.btnPatientRpt.Text = "Patient Report";
            this.btnPatientRpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPatientRpt.UseVisualStyleBackColor = true;
            this.btnPatientRpt.Click += new System.EventHandler(this.btnPatientRpt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 41);
            this.label1.TabIndex = 19;
            this.label1.Text = "REPORTS";
            // 
            // btnProc
            // 
            this.btnProc.BackColor = System.Drawing.Color.White;
            this.btnProc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProc.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnProc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.btnProc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btnProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProc.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnProc.Image = global::HospitalERP.Properties.Resources.reports;
            this.btnProc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProc.Location = new System.Drawing.Point(112, 175);
            this.btnProc.Margin = new System.Windows.Forms.Padding(4);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(335, 89);
            this.btnProc.TabIndex = 20;
            this.btnProc.Text = "Procedure Report";
            this.btnProc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Visible = false;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 278);
            this.ControlBox = false;
            this.Controls.Add(this.btnProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPatientRpt);
            this.Controls.Add(this.btnBillingRpt);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReports";
            this.ShowIcon = false;
            this.Text = "Reports";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReports_FormClosed);
            this.Shown += new System.EventHandler(this.frmReports_Shown);
            this.Enter += new System.EventHandler(this.frmReports_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBillingRpt;
        private System.Windows.Forms.Button btnPatientRpt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProc;
    }
}