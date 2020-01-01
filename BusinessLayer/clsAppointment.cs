using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointment
    {
        clsConnectorData connect;

        public List<clsPatientModel> Retrieve()
        {
            List<clsPatientModel> result = new List<clsPatientModel>();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
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
            List<clsAppointmentModel> result = new List<clsAppointmentModel>();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetAppointmentByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", selectedPatient));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(new clsAppointmentModel()
                    {
                        AppointmentId = Convert.ToInt32(item[0]),
                        HasAppointment = Convert.ToBoolean(item[1]),
                        Appointment = Convert.ToDateTime(item[2])
                    });
                }
            }

            return result;
        }

        public void DeleteByAppointmentId(int selectedAppointmentId)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.DeleteAppointmentByAppointmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@appointment", selectedAppointmentId));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }

        public void New(int patientId, DateTime newAppointment)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.InsertAppointment;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patientId", patientId));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@newAppointment", newAppointment));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
