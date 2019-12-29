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
    public class clsPatientDetails
    {
        clsConnectorData connect = new clsConnectorData();

        public clsPatientDetailsModel GetDetailsByPatientId(int patientId)
        {
            clsPatientDetailsModel result = new clsPatientDetailsModel();
            DataTable dataTable = new DataTable();

            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetPatientDetailsByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", patientId));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable != null || dataTable.Rows.Count > 0)
            {
                result = new clsPatientDetailsModel()
                {
                    Name = dataTable.Rows[0][1].ToString(),
                    Surname = dataTable.Rows[0][2].ToString(),
                    Tel = dataTable.Rows[0][3].ToString(),
                    Mobile1 = dataTable.Rows[0][4].ToString(),
                    Mobile2 = dataTable.Rows[0][5].ToString(),
                    DOB = string.IsNullOrWhiteSpace(dataTable.Rows[0][6].ToString())? DateTime.Now: Convert.ToDateTime(dataTable.Rows[0][6].ToString()),
                    Age = string.IsNullOrWhiteSpace(dataTable.Rows[0][7].ToString())? 0: Convert.ToInt32(dataTable.Rows[0][7].ToString()),
                    Occupation = dataTable.Rows[0][8].ToString()
                };
            }

            return result;
        }
    }
}
