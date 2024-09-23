namespace HospitalManagementySite
{
    partial class MainForm
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
            this.button_patientManagement = new System.Windows.Forms.Button();
            this.label_greet = new System.Windows.Forms.Label();
            this.button_signOut = new System.Windows.Forms.Button();
            this.button_appointment = new System.Windows.Forms.Button();
            this.button_medicalInventory = new System.Windows.Forms.Button();
            this.button_dataAnalytics = new System.Windows.Forms.Button();
            this.button_chat = new System.Windows.Forms.Button();
            this.label_loginType = new System.Windows.Forms.Label();
            this.buttonPatientAdmission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_patientManagement
            // 
            this.button_patientManagement.Location = new System.Drawing.Point(153, 92);
            this.button_patientManagement.Name = "button_patientManagement";
            this.button_patientManagement.Size = new System.Drawing.Size(212, 46);
            this.button_patientManagement.TabIndex = 0;
            this.button_patientManagement.Text = "Patient Management Page";
            this.button_patientManagement.UseVisualStyleBackColor = true;
            this.button_patientManagement.Click += new System.EventHandler(this.button_patientManagement_Click);
            // 
            // label_greet
            // 
            this.label_greet.AutoSize = true;
            this.label_greet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_greet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_greet.Location = new System.Drawing.Point(423, 9);
            this.label_greet.Name = "label_greet";
            this.label_greet.Size = new System.Drawing.Size(91, 16);
            this.label_greet.TabIndex = 2;
            this.label_greet.Text = "Hello Jiwon!";
            // 
            // button_signOut
            // 
            this.button_signOut.Location = new System.Drawing.Point(466, 28);
            this.button_signOut.Name = "button_signOut";
            this.button_signOut.Size = new System.Drawing.Size(63, 23);
            this.button_signOut.TabIndex = 3;
            this.button_signOut.Text = "Sign Out";
            this.button_signOut.UseVisualStyleBackColor = true;
            this.button_signOut.Click += new System.EventHandler(this.button_signOut_Click);
            // 
            // button_appointment
            // 
            this.button_appointment.Location = new System.Drawing.Point(153, 169);
            this.button_appointment.Name = "button_appointment";
            this.button_appointment.Size = new System.Drawing.Size(212, 46);
            this.button_appointment.TabIndex = 4;
            this.button_appointment.Text = "Appointment Management";
            this.button_appointment.UseVisualStyleBackColor = true;
            this.button_appointment.Click += new System.EventHandler(this.button_appointment_Click);
            // 
            // button_medicalInventory
            // 
            this.button_medicalInventory.Location = new System.Drawing.Point(153, 363);
            this.button_medicalInventory.Name = "button_medicalInventory";
            this.button_medicalInventory.Size = new System.Drawing.Size(212, 44);
            this.button_medicalInventory.TabIndex = 5;
            this.button_medicalInventory.Text = "Medical Inventory";
            this.button_medicalInventory.UseVisualStyleBackColor = true;
            this.button_medicalInventory.Click += new System.EventHandler(this.button_medicalInventory_Click);
            // 
            // button_dataAnalytics
            // 
            this.button_dataAnalytics.Location = new System.Drawing.Point(153, 431);
            this.button_dataAnalytics.Name = "button_dataAnalytics";
            this.button_dataAnalytics.Size = new System.Drawing.Size(212, 44);
            this.button_dataAnalytics.TabIndex = 6;
            this.button_dataAnalytics.Text = "Data Analytics";
            this.button_dataAnalytics.UseVisualStyleBackColor = true;
            this.button_dataAnalytics.Click += new System.EventHandler(this.button_dataAnalytics_Click);
            // 
            // button_chat
            // 
            this.button_chat.Location = new System.Drawing.Point(153, 290);
            this.button_chat.Name = "button_chat";
            this.button_chat.Size = new System.Drawing.Size(212, 44);
            this.button_chat.TabIndex = 7;
            this.button_chat.Text = "Real Time Chat";
            this.button_chat.UseVisualStyleBackColor = true;
            this.button_chat.Click += new System.EventHandler(this.button_chat_Click);
            // 
            // label_loginType
            // 
            this.label_loginType.AutoSize = true;
            this.label_loginType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_loginType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_loginType.Location = new System.Drawing.Point(391, 11);
            this.label_loginType.Name = "label_loginType";
            this.label_loginType.Size = new System.Drawing.Size(35, 13);
            this.label_loginType.TabIndex = 8;
            this.label_loginType.Text = "label1";
            // 
            // buttonPatientAdmission
            // 
            this.buttonPatientAdmission.Location = new System.Drawing.Point(153, 231);
            this.buttonPatientAdmission.Name = "buttonPatientAdmission";
            this.buttonPatientAdmission.Size = new System.Drawing.Size(212, 44);
            this.buttonPatientAdmission.TabIndex = 9;
            this.buttonPatientAdmission.Text = "Patient Admission and Monitor ";
            this.buttonPatientAdmission.UseVisualStyleBackColor = true;
            this.buttonPatientAdmission.Click += new System.EventHandler(this.buttonPatientAdmission_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 523);
            this.Controls.Add(this.buttonPatientAdmission);
            this.Controls.Add(this.label_loginType);
            this.Controls.Add(this.button_chat);
            this.Controls.Add(this.button_dataAnalytics);
            this.Controls.Add(this.button_medicalInventory);
            this.Controls.Add(this.button_appointment);
            this.Controls.Add(this.button_signOut);
            this.Controls.Add(this.label_greet);
            this.Controls.Add(this.button_patientManagement);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_patientManagement;
        private System.Windows.Forms.Label label_greet;
        private System.Windows.Forms.Button button_signOut;
        private System.Windows.Forms.Button button_appointment;
        private System.Windows.Forms.Button button_medicalInventory;
        private System.Windows.Forms.Button button_dataAnalytics;
        private System.Windows.Forms.Button button_chat;
        private System.Windows.Forms.Label label_loginType;
        private System.Windows.Forms.Button buttonPatientAdmission;
    }
}