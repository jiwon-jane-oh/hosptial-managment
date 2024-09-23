using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementySite
{
    public class PatientWithVital
    {
        public int PatientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public string DateTaken { get; set; }

        public List<PatientWithVital> getPatientInER()
        {
            PatientInformation patientInformation = new PatientInformation();
            List<PatientInformation> erPatients = patientInformation.GetPatientInER();

            List<PatientWithVital> result = new List<PatientWithVital>();

            foreach (PatientInformation patient in erPatients)
            {
                int visitId = patientInformation.getPatientVisitID(patient.PatientId);
                if (visitId > 0)
                {
                    VitalSign vitalSign = getLastVitalSign(visitId);
                    if (vitalSign != null)
                    {
                        PatientWithVital patientWithVital = new PatientWithVital();
                        patientWithVital.PatientId = patient.PatientId;
                        patientWithVital.Firstname = patient.Firstname;
                        patientWithVital.Lastname = patient.Lastname;
                        patientWithVital.HeartRate = vitalSign.HeartRate.ToString();
                        patientWithVital.BloodPressure = vitalSign.BloodPressure;
                        patientWithVital.Temperature = vitalSign.Temperature.ToString();
                        patientWithVital.DateTaken = DateTime.Parse(vitalSign.TimeTaken.ToString()).ToString("MM/dd/yyyy");
                        result.Add(patientWithVital);
                    }
                }               
            }
            return result;
        }

        private VitalSign getLastVitalSign(int visitId)
        {
            VitalSign vitalSign = null;

            var context = new HospitalManagementDBEntities1();

            var query = from vital in context.VitalSigns
                        where vital.VisitId == visitId
                        select vital;

            var vitalList = query.ToList().OrderByDescending(n => n.VitalId).ToList();
            if (vitalList.Count > 0)
            {
                return vitalList[0];
            }

            return vitalSign;
        }
    }
}
