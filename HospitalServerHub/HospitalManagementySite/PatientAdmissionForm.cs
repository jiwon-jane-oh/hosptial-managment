using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HospitalManagementySite.HospitalManagementDBDataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalManagementySite
{
    // Class to implement the functions that allow staffs in the hospital
    // to admit a new patient, update status such as vital sign, prescribe or change medications
    // and change a status of a patient in hospital. The class also allows user to search for 
    // patient with searching criteria such as  "All Patients", "Patients by birthday", "Patients by lastname", 
    // "Patients by firstname","Patients in triage", "Patients in ER", "Patients use medicaton", "Discharged patients"
    public partial class PatientAdmissionForm : Form
    {
        private User user; // staff
        private string currentSearchingCriteria = "";
        private HubConnection connectionER;

        public PatientAdmissionForm(User user)
        {
            InitializeComponent();
            InitializeSignalR();


            this.user = user;
            string[] patientStatus = {"Select Patient Status", "Triage", "Admission", "ER admission", "Inpatient care",
                "ICU", "Inpatient rehabilitation facility (IRF)", "Discharged"};
            comboBoxPatientStatus.DataSource = patientStatus;
            comboBoxPatientStatus.SelectedIndex = 0;

            string[] searchPatientCriteria = {"All Patients", "Patients by birthday", "Patients by lastname", "Patients by firstname",
                "Patients in triage", "Patients in ER", "Patients use medicaton", "Discharged patients"};
            comboBoxSearchCriteria.DataSource = searchPatientCriteria;
            comboBoxSearchCriteria.SelectedIndex = 0;
            labelSearchText.Text = "All Patients";
        }

        // Function to triage a patient. It just admit a new patient from the list of patients from datagridview.
        // Or if staff know the patient ID, they can enter directly from the textbox.
        private void buttonTriagePatient_Click(object sender, EventArgs e)
        {
            string patientID = textBoxPatientId.Text;
            
            if (patientID != "") // valid patient ID
            {
                if (!isPatientAdmitted(patientID)) // check if the patient has been triaged
                {
                    PatientTriage patientTriage = new PatientTriage(user, patientID);
                    patientTriage.Show();
                }
                else
                {
                    MessageBox.Show("The patient has already been triage.");
                }
            }
            else
            {
                MessageBox.Show("Please select a patient from datagridview to triage");
            }

        }


        // Function to handle search button to load patients to datagridview
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        // Helper function to load patients to datagridview with selected criteria
        private void loadDataGrid()
        {
            PatientInformation patientInformation = new PatientInformation();
            if (comboBoxSearchCriteria.SelectedIndex == 0) // all patient
            {
                dataGridView1.DataSource = patientInformation.getPatients();
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 1) // patient by birthday
            {
                dataGridView1.DataSource = patientInformation.GetPatientByDOB(textBoxSearchInput.Text);
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 2) // search by lastname
            {
                if (textBoxSearchInput.Text == "")
                {
                    MessageBox.Show("Please enter last name");
                }
                else
                {
                    dataGridView1.DataSource = patientInformation.GetPatientByLastName(textBoxSearchInput.Text);
                }
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 3) // search by firstName
            {
                if (textBoxSearchInput.Text == "")
                {
                    MessageBox.Show("Please enter first name");
                }
                else
                {
                    dataGridView1.DataSource = patientInformation.GetPatientByFirstName(textBoxSearchInput.Text);
                }
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 4) // search by triage
            {
                if (textBoxSearchInput.Text == "")
                {
                    MessageBox.Show("Please enter triage");
                }
                else
                {                   
                    dataGridView1.DataSource = patientInformation.GetPatientInTriage();
                }
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 5) // search by ICU or ER admission
            {
                dataGridView1.DataSource = patientInformation.GetPatientInER();
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 6) // search my medication
            {
                if (textBoxSearchInput.Text == "")
                {
                    MessageBox.Show("Please enter medication name");
                }
                else
                {
                    dataGridView1.DataSource = patientInformation.GetPatientMedication(textBoxSearchInput.Text);
                }
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 7) // search by discharged
            {
                dataGridView1.DataSource = patientInformation.GetPatientDischarged();
            }
        }

        // Intialized signalR to allow live update patient's status in ER
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

        // Send update signal to update patient's status in ER monitor 
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

        // Function to handle update patient status
        private void buttonUpdatePatientStatus_Click(object sender, EventArgs e)
        {
            string patientStatus = comboBoxPatientStatus.SelectedValue.ToString();
            string patientId = textBoxPatientId.Text;

            if (string.IsNullOrEmpty(patientStatus) || string.IsNullOrEmpty(patientId))
            {
                MessageBox.Show("Please click on combobox to selectpatient status and " +
                    "click on datagridview to select patientId to update.");
                return;
            }

            try
            {
                var context = new HospitalManagementDBEntities1();
                
                int pid = Int32.Parse(patientId);
                var statusUpdate = context.Visits.FirstOrDefault(p => p.PatientId == pid && p.VisitEndDate == null);

                if (statusUpdate != null) // found the patient to be updated
                {
                    statusUpdate.PatientStatus = patientStatus; // set the status 
                    if (patientStatus == "Discharged") // patient discharged
                    {
                        statusUpdate.VisitEndDate = DateTime.Now; // set the end date field 
                    }

                    context.SaveChanges(); // save to database
                    loadDataGrid(); // load the datagridview
                    MessageBox.Show("Status updated successfully.");
                    SendPatientERUpdate("Update patient ER"); // send message to Update patient in ER
                }
                else
                {
                    MessageBox.Show("Patient has not been admitted yet.");
                }
                             
            }           
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex);
            }

        }

        // Handle datagridview cell content click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // upload patient ID to patient Id textbox 
            textBoxPatientId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        // Function to handle patient treatment button click. This allows doctor to prescribe 
        // medication to patient
        private void buttonPatientTreatment_Click(object sender, EventArgs e)
        {
            string patientID = textBoxPatientId.Text;
            if (patientID != "") // patient selected
            {
                if (isPatientAdmitted(patientID))
                {
                    PatientInformation patientInformation = new PatientInformation();
                    PrescriptionMedicationForm pres = new PrescriptionMedicationForm(patientID);
                    pres.Text = "Medication treatment for: " + patientInformation.getPatientName(Int32.Parse(patientID));
                    pres.Show(); // show PrescriptionMedicationForm
                }
                else
                {
                    MessageBox.Show("Patient has not been admitted yet.");
                }
            }
            else
            {
                MessageBox.Show("Please select a patient for treatment.");
            }
            
        }        

        // Helper function to check if patient has been admitted to the hospital 
        private bool isPatientAdmitted(string patientId)
        {
            var context = new HospitalManagementDBEntities1();
            
            int pid = Int32.Parse(patientId);
            var visit = context.Visits.FirstOrDefault(p => p.PatientId == pid && 
            (p.PatientStatus != "N/A" && p.PatientStatus != "Discharged"));

            if (visit != null)
            {
                return true;
            }
            else
            {
                return false;               
            }        
        }      

        // Function to handle search criteria combobox 
        private void comboBoxSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchCriteria.SelectedIndex == 0)
            {
                labelSearchText.Text = "All Patients";
                textBoxSearchInput.Text = "*";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 1)
            {
                labelSearchText.Text = "Birthday";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 2)
            {
                labelSearchText.Text = "Lastname";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 3)
            {
                labelSearchText.Text = "Firstname";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 4)
            {
                labelSearchText.Text = "Textbox not use";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 5)
            {
                labelSearchText.Text = "Textbox not use";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 6)
            {
                labelSearchText.Text = "Medication name";
            }
            else if (comboBoxSearchCriteria.SelectedIndex == 7)
            {
                labelSearchText.Text = "Textbox not use";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Function to handle Vital button click. This allows staff to record the patient's vital sign
        private void buttonVital_Click(object sender, EventArgs e)
        {
            string patientID = textBoxPatientId.Text;
            if (patientID != "") // patient ID is selected
            {
                if (isPatientAdmitted(patientID)) // patient must be admitted or triaged
                {
                    PatientInformation patientInformation = new PatientInformation();
                    // get visit ID for the patient
                    int vID = patientInformation.getPatientVisitID(Int32.Parse(patientID));
                    if (vID >= 0)
                    {
                        VitalSignsForm vitalSignsForm = new VitalSignsForm(vID.ToString());
                        vitalSignsForm.Show(); // go to the vitalSigns form to collect patient's vital signs
                    }
                    else
                    {
                        // shouldn't be here
                        MessageBox.Show("Stop to debug.");
                    }
                }
                else
                {
                    MessageBox.Show("The patient need to be triaged first.");
                }
            }
            else
            {
                MessageBox.Show("Please select a patient from datagridview to update vital sign.");
            }
        }
    }
}
