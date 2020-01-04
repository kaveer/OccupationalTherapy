using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class clsQuery
    {
        /// <summary>
        /// select statemet
        /// </summary>
        public static string RetrieveAppointment = "SELECT * FROM Appointment";
        public static string RetrievePatientDetails = "SELECT * FROM PatientDetails";
        public static string GetPatientDetailsByPatientId = "SELECT * FROM PatientDetails pd WHERE pd.PatientId = @patient";
        public static string GetDateEntryByPatientId = "SELECT EntryId, PatientId, EntryDate FROM DateEntry WHERE(PatientId = @patient) ORDER BY EntryDate";
        public static string GetMedicalRecordByPatientId = "SELECT MedicalRecord.* FROM MedicalRecord WHERE(PatientId = @patient)";
        public static string GetPrescriptionByPatientId = "SELECT Prescription.* FROM Prescription WHERE(PatientId = @patient)";
        public static string GetAppointmentByPatientId = "SELECT Appointment.* FROM Appointment WHERE(PatientId =  @patient)";
        public static string GetAssessementEntryByPatientId = "SELECT Assessment.* AS Expr1 FROM Assessment WHERE(PatientId = @patient)";
        public static string GetAssessementEntryByAssessmentId;

        /// <summary>
        /// Delete statement
        /// </summary>
        public static string DeleteAppointmentByAppointmentId = "DELETE * FROM Appointment WHERE (AppointmentId = @appointment)";
        public static string DeleteAssessmentByAssessmentId = "DELETE * FROM Assessment WHERE (AssessementId = @assessment)";
        public static string DeleteAssessmentDetailsByAssessmentId = "DELETE * FROM AssessmentDetails WHERE (AssessmentId = @assessment)";

        /// <summary>
        /// Insert statement
        /// </summary>
        public static string InsertAppointment = "INSERT INTO Appointment(PatientId, AppointmentDate) VALUES(@patientId, @newAppointment)";

        /// <summary>
        /// Update statement
        /// </summary>
        public static string UpdatePatientDetails = "UPDATE PatientDetails SET Name = @na, Surname = @sur, Tel = @tel, Mobile1 = @mob1, Mobile2 = @mob2, DOB = @dob, Age = @age, Occupation = @occup WHERE PatientId = {0}";
        public static string UpdateMedicalRecord = "UPDATE MedicalRecord SET Diagnosis = @diag, BriefHistory = @bh, PastMedicalHistory = @pmh, Swelling = @swel, Tenderness = @ten, Sensation = @sen, SensationDetails = @sendet WHERE PatientId = {0}";
        public static string UpdatePrescription = "UPDATE Prescription SET Advise = @advise, Prescription = @prescription WHERE PatientId = {0}";
        public static string SaveAssessmentDetails;
        public static string GetAssessementDetailsByAssessmentId;
    }
}
