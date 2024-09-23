using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementySite
{
    public class PatientInformation
    {
        public int PatientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PatientStatus { get; set; }




        public List<PatientInformation> getPatients()
        {
            List<PatientInformation> patientInfoList = new List<PatientInformation>();
            var context = new HospitalManagementDBEntities1();

            IMongoCollection<User> userColl = GetUserCollection();
            var filter = Builders<User>.Filter.Empty;
            var users = userColl.Find(filter).ToList();
            var patients = context.Patients.ToList();
            var query = from patient in patients
                        join user in users on patient.UserId equals user.UserId
                        select new
                        {
                            PatientId = patient.PatientId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Username = user.Username,
                            DateOfBirth = patient.DateOfBirth,
                            Gender = patient.Gender,
                            PhoneNumber = user.PhoneNumber,
                            Email = user.Email,
                            PatientStatus = ""
                        };
            foreach (var patient in query)
            {
                string status = getPatientStatus(Int32.Parse(patient.PatientId.ToString()));
                PatientInformation patientInfo = new PatientInformation();
                patientInfo.PatientId = patient.PatientId;
                patientInfo.Firstname = patient.FirstName;
                patientInfo.Lastname = patient.LastName;
                patientInfo.Username = patient.Username;
                patientInfo.DateOfBirth = DateTime.Parse(patient.DateOfBirth.ToString());
                patientInfo.Gender = patient.Gender;
                patientInfo.PhoneNumber = patient.PhoneNumber;
                patientInfo.Email = patient.Email;
                patientInfo.PatientStatus = status;
                patientInfoList.Add(patientInfo);
            }
            return patientInfoList;
        }

        public IMongoCollection<User> GetUserCollection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            return database.GetCollection<User>("users");
        }

        public string getPatientStatus(int patientId)
        {
            string patientStatus = "N/A";
            var context = new HospitalManagementDBEntities1();

            var query = from visit in context.Visits
                        where visit.PatientId == patientId
                        select new
                        {
                            PatientId = visit.PatientId,
                            VisitEndDate = visit.VisitEndDate,
                            PatientStatus = visit.PatientStatus
                        };
            foreach (var visit in query)
            {
                string endDate = visit.VisitEndDate.ToString();
                if (endDate == "")
                {
                    patientStatus = visit.PatientStatus;
                }
            }
            return patientStatus;
        }

        public List<PatientInformation> GetPatientInTriage()
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();

            foreach (PatientInformation patient in patientInfo)
            {
                if (patient.PatientStatus == "Triage")
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public List<PatientInformation> GetPatientInER()
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();

            foreach (PatientInformation patient in patientInfo)
            {
                if (patient.PatientStatus == "ICU" ||
                    patient.PatientStatus == "ER admission")
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public List<PatientInformation> GetPatientByDOB(string DOB)
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();
            string dateOfBirth = DateTime.Parse(DOB).ToString("MM/dd/yyyy");
            foreach (PatientInformation patient in patientInfo)
            {
                string dob = patient.DateOfBirth.ToString("MM/dd/yyyy");
                if (dob == dateOfBirth)
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public List<PatientInformation> GetPatientByLastName(string lastName)
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();

            foreach (PatientInformation patient in patientInfo)
            {
                if (patient.Lastname == lastName)
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public List<PatientInformation> GetPatientByFirstName(string firstName)
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();

            foreach (PatientInformation patient in patientInfo)
            {
                if (patient.Firstname == firstName)
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public List<PatientInformation> GetPatientMedication(string medName)
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            var context = new HospitalManagementDBEntities1();
            List<PatientInformation> result = new List<PatientInformation>();
            foreach (PatientInformation patient in patientInfo)
            {
                var query = from med in context.Medications
                            where med.PatientId == patient.PatientId && med.MedicationName == medName
                            select new
                            {
                                PatientId = med.PatientId,
                                MedicationName = med.MedicationName
                            };

                if (query.Count() > 0)
                {
                    result.Add(patient);
                }
            }
            return result;
        }
        // common aliment 
        public List<PatientInformation> GetPatientDischarged()
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> patientInfo = patientInformation.getPatients();
            List<PatientInformation> result = new List<PatientInformation>();

            foreach (PatientInformation patient in patientInfo)
            {
                if (patient.PatientStatus == "Discharged")

                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public string getPatientName(int patientId)
        {
            IMongoCollection<User> userColl = GetUserCollection();

            var context = new HospitalManagementDBEntities1();
            var filter = Builders<User>.Filter.Empty;
            var users = userColl.Find(filter).ToList();
            var patients = context.Patients.ToList();
            string patientName = "";
            var query = from patient in patients
                        join user in users on patient.UserId equals user.UserId
                        select new
                        {
                            PatientId = patient.PatientId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Username = user.Username,
                            DateOfBirth = patient.DateOfBirth,
                            Gender = patient.Gender,
                            PhoneNumber = user.PhoneNumber,
                            Email = user.Email,
                            PatientStatus = ""
                        };
            if (query.Count() > 0)
            {
                patientName = query.First().FirstName + " " + query.First().LastName;
            }
            return patientName;
        }

        public int getPatientVisitID(int patientID)
        {
            int visitId = -1;
            var context = new HospitalManagementDBEntities1();

            var visit = context.Visits.FirstOrDefault(p => p.PatientId == patientID && p.VisitEndDate == null);

            if (visit != null)
            {
                visitId = visit.VisitId;
            }
            return visitId;
        }
    }
}
