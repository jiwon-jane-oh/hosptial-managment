using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalManagementySite
{
    public partial class PatientManagementForm : Form
    {
        IMongoCollection<User> userCollection;
        int selectedPatientId;
        DataTable dataTable = null;

        public PatientManagementForm()
        {
            InitializeComponent();
        }

        private void PatientManagementForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                var databaseName = MongoUrl.Create(connectionString).DatabaseName;
                var mongoClient = new MongoClient(connectionString);
                var database = mongoClient.GetDatabase(databaseName);
                userCollection = database.GetCollection<User>("users");


                if(LoginData.LoginUser.AccessLevel == 4)
                {
                    LoadDataForPatient();
                }
                else
                {
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}");
                Application.Exit();
            }

        }


        private void LoadDataForPatient()
        {
            try
            {
                using (var context = new HospitalManagementDBEntities1())
                {
                    // Attempt to query the database to ensure connection
                    if (!context.Database.Exists())
                    {
                        MessageBox.Show("Database connection failed. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    comboBox_uid.Items.Add(LoginData.LoginUser.UserId);
                    


                    // Query SQL Server to retrieve all patients
                    var patients = context.Patients.ToList();

                    var user = LoginData.LoginUser;
                    // Join data based on userId and prepare for DataGridView binding
                    var query = from patient in patients
                                where patient.UserId == user.UserId
                                select new
                                {
                                    PatientId = patient.PatientId,
                                    UserID = user.UserId,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    DateOfBirth = patient.DateOfBirth,
                                    Gender = patient.Gender,
                                    PhoneNumber = user.PhoneNumber,
                                    Address = patient.Address,
                                    MedicalHistory = patient.MedicalHistory
                                    // Add more fields as needed
                                };

                    // Bind the result to DataGridView
                    dataGridView1.DataSource = query.ToList();
           
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadData()
        {
            try
            {
                using (var context = new HospitalManagementDBEntities1())
                {
                    // Attempt to query the database to ensure connection
                    if (!context.Database.Exists())
                    {
                        MessageBox.Show("Database connection failed. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Query MongoDB to retrieve all users
                    var filter = Builders<User>.Filter.Eq("AccessLevel", 4);
                    var users = userCollection.Find(filter).ToList();

                    comboBox_uid.Items.Clear();

                    foreach(var user in users)
                    {
                        comboBox_uid.Items.Add(user.UserId);
                    }
            

                    // Query SQL Server to retrieve all patients
                    var patients = context.Patients.ToList();

                    // Join data based on userId and prepare for DataGridView binding
                    var query = from patient in patients
                                join user in users on patient.UserId equals user.UserId
                                select new
                                {
                                    PatientId = patient.PatientId,
                                    UserID=user.UserId,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    DateOfBirth = patient.DateOfBirth,
                                    Gender = patient.Gender,
                                    PhoneNumber = user.PhoneNumber,
                                    Address = patient.Address,
                                    MedicalHistory = patient.MedicalHistory
                                    // Add more fields as needed
                                };

                    // Bind the result to DataGridView
                    dataGridView1.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_fileSearch_Click(object sender, EventArgs e)
        {



           OpenFileDialog openFileDialog = new OpenFileDialog();
           
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath= openFileDialog.FileName;
               textBox_fileRoute.Text = filePath;
               ProcessFile(filePath);

              

            }


        }

        private void ProcessFile(string filePath)
        {
            try
            {
                string extension = Path.GetExtension(filePath).ToLower();
                string medicalHistory = string.Empty;

                MessageBox.Show(extension);
               
                switch (extension)// allow two format
                {
                    case ".txt":
                        medicalHistory = ProcessTextFile(filePath);

                     

                        richTextBox_medicalHistory.AppendText(medicalHistory);
                        break;
              
                    case ".csv":
                        medicalHistory = ProcessCsvFile(filePath);
                        dataTable = getDataFromCSV(filePath);


                        richTextBox_medicalHistory.AppendText(medicalHistory);
                        break;
                     
                    default:
                        throw new NotSupportedException("Unsupported file format");
                }

                textBox_fileRoute.Text = "";
          
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing file: {ex.Message}");
            }
        }

        private string ProcessTextFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            //if (!ValidateFileContent(lines))
            //{
            //    throw new InvalidOperationException("Invalid file content");
            //}

            StringBuilder medicalHistory = new StringBuilder();
            foreach (string line in lines)
            {
                medicalHistory.AppendLine(line);
            }
            return medicalHistory.ToString();
        }

       

        private string ProcessCsvFile(string filePath)
        {
            StringBuilder medicalHistory = new StringBuilder();
            string[] lines = File.ReadAllLines(filePath);

            if (!ValidateFileContent(lines))
            {
                throw new InvalidOperationException("Invalid file content");
            }

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');


                medicalHistory.AppendLine();
                medicalHistory.AppendLine($"Date: {values[0]}");
                medicalHistory.AppendLine($"Condition: {values[1]}");
                medicalHistory.AppendLine($"Medications: {values[2]}");
                medicalHistory.AppendLine($"Treatments: {values[3]}");
                medicalHistory.AppendLine($"Notes: {values[4]}");
                medicalHistory.AppendLine($"MedicationsDose: {values[5]}");
                medicalHistory.AppendLine($"Prescription: {values[6]}");
                medicalHistory.AppendLine(); // Blank line to separate entries
              
            }
            return medicalHistory.ToString();
        }


        private bool ValidateFileContent(string[] lines)
        {
            return lines.Any() && lines.All(line => !string.IsNullOrWhiteSpace(line));
        }


      


        private void comboBox_uid_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                // Get selected userId from ComboBox
                string selectedUserId = comboBox_uid.SelectedItem.ToString();

            // focus on the row where value of userId column == selectedUserId on datagridview1
            // 


            updateValue(selectedUserId);
              
        }

        private void updateValue(string selectedUserId)
        {
            try
            {

                
                using (var context = new HospitalManagementDBEntities1())
                {
                    // Find the patient that has the selected userId
                    var patient = context.Patients.FirstOrDefault(p => p.UserId == selectedUserId);

                    if (patient == null)
                    {
                        MessageBox.Show("No patient found with the selected user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Query MongoDB to get the user details
                    var userFilter = Builders<User>.Filter.Eq("UserId", selectedUserId);
                    var user = userCollection.Find(userFilter).FirstOrDefault();

                    if (user == null)
                    {
                        MessageBox.Show("No user found with the selected user ID in MongoDB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Set the value of patient details in the respective controls
                    comboBox_gender.SelectedItem = patient.Gender;
                    dateTimePicker_birth.Value = (DateTime)patient.DateOfBirth;

                    richTextBox_medicalHistory.Text = patient.MedicalHistory;

                    textBox_address.Text = patient.Address;






                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["UserID"].Value != null && row.Cells["UserID"].Value.ToString() == selectedUserId)
                        {
                            // Set the current cell to the first cell in the found row
                            dataGridView1.CurrentCell = row.Cells[0];
                            // Optionally, select the entire row
                            row.Selected = true;
                            // Ensure the row is visible by scrolling to it
                            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading patient details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
            private void button_save_Click(object sender, EventArgs e)
            {
                string selectedUserId = comboBox_uid.SelectedItem?.ToString();
                string gender = comboBox_gender.SelectedItem?.ToString();
                DateTime birthdate = dateTimePicker_birth.Value;
                string medicalHistory = richTextBox_medicalHistory.Text;
                string address = textBox_address.Text;

                if (string.IsNullOrEmpty(selectedUserId) || string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Please fill all required fields.");
                    return;
                }

                try
                {
                    using (var context = new HospitalManagementDBEntities1())
                    {
                    var patientToUpdate = context.Patients.FirstOrDefault(p => p.UserId == selectedUserId);
                    if (patientToUpdate != null)
                        {
                            patientToUpdate.Gender = gender;
                            patientToUpdate.DateOfBirth = birthdate;
                            patientToUpdate.Address = address;
                            patientToUpdate.MedicalHistory = medicalHistory;

                            context.SaveChanges();
                            MessageBox.Show("Patient updated successfully.");


                        if (LoginData.LoginUser.AccessLevel == 4)
                        {
                            LoadDataForPatient();
                        }
                        else
                        {
                            LoadData();
                        }

                        updateValue(selectedUserId);
                        updateMedicationHistoryUsage(patientToUpdate.PatientId);

                        }
                        else
                        {
                            MessageBox.Show("Patient not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void button_goMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper function to update medication history usage
        private void updateMedicationHistoryUsage(int patientId)
        {
            if (dataTable != null)
            {
                var context = new HospitalManagementDBEntities1();

                foreach (DataRow row in dataTable.Rows) // loop through each entry in the dataTable
                {
                    var newMedication = new Medication // make new entry for Medication table 
                    {
                        PatientId = patientId,
                        MedicationName = row["Medications"].ToString(),
                        Dose = Int32.Parse(row["MedicationsDose"].ToString()),
                        MedicationStatus = row["Prescription"].ToString(),
                        PrescribedDate = DateTime.Parse(row["PrescribedDate"].ToString())
                    };
                    context.Medications.Add(newMedication); // add new entry to table
                }
                context.SaveChanges(); // save the change to the table
                dataTable = null; // clear data table
            }

        }

        // Helper function to parse data from CSV file to DataTable format for later use
        private DataTable getDataFromCSV(string csv_file_path)
        {
            dataTable = new DataTable();
            try
            {
                string extension = System.IO.Path.GetExtension(csv_file_path).ToLower();
                if (extension.Equals(".csv"))
                {
                    using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                    {
                        // setup the delimiters fro csv reader
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        // create a string array for column field
                        string[] colFields = csvReader.ReadFields();

                        // loop to add each entry in the data
                        foreach (string colField in colFields)
                        {
                            DataColumn dataColumn = new DataColumn(colField);
                            dataTable.Columns.Add(dataColumn);

                        }
                        // loop until the data have reach to the end
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();

                            dataTable.Rows.Add(fieldData);

                        }
                    }
                }
                else // text file format
                {
                    // need to work on this format
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message.ToString());
            }

            return dataTable;
        }
    }
}
