using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Model;

namespace BusinessLayer
{
    public class clsPrescription
    {
        clsConnectorData connect;

        public clsPrescriptionModel GetByPatientId(int selectedPatient)
        {
            clsPrescriptionModel result = new clsPrescriptionModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetPrescriptionByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", selectedPatient));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {
                result = new clsPrescriptionModel()
                {
                    PrescriptionId = Convert.ToInt32(dataTable.Rows[0][0].ToString()),
                    Advise = dataTable.Rows[0][2].ToString(),
                    Prescription = dataTable.Rows[0][3].ToString()
                };
            }

            return result;
        }

        public void Update(int patientId, clsPrescriptionModel prescription)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = string.Format(clsQuery.UpdatePrescription, patientId);
            connect.cmd.Parameters.AddWithValue("@advise", prescription.Advise);
            connect.cmd.Parameters.AddWithValue("@prescription", prescription.Prescription);
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }

        public void Save(int patientId, clsPrescriptionModel prescription)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.InsertPrescription;
            connect.cmd.Parameters.AddWithValue("@pa", patientId);
            connect.cmd.Parameters.AddWithValue("@advise", prescription.Advise);
            connect.cmd.Parameters.AddWithValue("@prescription", prescription.Prescription);
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
