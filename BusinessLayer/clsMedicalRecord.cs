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
    public class clsMedicalRecord
    {
        clsConnectorData connect;

        public clsPatientMedicalRecordModel GetByPatientId(int selectedPatient)
        {
            clsPatientMedicalRecordModel result = new clsPatientMedicalRecordModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetMedicalRecordByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", selectedPatient));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable != null || dataTable.Rows.Count > 0)
            {
                result = new clsPatientMedicalRecordModel()
                {
                    MedicalId = Convert.ToInt32(dataTable.Rows[0][0].ToString()),
                    Diagnosis = dataTable.Rows[0][2].ToString(),
                    BriefHistory = dataTable.Rows[0][3].ToString(),
                    PastMedicalHistory = dataTable.Rows[0][4].ToString(),
                    Swelling = Convert.ToBoolean(dataTable.Rows[0][5].ToString()),
                    Tenderness = Convert.ToBoolean(dataTable.Rows[0][6].ToString()),
                    Sensation = Convert.ToBoolean(dataTable.Rows[0][7].ToString()),
                    SensationDetails = dataTable.Rows[0][8].ToString(),
                };
            }

            return result;
        }

        public void Update(int patientId, clsPatientMedicalRecordModel medicalRecords)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = string.Format(clsQuery.UpdateMedicalRecord, patientId);
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@diag", medicalRecords.Diagnosis));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@bh", medicalRecords.BriefHistory));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@pmh", medicalRecords.PastMedicalHistory));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@swel", medicalRecords.Swelling));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ten", medicalRecords.Tenderness));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@sen", medicalRecords.Sensation));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@sendet", medicalRecords.SensationDetails));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
