using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class clsQuery
    {
        public static string RetrieveAppointment = "SELECT * FROM Appointment";
        public static string GetPatientDetailsByPatientId = "SELECT * FROM PatientDetails pd WHERE pd.PatientId = @patient";
        public static string GetDateEntryByPatientId = "SELECT EntryId, PatientId, EntryDate FROM DateEntry WHERE(PatientId = @patient) ORDER BY EntryDate";
        public static string GetMedicalRecordByPatientId = "SELECT MedicalRecord.* FROM MedicalRecord WHERE(PatientId = @patient)";
        public static string GetPrescriptionByPatientId = "SELECT Prescription.* FROM Prescription WHERE(PatientId = @patient)";
        public static string GetAppointmentByPatientId = "SELECT Appointment.* FROM Appointment WHERE(PatientId =  @patient)";
        public static string GetAssessementEntryByPatientId = "SELECT Assessment.* AS Expr1 FROM Assessment WHERE(PatientId = @patient)";
    }
}
