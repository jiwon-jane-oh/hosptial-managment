namespace HospitalManagementySite
{
    partial class PatientManagementForm
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
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_fileRoute = new System.Windows.Forms.TextBox();
            this.richTextBox_medicalHistory = new System.Windows.Forms.RichTextBox();
            this.button_fileSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_birth = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_uid = new System.Windows.Forms.ComboBox();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.button_goMain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(711, 450);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_fileRoute
            // 
            this.textBox_fileRoute.Location = new System.Drawing.Point(162, 293);
            this.textBox_fileRoute.Name = "textBox_fileRoute";
            this.textBox_fileRoute.Size = new System.Drawing.Size(204, 20);
            this.textBox_fileRoute.TabIndex = 7;
            // 
            // richTextBox_medicalHistory
            // 
            this.richTextBox_medicalHistory.Location = new System.Drawing.Point(162, 319);
            this.richTextBox_medicalHistory.Name = "richTextBox_medicalHistory";
            this.richTextBox_medicalHistory.Size = new System.Drawing.Size(423, 145);
            this.richTextBox_medicalHistory.TabIndex = 8;
            this.richTextBox_medicalHistory.Text = "";
            // 
            // button_fileSearch
            // 
            this.button_fileSearch.Location = new System.Drawing.Point(372, 290);
            this.button_fileSearch.Name = "button_fileSearch";
            this.button_fileSearch.Size = new System.Drawing.Size(75, 23);
            this.button_fileSearch.TabIndex = 9;
            this.button_fileSearch.Text = "Find";
            this.button_fileSearch.UseVisualStyleBackColor = true;
            this.button_fileSearch.Click += new System.EventHandler(this.button_fileSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "UID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Gender:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 13;
            // 
            // dateTimePicker_birth
            // 
            this.dateTimePicker_birth.Location = new System.Drawing.Point(162, 239);
            this.dateTimePicker_birth.Name = "dateTimePicker_birth";
            this.dateTimePicker_birth.Size = new System.Drawing.Size(204, 20);
            this.dateTimePicker_birth.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(115, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 135);
            this.dataGridView1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date Of Birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Medical Record File ( txt/csv)";
            // 
            // comboBox_uid
            // 
            this.comboBox_uid.FormattingEnabled = true;
            this.comboBox_uid.Location = new System.Drawing.Point(162, 192);
            this.comboBox_uid.Name = "comboBox_uid";
            this.comboBox_uid.Size = new System.Drawing.Size(204, 21);
            this.comboBox_uid.TabIndex = 18;
            this.comboBox_uid.SelectedIndexChanged += new System.EventHandler(this.comboBox_uid_SelectedIndexChanged);
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox_gender.Location = new System.Drawing.Point(162, 217);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(204, 21);
            this.comboBox_gender.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Address";
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(162, 267);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(204, 20);
            this.textBox_address.TabIndex = 21;
            // 
            // button_goMain
            // 
            this.button_goMain.Location = new System.Drawing.Point(630, 450);
            this.button_goMain.Name = "button_goMain";
            this.button_goMain.Size = new System.Drawing.Size(75, 23);
            this.button_goMain.TabIndex = 22;
            this.button_goMain.Text = "Exit";
            this.button_goMain.UseVisualStyleBackColor = true;
            this.button_goMain.Click += new System.EventHandler(this.button_goMain_Click);
            // 
            // PatientManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.button_goMain);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_gender);
            this.Controls.Add(this.comboBox_uid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker_birth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_fileSearch);
            this.Controls.Add(this.richTextBox_medicalHistory);
            this.Controls.Add(this.textBox_fileRoute);
            this.Controls.Add(this.button_save);
            this.Name = "PatientManagementForm";
            this.Text = "PatinetManagementForm";
            this.Load += new System.EventHandler(this.PatientManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_fileRoute;
        private System.Windows.Forms.RichTextBox richTextBox_medicalHistory;
        private System.Windows.Forms.Button button_fileSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birth;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_uid;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Button button_goMain;
    }
}