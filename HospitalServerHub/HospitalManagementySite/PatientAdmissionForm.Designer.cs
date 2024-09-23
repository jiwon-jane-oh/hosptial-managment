namespace HospitalManagementySite
{
    partial class PatientAdmissionForm
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
            this.buttonTriagePatient = new System.Windows.Forms.Button();
            this.buttonUpdatePatientStatus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSearchCriteria = new System.Windows.Forms.ComboBox();
            this.textBoxSearchInput = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelSearchText = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxPatientId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPatientStatus = new System.Windows.Forms.ComboBox();
            this.buttonPatientTreatment = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonVital = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTriagePatient
            // 
            this.buttonTriagePatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTriagePatient.Location = new System.Drawing.Point(21, 121);
            this.buttonTriagePatient.Name = "buttonTriagePatient";
            this.buttonTriagePatient.Size = new System.Drawing.Size(121, 47);
            this.buttonTriagePatient.TabIndex = 10;
            this.buttonTriagePatient.Text = "Triage Patient";
            this.buttonTriagePatient.UseVisualStyleBackColor = true;
            this.buttonTriagePatient.Click += new System.EventHandler(this.buttonTriagePatient_Click);
            // 
            // buttonUpdatePatientStatus
            // 
            this.buttonUpdatePatientStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdatePatientStatus.Location = new System.Drawing.Point(417, 117);
            this.buttonUpdatePatientStatus.Name = "buttonUpdatePatientStatus";
            this.buttonUpdatePatientStatus.Size = new System.Drawing.Size(130, 54);
            this.buttonUpdatePatientStatus.TabIndex = 14;
            this.buttonUpdatePatientStatus.Text = "Update Patient Status";
            this.buttonUpdatePatientStatus.UseVisualStyleBackColor = true;
            this.buttonUpdatePatientStatus.Click += new System.EventHandler(this.buttonUpdatePatientStatus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxSearchCriteria);
            this.groupBox1.Controls.Add(this.textBoxSearchInput);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.labelSearchText);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 489);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 177);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Patients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Search Criteria";
            // 
            // comboBoxSearchCriteria
            // 
            this.comboBoxSearchCriteria.FormattingEnabled = true;
            this.comboBoxSearchCriteria.Location = new System.Drawing.Point(41, 72);
            this.comboBoxSearchCriteria.Name = "comboBoxSearchCriteria";
            this.comboBoxSearchCriteria.Size = new System.Drawing.Size(200, 28);
            this.comboBoxSearchCriteria.TabIndex = 6;
            this.comboBoxSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchCriteria_SelectedIndexChanged);
            // 
            // textBoxSearchInput
            // 
            this.textBoxSearchInput.Location = new System.Drawing.Point(312, 74);
            this.textBoxSearchInput.Name = "textBoxSearchInput";
            this.textBoxSearchInput.Size = new System.Drawing.Size(122, 26);
            this.textBoxSearchInput.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(188, 117);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(111, 49);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelSearchText
            // 
            this.labelSearchText.AutoSize = true;
            this.labelSearchText.Location = new System.Drawing.Point(320, 42);
            this.labelSearchText.Name = "labelSearchText";
            this.labelSearchText.Size = new System.Drawing.Size(102, 20);
            this.labelSearchText.TabIndex = 2;
            this.labelSearchText.Text = "Date Of Birth";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1044, 427);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBoxPatientId
            // 
            this.textBoxPatientId.Location = new System.Drawing.Point(21, 76);
            this.textBoxPatientId.Name = "textBoxPatientId";
            this.textBoxPatientId.Size = new System.Drawing.Size(112, 26);
            this.textBoxPatientId.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "PatientID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonVital);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxPatientStatus);
            this.groupBox2.Controls.Add(this.buttonPatientTreatment);
            this.groupBox2.Controls.Add(this.buttonUpdatePatientStatus);
            this.groupBox2.Controls.Add(this.buttonTriagePatient);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxPatientId);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(589, 489);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 177);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Triage and Treatment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Patient Status";
            // 
            // comboBoxPatientStatus
            // 
            this.comboBoxPatientStatus.FormattingEnabled = true;
            this.comboBoxPatientStatus.Location = new System.Drawing.Point(175, 74);
            this.comboBoxPatientStatus.Name = "comboBoxPatientStatus";
            this.comboBoxPatientStatus.Size = new System.Drawing.Size(256, 28);
            this.comboBoxPatientStatus.TabIndex = 19;
            // 
            // buttonPatientTreatment
            // 
            this.buttonPatientTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPatientTreatment.Location = new System.Drawing.Point(285, 119);
            this.buttonPatientTreatment.Name = "buttonPatientTreatment";
            this.buttonPatientTreatment.Size = new System.Drawing.Size(113, 49);
            this.buttonPatientTreatment.TabIndex = 18;
            this.buttonPatientTreatment.Text = "Patient\'s Treatment";
            this.buttonPatientTreatment.UseVisualStyleBackColor = true;
            this.buttonPatientTreatment.Click += new System.EventHandler(this.buttonPatientTreatment_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(504, 705);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(111, 49);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonVital
            // 
            this.buttonVital.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVital.Location = new System.Drawing.Point(157, 117);
            this.buttonVital.Name = "buttonVital";
            this.buttonVital.Size = new System.Drawing.Size(113, 49);
            this.buttonVital.TabIndex = 19;
            this.buttonVital.Text = "Patient Vital";
            this.buttonVital.UseVisualStyleBackColor = true;
            this.buttonVital.Click += new System.EventHandler(this.buttonVital_Click);
            // 
            // PatientAdmissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 797);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PatientAdmissionForm";
            this.Text = "PatientAdmissionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTriagePatient;
        private System.Windows.Forms.Button buttonUpdatePatientStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSearchInput;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelSearchText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxPatientId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonPatientTreatment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPatientStatus;
        private System.Windows.Forms.ComboBox comboBoxSearchCriteria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonVital;
        //private System.Windows.Forms.Button buttonPatientVital;
    }
}