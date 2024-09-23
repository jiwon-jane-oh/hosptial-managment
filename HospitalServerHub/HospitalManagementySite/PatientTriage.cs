using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // Class to implement patient triage. This form allows staff to admit a patient to hospital,
    // update patient's status, and take vital signs.
    public partial class PatientTriage : Form
    {
        private HospitalManagementDBEntities1 context;
        private User staff;
        private HubConnection connectionER;
        private string patientId;
        public PatientTriage(User staff, string patientId)
        {
            InitializeComponent();
            InitializeSignalR();
            string[] visitReasons = {"Select Visit Reason","Stomach and abdominal pain", "Chest pain", "Fever",
                                       "Cough", "Shortness of breath", "Broken bones",
                                        "Fainting", "Fever with a rash", "Seizures", "Head or eye injury"};
            comboBoxVisitReason.DataSource = visitReasons;
            comboBoxVisitReason.SelectedIndex = 0;

            string[] patientStatus = {"Select Patient Status", "Triage", "Regular admission", "ER admission" ,"Inpatient care", 
                "ICU", "Inpatient rehabilitation facility (IRF)", "Discharged"};


            comboBoxPatientStatus.DataSource = patientStatus;
            comboBoxPatientStatus.SelectedIndex = 0;

            this.staff = staff;
            this.patientId = patientId;
            groupBoxVisitInfo.Text = "Visit info for patient: " + patientId;
            context = new HospitalManagementDBEntities1();
        }

        // Function to handle button submit. This will save patient's status and allow staff to take
        // and record patient's vital signs. Send signalR to update patients in ER.
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBoxVisitReason.SelectedIndex == 0)
            {
                MessageBox.Show("Please select visit reason.");
            }
            else if (comboBoxPatientStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please select patient's status.");
            }
            else
            {
                var context = new HospitalManagementDBEntities1();
                // create new visit entry for visit table
                var newVisit = new Visit
                {
                    PatientId = Int32.Parse(patientId),
                    StaffId = staff.UserId,
                    VisitReason = comboBoxVisitReason.SelectedValue.ToString(),
                    VisitStartDate = DateTime.Now,
                    VisitEndDate = null,
                    PatientStatus = comboBoxPatientStatus.SelectedValue.ToString()
                };

                context.Visits.Add(newVisit); // add new visit entry to Visits table
                context.SaveChanges(); // update the sql server
                VitalSignsForm vitalSignsForm = new VitalSignsForm(newVisit.VisitId.ToString());
                vitalSignsForm.Show(); // pop up the vital sign form 
                SendPatientERUpdate("Update patient ER"); // send signalR to update patient in ER
                MessageBox.Show("Update patient triage success");                                       
            }
        }

        // Intialzied signalR to communicate via patientER port
        private async void InitializeSignalR()
        {
            connectionER = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/patientER")
                   .Build();
            try
            {
                await connectionER.StartAsync();
                //   MessageBox.Show("Connection to the hub was successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Send message so that patient in ER status board can be updated
        private async void SendPatientERUpdate(string message)
        {
            try
            {
                await connectionER.InvokeAsync("SendMessage", message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending ER update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
