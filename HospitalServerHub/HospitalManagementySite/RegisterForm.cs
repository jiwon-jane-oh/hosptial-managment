using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Numerics;


namespace HospitalManagementySite
{
    public partial class RegisterForm : Form
    {

        IMongoCollection<User> userCollection;
        IMongoCollection<Doctor> doctorCollection;
        IMongoCollection<Patient> patientCollection;
        string selectedType;

        public RegisterForm()
        {
            InitializeComponent();



            //hide combobox for doctor expertise
            comboBox_doctorExpertise.Visible = false;
            labelExpertise.Visible = false;



        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                var databaseName = MongoUrl.Create(connectionString).DatabaseName;
                var mongoClient = new MongoClient(connectionString);
                var database = mongoClient.GetDatabase(databaseName);
                userCollection = database.GetCollection<User>("users");
                doctorCollection = database.GetCollection<Doctor>("doctors");

               patientCollection = database.GetCollection<Patient>("patients");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}");
                Application.Exit();
            }

        }

        private void comboBox_roleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = comboBox_roleType.SelectedItem.ToString();
            labelExpertise.Visible = selectedType == "doctor";
            comboBox_doctorExpertise.Visible = selectedType == "doctor";
        }
        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox_username.Text) ||
                string.IsNullOrWhiteSpace(textBox_password.Text) ||
                string.IsNullOrWhiteSpace(textBox_email.Text) ||
                string.IsNullOrWhiteSpace(selectedType))
            {
                MessageBox.Show("Please enter all required information!");
                return false;
            }

            if (selectedType == "doctor" && (comboBox_doctorExpertise.SelectedItem == null || string.IsNullOrWhiteSpace(comboBox_doctorExpertise.SelectedItem.ToString())))
            {
                MessageBox.Show("Please select expertise!");
                comboBox_doctorExpertise.Focus();
                return false;
            }

            return true;
        }

        private bool DoesUserExist(string username)
        {
            var filter = Builders<User>.Filter.Eq("Username", username);
            return userCollection.Find(filter).Any();
        }

        private int GetAccessLevel(string role)
        {
            switch (role)
            {
                case "doctor":
                    return 1;
                case "nurse":
                    return 2;
                case "staff":
                    return 3;
                default://patients
                    return 4;
            }
        }


        private void button_submit_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                return;
            }

            string username = textBox_username.Text;
            string password = textBox_password.Text;
            string email = textBox_email.Text;
            string role = selectedType;
            string firstname = textBox_firstname.Text;
            string lastname = textBox_lastname.Text;
            string phone = textBox_phone.Text;
            string expertise = role == "doctor" ? comboBox_doctorExpertise.SelectedItem.ToString() : string.Empty;

            if (DoesUserExist(username))
            {
                MessageBox.Show("Username already exists, please choose a different one.");
                return;
            }

            try
            {
                var user = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    FirstName = firstname,
                    LastName = lastname,
                    PhoneNumber = phone,
                    Email = email,
                    AccessLevel = GetAccessLevel(role),
                   
                };

                
                userCollection.InsertOne(user);

                //  insert data to patient or doctor table if selected type is patient or doctor with userId
                InsertRoleSpecificData(user);
                LoginForm2 loginForm = new LoginForm2();
                loginForm.Show();
                this.Hide();

                MessageBox.Show("Sign Up Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sign up: {ex.Message}");
            }
        }

        private void InsertRoleSpecificData(User user)
        {
            try
            {

                if (user.AccessLevel == 1) // Doctor collectin in MongoDB
                {

                    using (var context = new HospitalManagementDBEntities1())
                    {

                        var newDoctor = new Doctor
                        {
                            UserId = user.UserId,
                            Expertise = comboBox_doctorExpertise.SelectedItem.ToString()


                        };

                        context.Doctors.Add(newDoctor);
                        context.SaveChanges();

                    }

                }
                else if (user.AccessLevel == 4) // Patient table in SQL Server 
                {
                    using (var context = new HospitalManagementDBEntities1())
                    {

                        var newPatient = new Patient
                        {
                            UserId = user.UserId,
                            DateOfBirth= DateTime.Now,
                            Gender="",
                            Address="",
                            MedicalHistory=""

                            
                        };

                        context.Patients.Add(newPatient);
                        context.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting role-specific data: {ex.Message}");
            }
        }

        private void button_goMain_Click(object sender, EventArgs e)
        {

          
              
                LoginForm2 loginForm = new LoginForm2();
                loginForm.Show();
                this.Hide();
            
        }
    }




}
