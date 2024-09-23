namespace HospitalManagementySite
{
    partial class AppointmentForm
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
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.entityCommand2 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label_doctorId = new System.Windows.Forms.Label();
            this.label_note = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_patientId = new System.Windows.Forms.Label();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_refreash = new System.Windows.Forms.Button();
            this.labelforPatient = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(107, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(586, 157);
            this.dataGridView1.TabIndex = 1;
            // 
            // entityCommand2
            // 
            this.entityCommand2.CommandTimeout = 0;
            this.entityCommand2.CommandTree = null;
            this.entityCommand2.Connection = null;
            this.entityCommand2.EnablePlanCaching = true;
            this.entityCommand2.Transaction = null;
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(150, 247);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(227, 21);
            this.comboBoxDoctor.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(466, 201);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(150, 288);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // label_doctorId
            // 
            this.label_doctorId.AutoSize = true;
            this.label_doctorId.Location = new System.Drawing.Point(105, 250);
            this.label_doctorId.Name = "label_doctorId";
            this.label_doctorId.Size = new System.Drawing.Size(39, 13);
            this.label_doctorId.TabIndex = 6;
            this.label_doctorId.Text = "Doctor";
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Location = new System.Drawing.Point(109, 291);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(30, 13);
            this.label_note.TabIndex = 8;
            this.label_note.Text = "Note";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(424, 204);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(30, 13);
            this.label_date.TabIndex = 9;
            this.label_date.Text = "Date";
            // 
            // label_patientId
            // 
            this.label_patientId.AutoSize = true;
            this.label_patientId.Location = new System.Drawing.Point(95, 204);
            this.label_patientId.Name = "label_patientId";
            this.label_patientId.Size = new System.Drawing.Size(49, 13);
            this.label_patientId.TabIndex = 11;
            this.label_patientId.Text = "PatientId";
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(150, 201);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(227, 21);
            this.comboBoxPatient.TabIndex = 10;
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(180, 415);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(136, 33);
            this.button_submit.TabIndex = 12;
            this.button_submit.Text = "Make Appointment";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(322, 415);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(136, 33);
            this.button_update.TabIndex = 15;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            // 
            // button_refreash
            // 
            this.button_refreash.Location = new System.Drawing.Point(699, 161);
            this.button_refreash.Name = "button_refreash";
            this.button_refreash.Size = new System.Drawing.Size(75, 23);
            this.button_refreash.TabIndex = 17;
            this.button_refreash.Text = "refreash";
            this.button_refreash.UseVisualStyleBackColor = true;
            // 
            // labelforPatient
            // 
            this.labelforPatient.AutoSize = true;
            this.labelforPatient.ForeColor = System.Drawing.Color.Red;
            this.labelforPatient.Location = new System.Drawing.Point(164, 271);
            this.labelforPatient.Name = "labelforPatient";
            this.labelforPatient.Size = new System.Drawing.Size(0, 13);
            this.labelforPatient.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(475, 415);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(136, 33);
            this.button_cancel.TabIndex = 20;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelforPatient);
            this.Controls.Add(this.button_refreash);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label_patientId);
            this.Controls.Add(this.comboBoxPatient);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.label_doctorId);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.comboBoxDoctor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand2;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label_doctorId;
        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_patientId;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_refreash;
        private System.Windows.Forms.Label labelforPatient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_cancel;
    }
}