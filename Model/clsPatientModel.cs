using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class clsPatientModel
    {
        public int PatientId { get; set; }
        public clsPatientDetailsModel PatientDetails { get; set; }
        public clsPatientMedicalRecordModel MedicalRecords { get; set; }
        public clsPrescriptionModel Prescription { get; set; }
        public List<clsAppintmentModel> AppointmentAndDate { get; set; }
        public clsDateEntryModel DateEntry { get; set; }
        public List<clsAssessmentModel> Assessment { get; set; }

    }

    public class clsPatientDetailsModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
    }

    public class clsPatientMedicalRecordModel
    {
        public int MedicalId { get; set; }
        public string Diagnosis { get; set; }
        public string BriefHistory { get; set; }
        public string PastMedicalHistory { get; set; }
        public bool Swelling { get; set; }
        public bool Tenderness { get; set; }
        public bool Sensation { get; set; }
        public string SensationDetails { get; set; }
    }

    public class clsPrescriptionModel
    {
        public int PrescriptionId { get; set; }
        public string Advise { get; set; }
        public string Prescription { get; set; }
    }


}
