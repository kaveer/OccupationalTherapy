using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class clsAppointmentAndDateModel
    {
       
    }

    public class clsAppointmentModel
    {
        public int AppointmentId { get; set; }
        public bool HasAppointment { get; set; }
        public DateTime Appointment { get; set; }
    }
    public class clsDateEntryModel
    {
        public int EntryId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
