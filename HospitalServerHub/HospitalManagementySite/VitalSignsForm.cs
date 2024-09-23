using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // This class implements vital signs form that allows user to take and record
    // patient's vital sign. If the vital signs meet a critical condition, it will 
    // send code red message to doctors and nurses
    public partial class VitalSignsForm : Form
    {
        private string visitId;
        private HospitalManagementDBEntities1 context;
        private HubConnection connectionCodeRed;
        private HubConnection connectionER;
        private const int CRITICAL_CONDITION_HIGH_HEARTRATE = 150;
        private const int CRITICAL_CONDITION_LOW_HEARTRATE = 40;
        private const int CRITICAL_CONDITION_FOR_HIGH_FEVER = 110;

        public VitalSignsForm(string visitId)
        {
            InitializeComponent();
            InitializeSignalR();
            this.visitId = visitId;
            context = new HospitalManagementDBEntities1();
        }

        // This function handle vital signs update button click
        private void buttonUpdateVitalSigns_Click(object sender, EventArgs e)
        {
            if (checkDataValidty()) // check for the valid input
            {
                int heartRate = Int32.Parse(textBoxHeartRate.Text);
                string bloodPressure = textBoxBloodPressure.Text;
                decimal temperature = Convert.ToDecimal(textBoxTemperature.Text);

                var context = new HospitalManagementDBEntities1();
                

                var newVital = new VitalSign // create a new vital sign entry
                {
                    VisitId = Int32.Parse(visitId),
                    HeartRate = heartRate,
                    BloodPressure = bloodPressure,
                    Temperature = temperature,
                    TimeTaken = DateTime.Now                                      
                };

                context.VitalSigns.Add(newVital); // add the new entry to the VitalSigns tables
                context.SaveChanges(); // upddate the sql server
                MessageBox.Show("Update patient's vital success");

                SendPatientERUpdate("Update patient ER"); // send the signalR to update the patient's status in ER board
                
                // check if the patient is in critical condition
                if (heartRate > CRITICAL_CONDITION_HIGH_HEARTRATE || 
                    heartRate < CRITICAL_CONDITION_LOW_HEARTRATE || 
                    temperature > CRITICAL_CONDITION_FOR_HIGH_FEVER)
                {
                    int vID = Int32.Parse(visitId); // get visit id for the patient in critical condition
                    var visit = context.Visits.FirstOrDefault(p => p.VisitId == vID);
                    if (visit != null)
                    {
                        // send code red alert
                        SendPatientCodeRedAlert("CODE RED ALERT: Patient " + visit.PatientId.ToString() + 
                            " is in critical condition!!! All available staffs please come to assist the patient!");
                    }
                }               
            }
        }

        // Helper function to check for valid input
        private bool checkDataValidty()
        {
            bool result = true;

            if (textBoxHeartRate.Text == "")
            {
                MessageBox.Show("Please enter heart rate.");
                return false;
            }
            if (textBoxBloodPressure.Text == "")
            {
                MessageBox.Show("Please enter blood pressure.");
                return false;
            }
            if (textBoxTemperature.Text == "")
            {
                MessageBox.Show("Please enter temperature.");
                return false;
            }
            return result;
        }

        // Set up signalR to communicate via two ports codeRedAlert and patientER
        private async void InitializeSignalR()
        {
            connectionCodeRed = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/codeRedAlert")
                   .Build();

            connectionER = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/patientER")
                   .Build();

            // connectionCodeRed
            try
            {
                await connectionCodeRed.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // connectionER
            try
            {
                await connectionER.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper function to send code red alert
        private async void SendPatientCodeRedAlert(string message)
        {
            try
            {
                await connectionCodeRed.InvokeAsync("SendCodeRedMessage", message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending code red alert: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper function to send patient ER update
        private async void SendPatientERUpdate(string message)
        {
            try
            {
                await connectionER.InvokeAsync("SendMessage", message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending code red alert: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
