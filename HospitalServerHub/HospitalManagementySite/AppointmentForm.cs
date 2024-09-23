using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace HospitalManagementySite
{
    public partial class AppointmentForm : Form
    {
        private HospitalManagementDBEntities1 context;
        private HubConnection connection;
        private int subId;

        public AppointmentForm()
        {
            InitializeComponent();
            context = new HospitalManagementDBEntities1();
            InitializeSignalR();
            
            //
            setLoginData();

            if (LoginData.LoginUser.AccessLevel != 4)
            {
                LoadPatients();
                LoadDoctors();
            }
            LoadAppointment();

        }

        private void setLoginData()
        {


            if (LoginData.LoginUser.AccessLevel == 1)
            {
                // Logged in user is a doctor
                // Find userId from doctor table where DoctorId = dId

                subId = context.Doctors
                                   .Where(d => d.UserId== LoginData.LoginUser.UserId)
                                   .Select(d => d.DoctorId)
                                   .FirstOrDefault();


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
                comboBoxDoctor.Visible = false;
                comboBoxPatient.Visible = false;
                richTextBox1.Visible = false;

                monthCalendar1.Visible = false;
                label_date.Visible = false;
                label_doctorId.Visible = false;
                label_patientId.Visible = false;
                label_note.Visible = false;


                button_update.Visible = false;
                button_submit.Visible = false;

                labelforPatient.Text = "** Please contact to staff if you need to make or change your appointment ";

            }

        }

        //}
        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                   .WithUrl("http://localhost:5041/appointmentHub")
                   .Build();






            try
            {
                await connection.StartAsync();
                //   MessageBox.Show("Connection to the hub was successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SendAppointmentUpdate(int doctorId, int patientId, string message)
        {
            try
            {
                await connection.InvokeAsync("SendAppointmentUpdate", doctorId, patientId, message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending appointment update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatients()
        {
            if (LoginData.LoginUser.AccessLevel == 4)
            {
                comboBoxPatient.Items.Add(subId);

            }
            else
            {
                // Load patients into comboBoxPatient
                var patients = context.Patients.Select(p => new { p.PatientId }).ToList();
                comboBoxPatient.DataSource = patients;
                comboBoxPatient.DisplayMember = "PatientId";
                comboBoxPatient.ValueMember = "PatientId";
            }


        }

        private void LoadDoctors()
        {
            // Load patients into comboBoxPatient
            var doctors = context.Doctors.Select(p => new { p.DoctorId }).ToList();
            comboBoxDoctor.DataSource = doctors;

            comboBoxDoctor.DisplayMember = "DoctorId";
            comboBoxDoctor.ValueMember = "DoctorId";
        }





        private void LoadAppointment()
        {
            using (var context = new HospitalManagementDBEntities1())
            {


                if (LoginData.LoginUser.AccessLevel == 4)
                {
                    ///get appointments where appointments patient id =subId
                    ///
                    var appointments = context.Appointments
                                        .Where(a => a.PatientId == subId)
                                        .Select(a => new { a.AppointmentId, a.PatientId, a.DoctorId,a.AppointmentDate, a.Status, a.Description }).ToList();

                    dataGridView1.DataSource = appointments;
                }
                else if (LoginData.LoginUser.AccessLevel == 1)
                {
                    ///get appointments where appointments doctor id =subId 
                    ///
                    var appointments = context.Appointments
                                         .Where(a => a.DoctorId == subId)
                                         .Select(a => new { a.AppointmentId, a.PatientId, a.DoctorId, a.AppointmentDate, a.Status, a.Description }).ToList();
                    dataGridView1.DataSource = appointments;
                }
                else
                {
                    //get all appointment list
                    var  appointments = context.Appointments.ToList();
                    dataGridView1.DataSource = appointments;

                }

            }
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
                try
                {

                // Validate selected items
                if (comboBoxPatient.SelectedItem == null)
                {
                    MessageBox.Show("Please select a patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxDoctor.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int patientId = Convert.ToInt32(comboBoxPatient.SelectedValue);
                int doctorId = Convert.ToInt32(comboBoxDoctor.SelectedValue);
                var newAppointment = new Appointment
                {
                    PatientId = patientId,
                    DoctorId = doctorId,
                    AppointmentDate = monthCalendar1.SelectionStart,
                    Status = "Scheduled",
                    Description = richTextBox1.Text,
                };

                context.Appointments.Add(newAppointment);

                context.SaveChanges();
                MessageBox.Show("Appointment saved successfully.");

                // SignalR code to notify about appointment update
                SendAppointmentUpdate(doctorId,patientId,"appointment created!");
                LoadAppointment();
                }
                catch (DbEntityValidationException ex)
                {
                    // Display validation errors
                    StringBuilder sb = new StringBuilder();
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            sb.AppendLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                    MessageBox.Show($"Validation errors:\n{sb.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        
        
        
        private void button_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected appointmentId
                int selectedAppointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AppointmentId"].Value);
                int currPatientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientId"].Value);
                int currDoctorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientId"].Value);

                // Validate selected items
                if (comboBoxPatient.SelectedItem == null)
                {
                    MessageBox.Show("Please select a patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxDoctor.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int patientId = Convert.ToInt32(comboBoxPatient.SelectedValue);
                int doctorId = Convert.ToInt32(comboBoxDoctor.SelectedValue);


                // Find the selected appointment in the context
                var appointmentToUpdate = context.Appointments.FirstOrDefault(a => a.AppointmentId == selectedAppointmentId);
                if (appointmentToUpdate != null)
                {
                    // Update the appointment details
                    appointmentToUpdate.PatientId = patientId;
                    appointmentToUpdate.DoctorId = doctorId;
                    appointmentToUpdate.AppointmentDate = monthCalendar1.SelectionStart;
                    appointmentToUpdate.Description = richTextBox1.Text;
                    appointmentToUpdate.Status = "Sheduled";

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Appointment updated successfully.");

                        // SignalR code to notify about appointment update
                        SendAppointmentUpdate(doctorId, patientId, "your appointment schedule updated!");





                        LoadAppointment();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Appointment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select the appointment you want to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_refreash_Click(object sender, EventArgs e)
        {
            LoadAppointment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected appointmentId
                int selectedAppointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AppointmentId"].Value);

                // Find the selected appointment in the context
                var appointmentToCancel = context.Appointments.FirstOrDefault(a => a.AppointmentId == selectedAppointmentId);
                if (appointmentToCancel != null)
                {
                    try
                    {
                        int patientId = Convert.ToInt32(comboBoxPatient.SelectedValue);
                        int doctorId = Convert.ToInt32(comboBoxDoctor.SelectedValue);


                        // Remove the appointment from the context
                        context.Appointments.Remove(appointmentToCancel);
                        context.SaveChanges();
                        MessageBox.Show("Appointment canceled successfully.");

                        // SignalR code to notify about appointment cancellation
                        SendAppointmentUpdate(doctorId, patientId, "Appointment canceled!");
                        LoadAppointment();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error canceling appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Appointment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select the appointment you want to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
