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
        clsConnectorData connect;

        public clsPatientDetailsModel GetByPatientId(int patientId)
        {
            clsPatientDetailsModel result = new clsPatientDetailsModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
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

        public List<clsPatientModel> Retrieve()
        {
            List<clsPatientModel> result = new List<clsPatientModel>();
            clsPatientModel data = new clsPatientModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.RetrievePatientDetails;
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable != null || dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    data = new clsPatientModel()
                    {
                        PatientId = Convert.ToInt32(item[0]),
                        PatientDetails = new clsPatientDetailsModel()
                        {
                            Name = item[1].ToString(),
                            Surname = item[2].ToString(),
                            Tel = item[3].ToString(),
                            Mobile1 = item[4].ToString(),
                            Mobile2 = item[5].ToString(),
                            DOB = string.IsNullOrWhiteSpace(item[6].ToString()) ? DateTime.Now : Convert.ToDateTime(item[6].ToString()),
                            Age = string.IsNullOrWhiteSpace(item[7].ToString()) ? 0 : Convert.ToInt32(item[7].ToString()),
                            Occupation = item[8].ToString()
                        }
                    };

                    result.Add(data);
                }
            }

            return result;
        }

        public void Update(int patientId, clsPatientDetailsModel patientDetails)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = string.Format(clsQuery.UpdatePatientDetails, patientId);
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@sur", patientDetails.Surname));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@na", patientDetails.Name));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@tel", patientDetails.Tel));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@mob1", patientDetails.Mobile1));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@mob2", patientDetails.Mobile2));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@dob", patientDetails.DOB));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@age", patientDetails.Age));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@occup", patientDetails.Occupation));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }

        public int Save(clsPatientDetailsModel patientDetails)
        {
            int patientId = 0;

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.InsertPatientDetails;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@na", patientDetails.Name));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@sur", patientDetails.Surname));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@tel", patientDetails.Tel));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@mob1", patientDetails.Mobile1));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@mob2", patientDetails.Mobile2));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@dob", patientDetails.DOB));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@age", patientDetails.Age));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@occup", patientDetails.Occupation));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();

            patientId = GetMaxPatientId();
            if (patientId ==0)
                throw new Exception("Unable to save patient Id");

            return patientId;
        }

        private int GetMaxPatientId()
        {
            int result = 0;
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.PatientDetailsSelectMaxPatientId;
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
                result = Convert.ToInt32(dataTable.Rows[0][0]);

            return result;
        }
    }
}
