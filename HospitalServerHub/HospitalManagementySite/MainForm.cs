using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    public partial class MainForm : Form
    {
        private HubConnection connection;
        private HubConnection connectionER;
        private HubConnection connectionCodeRed;
        private HubConnection connectionInventory;
        User currUser = LoginData.LoginUser;
        int subId = -1;
        private HospitalManagementDBEntities1 context;
        PatientERMonitorForm patientERMonitorForm = null;
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
            setLoginData();
            InitializeSignalR();
            if (currUser != null && currUser.AccessLevel < 3)
            {
                patientERMonitorForm = new PatientERMonitorForm();
                patientERMonitorForm.Show();
            }     
        }

        private void setLoginData()
        {


            context = new HospitalManagementDBEntities1();
            if (LoginData.LoginUser.AccessLevel == 1)
            {
                // Logged in user is a doctor
                // Find userId from doctor table where DoctorId = dId

                subId = context.Doctors
                                   .Where(d => d.UserId == LoginData.LoginUser.UserId)
                                   .Select(d => d.DoctorId)
                                   .FirstOrDefault();

                // Now you have the userId, you can use it as needed
            }
            else if (LoginData.LoginUser.AccessLevel == 4)
            {
                // Logged in user is a patient
                // Find userId from patient table where PatientId = pId

                subId = context.Patients
                                     .Where(p => p.UserId == LoginData.LoginUser.UserId)
                                     .Select(p => p.PatientId)
                                     .FirstOrDefault();

                // Now you have the userId, you can use it as needed
            }

        }

        // Initialize signalR communication for varies ports
        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/appointmentHub")
                   .Build();

            connectionER = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/patientER")
                   .Build();

            connectionCodeRed = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/codeRedAlert")
                   .Build();

            connectionInventory = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/inventory")
                   .Build();

            connection.On<int, int, string>("RecieveAppointmentUpdate", (doctorId, patientId, message) =>
            {
                Invoke((Action)(() =>
                {

                    //MessageBox.Show($"subId:{subId}, doctorId:{doctorId}, patientId:{patientId}");
                    if (LoginData.LoginUser.AccessLevel == 1 && doctorId == subId)
                    {
                        MessageBox.Show(message);
                    }
                    else if (LoginData.LoginUser.AccessLevel == 4 && patientId == subId)
                    {
                        MessageBox.Show(message);
                    }


                }));
            });


            try
            {
                await connection.StartAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /////////////////////////////////////////////////////////////////////
            // Recieve ER update. When a patient's status is updated,
            // the signal is sent to update the patient ER monitor system within the hospital.
            // All responsible personels such as doctors and nurses would be able to view the 
            // updated ER patient's status.
            connectionER.On<string>("RecieveERUpdate", (message) =>
            {
                Invoke((Action)(() =>
                {
                    if (patientERMonitorForm != null)
                    {
                        Invoke(new Action(() => patientERMonitorForm.UpdateView()));
                    }
                }));
            });

            try
            {
                await connectionER.StartAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //////////////////////////////////////////////////////////////////////
            // Recieve the code red alert. When a patient is in critial conditions
            // such as body temperature or heart rate elevated. When the SignalR
            // is received on this port, a code red alert message will be popped up
            // if doctors or nurses are login into the system.
            connectionCodeRed.On<string>("ReceiveCodeRedMessage", (message) =>
            {
                Invoke((Action)(() =>
                {
                    if(patientERMonitorForm != null)
                    {
                        Invoke(new Action(() => patientERMonitorForm.PostCodeRed(message)));
                    }
                    
                }));
            });

            try
            {
                await connectionCodeRed.StartAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /////////////////////////////////////////////////////////////////////
            // Recieve alert for low inventory. When the system detects a low inventory for 
            // certain item, it will send an alert to responsible personel (staff).
            connectionInventory.On<string>("ReceiveInventoryMessage", (message) =>
            {
                if (currUser.AccessLevel == 3)
                {
                    Invoke((Action)(() =>
                    {
                        string sms = "Message for " + currUser.FirstName + " " + currUser.LastName + ": " + message;
                        Invoke(new Action(() => MessageBox.Show(sms)));
                    }));
                }
            });

            try
            {
                await connectionInventory.StartAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeForm()
        {


            button_dataAnalytics.Visible = currUser.AccessLevel != 4;
            button_medicalInventory.Visible = currUser.AccessLevel != 4;

            string type;
            switch (currUser.AccessLevel)
            {
                case 1:
                    type = "doctor";
                    break;
                case 2:
                    type = "nurse";
                    break;
                case 3:
                    type = "staff";
                    break;

                default:
                    type = "patient";
                    break;


            }
            label_loginType.Text = $"[{type}]";

            label_greet.Text = $"Hello, {currUser.FirstName} !";

        }

        private void button_appointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();

            appointmentForm.Show();
            //this.Hide();
        }

        private void button_patientManagement_Click(object sender, EventArgs e)
        {

            PatientManagementForm patientManagementForm = new PatientManagementForm();

            patientManagementForm.Show();
            //this.Hide();

        }

        private void button_signOut_Click(object sender, EventArgs e)
        {
            LoginData.LoginUser = null;

            MessageBox.Show("Logout successfully!");
            LoginForm2 loginForm = new LoginForm2();
            loginForm.Show();
            if (patientERMonitorForm != null)
            {
                patientERMonitorForm.Close();
                patientERMonitorForm = null;
            }
            this.Hide();
        }

        // Function to handle medical inventory button. 
        // This allows staffs to view inventory items, add new supply items, remove an inventory items,
        // update (consume or refill hospital supplies)
        // and send alert to appropriate staffs if a supply item is low.
        private void button_medicalInventory_Click(object sender, EventArgs e)
        {
            if (currUser.AccessLevel > 3) // only users such as doctors, nurses, and staffs are able to access this function
            {
                MessageBox.Show("Only doctor, nurse, and staff are allowed to manage medical inventory");
            }
            else
            {
                MedicalInventoryForm medicalInventoryForm = new MedicalInventoryForm(currUser);
                medicalInventoryForm.Show();
            }
        }

        // Function to handle patient admission button. The function allows staffs in the hospital
        // to admit a new patient, update status such as vital sign, prescribe or change medications
        // and change a status of a patient in hospital.
        private void buttonPatientAdmission_Click(object sender, EventArgs e)
        {
            if (currUser.AccessLevel > 3)
            {
                MessageBox.Show("Only doctor, nurse, and staff can admit patient");
            }
            else
            {
                PatientAdmissionForm patientAdmissionForm = new PatientAdmissionForm(currUser);
                patientAdmissionForm.Show();
            }
        }

        // Function to handle data analytics button. This allows staffs in the systems to run
        // data analysis to obtain information such as reports on patient visits,
        // common ailments, medication usage, and ER's patient admission in a given period of time.
        private void button_dataAnalytics_Click(object sender, EventArgs e)
        {
            if (currUser.AccessLevel > 3)
            {
                MessageBox.Show("Only staff can run this option");
            }
            else
            {
                DataAnalyticsForm dataAnalyticsForm = new DataAnalyticsForm();
                dataAnalyticsForm.Show();
            }
        }

        // Function to allow communiation between all users in the hospital using signalR
        private void button_chat_Click(object sender, EventArgs e)
        {
            ChatSystemForm chatSystemForm = new ChatSystemForm(currUser);
            chatSystemForm.Show();
            chatSystemForm.Text = currUser.LastName + ", " + currUser.FirstName; 
        }
    }
}
