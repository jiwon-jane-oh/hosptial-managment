namespace HospitalManagementySite
{
    partial class VitalSignsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUpdateVitalSigns = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHeartRate = new System.Windows.Forms.TextBox();
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.textBoxBloodPressure = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Patient\'s Vital Signs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonExit);
            this.groupBox1.Controls.Add(this.buttonUpdateVitalSigns);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxHeartRate);
            this.groupBox1.Controls.Add(this.textBoxTemperature);
            this.groupBox1.Controls.Add(this.textBoxBloodPressure);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(43, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 275);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vital Signs";
            // 
            // buttonUpdateVitalSigns
            // 
            this.buttonUpdateVitalSigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateVitalSigns.Location = new System.Drawing.Point(33, 214);
            this.buttonUpdateVitalSigns.Name = "buttonUpdateVitalSigns";
            this.buttonUpdateVitalSigns.Size = new System.Drawing.Size(146, 49);
            this.buttonUpdateVitalSigns.TabIndex = 6;
            this.buttonUpdateVitalSigns.Text = "Update Vital Signs";
            this.buttonUpdateVitalSigns.UseVisualStyleBackColor = true;
            this.buttonUpdateVitalSigns.Click += new System.EventHandler(this.buttonUpdateVitalSigns_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Blood Pressure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Heart Rate";
            // 
            // textBoxHeartRate
            // 
            this.textBoxHeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHeartRate.Location = new System.Drawing.Point(167, 52);
            this.textBoxHeartRate.Name = "textBoxHeartRate";
            this.textBoxHeartRate.Size = new System.Drawing.Size(100, 26);
            this.textBoxHeartRate.TabIndex = 1;
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTemperature.Location = new System.Drawing.Point(167, 162);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.Size = new System.Drawing.Size(100, 26);
            this.textBoxTemperature.TabIndex = 3;
            // 
            // textBoxBloodPressure
            // 
            this.textBoxBloodPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBloodPressure.Location = new System.Drawing.Point(167, 105);
            this.textBoxBloodPressure.Name = "textBoxBloodPressure";
            this.textBoxBloodPressure.Size = new System.Drawing.Size(100, 26);
            this.textBoxBloodPressure.TabIndex = 2;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(195, 214);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(146, 49);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // VitalSignsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "VitalSignsForm";
            this.Text = "VitalSignsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUpdateVitalSigns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHeartRate;
        private System.Windows.Forms.TextBox textBoxTemperature;
        private System.Windows.Forms.TextBox textBoxBloodPressure;
        private System.Windows.Forms.Button buttonExit;
    }
}