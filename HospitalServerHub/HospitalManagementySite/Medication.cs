//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagementySite
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medication
    {
        public int MedicationId { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationStatus { get; set; }
        public Nullable<int> Dose { get; set; }
        public Nullable<System.DateTime> PrescribedDate { get; set; }
    }
}
