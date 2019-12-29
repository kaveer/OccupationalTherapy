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
    }
}
