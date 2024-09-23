using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // This class implement the medication prescription form. It allows doctor or nurse to prescribe 
    // a new medication for a patient, change a dose or remove a medication from the patient's medication list.
    // The new medication is saved in the Medications table in database.   
    public partial class PrescriptionMedicationForm : Form
    {
        private string patientId;
        public PrescriptionMedicationForm(string patientId)
        {
            InitializeComponent();
            string[] status = { "Select Prescription", "When needed", "Daily", "Twice a day", "No longer use" };
            comboBoxStatus.DataSource = status;
            comboBoxStatus.SelectedIndex = 0;
            this.patientId = patientId;
            loadMedication();
        }

        // Helper function to upload all th medication for a particular patient
        private void loadMedication()
        {
            var context = new HospitalManagementDBEntities1();
            int pid = Int32.Parse(patientId);
            // get all the medications from Medications table for patient with PatientId == pid
            var query = from med in context.Medications where med.PatientId == pid
                        select new
                        {
                            MedicationId = med.MedicationId,
                            MedicationName = med.MedicationName,
                            Prescription = med.MedicationStatus,
                            Dose = med.Dose                       
                        };
            dataGridView1.DataSource = query.ToList(); // upload to datagridview
        }

        // Handle add button click. This function allows doctor to add new prescription
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string medicationName = textBoxMedicationName.Text;
            string dose = textBoxDose.Text;
            string status = comboBoxStatus.SelectedValue.ToString();
            int ptid = Int32.Parse(patientId);
            try
            {
                if (checkValidInput()) // input is valid
                {
                    var context = new HospitalManagementDBEntities1();

                    var newMedication = new Medication // create a new medication entry to add to Medications table
                    {
                        PatientId = ptid,
                        MedicationName = medicationName,
                        Dose = Int32.Parse(dose),
                        MedicationStatus = status,
                        PrescribedDate = DateTime.Now
                    };

                    context.Medications.Add(newMedication); // add to Medications table
                    context.SaveChanges(); // save the change to sql server
                    loadMedication(); // load the medications for the patient to datagridview
                    MessageBox.Show("Add new medication success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex);
            }
        }

        // Helper function to check for valid prescription
        private bool checkValidInput() 
        {
            bool result = true;

            if (textBoxMedicationName.Text == "")
            {
                MessageBox.Show("Please enter medication name");
                return false;
            }
            if (textBoxDose.Text == "")
            {
                MessageBox.Show("Please enter medication dose");
                return false;
            }
            return result;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Function to handle update medication
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string medicationName = textBoxMedicationName.Text;
            string dose = textBoxDose.Text;
            string medStatus = comboBoxStatus.SelectedValue.ToString();

            if (string.IsNullOrEmpty(medicationName) || string.IsNullOrEmpty(dose) || 
                string.IsNullOrEmpty(medStatus)) // check for valid input
            {
                MessageBox.Show("Please click on datagridview to select medication name, dose, and status");
                return;
            }

            try
            {
                var context = new HospitalManagementDBEntities1();
                
                int medID = Int32.Parse(labelMedicationIDValue.Text);
                // fetch the medication to be updated from sql server
                var medUpdate = context.Medications.FirstOrDefault(p => p.MedicationId == medID);

                if (medUpdate != null) // the medication is found
                {
                    // update the medication 
                    medUpdate.MedicationName = medicationName;
                    medUpdate.Dose = Int32.Parse(dose);
                    medUpdate.MedicationStatus = medStatus;

                    context.SaveChanges(); // save to sql server
                    loadMedication(); // load to the datagridview
                    MessageBox.Show("Medication updated successfully.");
                }
                else
                {
                    MessageBox.Show("You didn't update medication.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex);
            }
        }

        // Helper function to save all the selected mouse click on the datagridview.
        // Upload the selected row data to textbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMedicationName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("When needed"))
            {
                comboBoxStatus.SelectedIndex = 1;
            }
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("Daily"))
            {
                comboBoxStatus.SelectedIndex = 2;
            }
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("Twice a day"))
            {
                comboBoxStatus.SelectedIndex = 3;
            }
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("No longer use"))
            {
                comboBoxStatus.SelectedIndex = 4;
            }
            textBoxDose.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            labelMedicationIDValue.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }    
    }
}
