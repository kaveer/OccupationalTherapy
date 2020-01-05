using System;
using System.Data;
using DataLayer;
using Model;

namespace BusinessLayer
{
    public class clsDateEntry
    {
        clsConnectorData connect;

        public clsDateEntryModel GetbyPatientId(int selectedPatient)
        {
            clsDateEntryModel result = new clsDateEntryModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetDateEntryByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", selectedPatient));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {
                result = new clsDateEntryModel()
                {
                    EntryId = Convert.ToInt32(dataTable.Rows[0][0].ToString()),
                    EntryDate = string.IsNullOrWhiteSpace(dataTable.Rows[0][2].ToString()) ? DateTime.Now : Convert.ToDateTime(dataTable.Rows[0][2].ToString()),
                };
            }

            return result;
        }

        public void Save(int patientId, clsDateEntryModel dateEntry)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.InsertDateEntry;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@pa", patientId));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@da", dateEntry.EntryDate));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
