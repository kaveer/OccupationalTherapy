using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointment
    {
        clsConnectorData connect = new clsConnectorData();

        public List<clsPatientModel> Retrieve()
        {
            List<clsPatientModel> result = new List<clsPatientModel>();
            DataTable dataTable = new DataTable();

            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.RetrieveAppointment;
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable != null || dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    clsPatientModel patient = new clsPatientModel()
                    {
                        PatientId = Convert.ToInt32(item[1]),
                        Appointments = new List<clsAppointmentModel>()
                        {
                            new clsAppointmentModel()
                            {
                                AppointmentId = Convert.ToInt32(item[0]),
                                HasAppointment = true,
                                Appointment = Convert.ToDateTime(item[2])
                            }
                        }
                    };

                    result.Add(patient);
                }

            }

            return result;
        }

        public List<clsAppointmentModel> GetByPatientId(int selectedPatient)
        {
            throw new NotImplementedException();
        }
    }
}
