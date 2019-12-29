using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class clsQuery
    {
        public static string RetrieveAppointment = "SELECT Appointment.PatientId, Appointment.AppointmentDate FROM Appointment WHERE Format(Appointment.AppointmentDate,\"MM/DD/YYYY\")=Date();";
    }
}
