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
    public class clsAssessment
    {
        clsConnectorData connect;

        public List<clsAssessmentModel> GetByPatientId(int selectedPatient)
        {

            List<clsAssessmentModel> result = new List<clsAssessmentModel>();
            result = GetAssessmentEntry(selectedPatient);

            return result;
        }

        private List<clsAssessmentModel> GetAssessmentEntry(int selectedPatient)
        {
            List<clsAssessmentModel> result = new List<clsAssessmentModel>();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetAssessementEntryByPatientId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", selectedPatient));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(new clsAssessmentModel()
                    {
                        AssessementId = Convert.ToInt32(item[0]),
                        AssessmentDate = Convert.ToDateTime(item[2])
                    });
                }
            }

            return result;
        }

        public void DeleteByAssessmentId(int selectedAssessmentId)
        {
            DeleteAssessmentEntry(selectedAssessmentId);
            DeletelAssessmentDetails(selectedAssessmentId);
        }

        private void DeleteAssessmentEntry(int selectedAssessmentId)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.DeleteAssessmentByAssessmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assessment", selectedAssessmentId));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }

        private void DeletelAssessmentDetails(int selectedAssessmentId)
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.DeleteAssessmentDetailsByAssessmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assessment", selectedAssessmentId));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }

        public List<clsAssessmentModel> GetDetailsByAssessmentId(int assessmentId)
        {
            throw new NotImplementedException();
        }
    }
}
