namespace HospitalManagementySite
{
    partial class PatientTriage
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxVisitInfo = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.comboBoxPatientStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVisitReason = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxVisitInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Patient Triage";
            // 
            // groupBoxVisitInfo
            // 
            this.groupBoxVisitInfo.Controls.Add(this.buttonExit);
            this.groupBoxVisitInfo.Controls.Add(this.buttonSubmit);
            this.groupBoxVisitInfo.Controls.Add(this.comboBoxPatientStatus);
            this.groupBoxVisitInfo.Controls.Add(this.label1);
            this.groupBoxVisitInfo.Controls.Add(this.comboBoxVisitReason);
            this.groupBoxVisitInfo.Controls.Add(this.label7);
            this.groupBoxVisitInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVisitInfo.Location = new System.Drawing.Point(45, 122);
            this.groupBoxVisitInfo.Name = "groupBoxVisitInfo";
            this.groupBoxVisitInfo.Size = new System.Drawing.Size(388, 199);
            this.groupBoxVisitInfo.TabIndex = 10;
            this.groupBoxVisitInfo.TabStop = false;
            this.groupBoxVisitInfo.Text = "Visit Info";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(203, 144);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(91, 34);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(98, 144);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(87, 34);
            this.buttonSubmit.TabIndex = 13;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // comboBoxPatientStatus
            // 
            this.comboBoxPatientStatus.FormattingEnabled = true;
            this.comboBoxPatientStatus.Location = new System.Drawing.Point(131, 89);
            this.comboBoxPatientStatus.Name = "comboBoxPatientStatus";
            this.comboBoxPatientStatus.Size = new System.Drawing.Size(238, 28);
            this.comboBoxPatientStatus.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Patient Status";
            // 
            // comboBoxVisitReason
            // 
            this.comboBoxVisitReason.FormattingEnabled = true;
            this.comboBoxVisitReason.Location = new System.Drawing.Point(131, 37);
            this.comboBoxVisitReason.Name = "comboBoxVisitReason";
            this.comboBoxVisitReason.Size = new System.Drawing.Size(238, 28);
            this.comboBoxVisitReason.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Visit Reason";
            // 
            // PatientTriage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 362);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxVisitInfo);
            this.Name = "PatientTriage";
            this.Text = "PatientTriage";
            this.groupBoxVisitInfo.ResumeLayout(false);
            this.groupBoxVisitInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxVisitInfo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.ComboBox comboBoxPatientStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVisitReason;
        private System.Windows.Forms.Label label7;
    }
}