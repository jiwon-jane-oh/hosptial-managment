using Microsoft.VisualBasic.ApplicationServices;
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
    // This class implements data analytics obtained from the database.
    // This enable staffs to obtain information such as reports on patient visits,
    // common ailments, and medication usage in a given period of time.
    public partial class DataAnalyticsForm : Form
    {
        public DataAnalyticsForm()
        {
            InitializeComponent();           
            string[] searchCriteria = { "Select Criteria", "Patient visit", "Common aliments", 
                "Medication usage", "ER admission" };
            comboBoxCriteria.DataSource = searchCriteria;
            comboBoxCriteria.SelectedIndex = 0;
        }

        // Function to handle search button click
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxCriteria.SelectedIndex == 1) // Patient visit
            {
                getPatientVisit();
            }
            else if (comboBoxCriteria.SelectedIndex == 2) // Common aliments
            {
                getCommonAliments();
            }
            else if (comboBoxCriteria.SelectedIndex == 3) // Medication usage
            {
                getMedicationUsage();
            }
            else if (comboBoxCriteria.SelectedIndex == 4) // ER admission
            {
                getPatientWithERAdmission();
            }
        }

        // Helper function to obtain number of patient visited in a given period of time
        private void getPatientVisit()
        {
            var context = new HospitalManagementDBEntities1();

            DateTime startDate = dateTimePickerStartSearchDate.Value; // get start date from the date time picker
            DateTime endDate = dateTimePickerEndSearchDate.Value;     // get end date from the date time picker

            // query the Visit table in sql database to get all the visit in the given period of time
            var query = from visit in context.Visits 
                        where visit.VisitStartDate >= startDate && visit.VisitStartDate <= endDate
                        select visit;
            var visitList = query.ToList();
            var groupList = visitList.GroupBy(n => n.VisitStartDate) // group by visited date category and sort them in desending order
                         .Select(n => new
                         {
                             VisitDate = n.Key,
                             VisitCount = n.Count()
                         })
                         .OrderByDescending(n => n.VisitCount).ToList();
            dataGridView1.DataSource = groupList;
            if(groupList.Count > 0) // if there are some data, then pop up a message to display the top visit date
            {
                MessageBox.Show("The number of patient visit the most was " + groupList[0].VisitCount + 
                    " on " + groupList[0].VisitDate + " in the period from " + 
                    startDate.Date.ToString("MM/dd/yyyy") + " to " + endDate.Date.ToString("MM/dd/yyyy"));

            }
        }

        // Helper function to obtain a common ailments in a given period of time
        private void getCommonAliments()
        {
            var context = new HospitalManagementDBEntities1();

            DateTime startDate = dateTimePickerStartSearchDate.Value; // get start date from the date time picker
            DateTime endDate = dateTimePickerEndSearchDate.Value;     // get end date from the date time picker

            // query the Visit table in sql database to get all the visits in the given period of time
            var query = from visitReason in context.Visits
                        where visitReason.VisitStartDate >= startDate && visitReason.VisitStartDate <= endDate
                        select visitReason;
            var visitList = query.ToList();
            var groupList = visitList.GroupBy(n => n.VisitReason) // group by visited reason and sort them in desending order
                         .Select(n => new
                         {
                             VisitReason = n.Key,
                             NumberOfVisit = n.Count()
                         })
                         .OrderByDescending(n => n.NumberOfVisit).ToList();
            dataGridView1.DataSource = groupList;
            if (groupList.Count > 0) // if there are some data, then pop up a message to display the number of common visited reason
            {
                
                MessageBox.Show("The most common aliment by patients is " + groupList[0].VisitReason + " from " +
                    startDate.Date.ToString("MM/dd/yyyy") + " to " + endDate.Date.ToString("MM/dd/yyyy"));
            }
        }

        // Helper function to obtain a medication usage in a given period of time
        private void getMedicationUsage()
        {
            var context = new HospitalManagementDBEntities1();

            DateTime startDate = dateTimePickerStartSearchDate.Value; // get start date from the date time picker
            DateTime endDate = dateTimePickerEndSearchDate.Value;     // get end date from the date time picker

            var query = from med in context.Medications
                        where med.MedicationStatus != "No longer use" &&
                        (med.PrescribedDate >= startDate && med.PrescribedDate <= endDate)
                        select med;
            var medList = query.ToList();
            var groupList = medList.GroupBy(n => n.MedicationName) // group by medication name and sort them in desending order
                         .Select(n => new
                         {
                             MedicationName = n.Key,
                             MedicationNameCount = n.Count()
                         })
                         .OrderByDescending(n => n.MedicationNameCount).ToList();
            dataGridView1.DataSource = groupList;

            if (groupList.Count > 0) // if there are some data, then pop up a message to display the most medication prescribe for patients 
            {
                MessageBox.Show("The medication has been prescribed the most in the period from " +
                    startDate.Date.ToString("MM/dd/yyyy") + " to " + endDate.Date.ToString("MM/dd/yyyy") +
                    " is " + groupList[0].MedicationName + " by " + groupList[0].MedicationNameCount + " patients");
            }
        }

        // Helper function to obtain a er admission in a given period of time
        private void getPatientWithERAdmission()
        {
            var context = new HospitalManagementDBEntities1();

            DateTime startDate = dateTimePickerStartSearchDate.Value; // get start date from the date time picker
            DateTime endDate = dateTimePickerEndSearchDate.Value;     // get end date from the date time picker

            var query = from status in context.Visits
                        where status.PatientStatus == "ER admission" &&
                        (status.VisitStartDate >= startDate && status.VisitStartDate <= endDate)
                        select status;
            var visitList = query.ToList();
            var groupList = visitList.GroupBy(n => n.PatientStatus) // group by patient status and sort them in desending order
                         .Select(n => new
                         {
                             ERAdmission = n.Key,
                             NumERPatientCount = n.Count()
                         })
                         .OrderByDescending(n => n.NumERPatientCount).ToList();
            dataGridView1.DataSource = groupList;
            if (groupList.Count > 0)  // if there are some data, then pop up a message to display the most patients ER admitted   
            {
                MessageBox.Show("ER admission admitted during the period of " +
                    startDate.Date.ToString("MM/dd/yyyy") + " to " + endDate.Date.ToString("MM/dd/yyyy") +
                    " is " + groupList[0].NumERPatientCount + " patients");
            }
        }
    }
}
