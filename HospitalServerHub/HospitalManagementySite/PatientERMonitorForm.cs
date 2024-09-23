using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // Class to implement PatientERMonitorForm to allow doctors and nurses to 
    // monitor patients' status in ER. It is also a place where code red messages
    // are posted. The information in this monitor are updated live whenever a
    // patient's status is changed or there is a patient in critical condition
    public partial class PatientERMonitorForm : Form
    {
        public PatientERMonitorForm()
        {
            InitializeComponent();
            PatientWithVital patientWithVital = new PatientWithVital();
            dataGridView1.DataSource = patientWithVital.getPatientInER();
        }

        // Update the datagridview when signalR is recevied
        public void UpdateView()
        {
            PatientWithVital patientWithVital = new PatientWithVital();
            dataGridView1.DataSource = patientWithVital.getPatientInER();
        }

        // Post code red alert message when signalR is recevied
        public void PostCodeRed(string message)
        {
            listBoxCodeRed.Items.Add(message);
        }
    }
}
