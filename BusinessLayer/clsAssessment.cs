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

        private clsPatientModel GetByAssessmentId(int assessmentId)
        {
            clsPatientModel result = new clsPatientModel();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetAssessementEntryByAssessmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assessment", assessmentId));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {

                result.PatientId = Convert.ToInt32(dataTable.Rows[0][1]);
                result.Assessment = new List<clsAssessmentModel>()
                {
                    new clsAssessmentModel()
                    {
                        AssessementId = Convert.ToInt32(dataTable.Rows[0][0]),
                        AssessmentDate = Convert.ToDateTime(dataTable.Rows[0][2])
                    }
                };
            }

            return result;
        }

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
            List<clsAssessmentModel> result = new List<clsAssessmentModel>();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetAssessementDetailsByAssessmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", assessmentId));
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(dataTable);
            connect.con.Close();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    clsAssessmentModel data = new clsAssessmentModel()
                    {
                        AssessmentDetailsId = Convert.ToInt32(item[0]),
                        AssessementId = Convert.ToInt32(item[1]),
                    };

                    ProcessAssessmentDetails(data, item);
                }
            }

            return result;
        }

        private void ProcessAssessmentDetails(clsAssessmentModel data, DataRow item)
        {
            
        }

        public void Update(int assessmentId, List<clsAssessmentModel> assessment)
        {
            if (assessment.Count == 0)
                return;

            var patientIdAssessment = GetByAssessmentId(assessmentId);
            if (patientIdAssessment.PatientId == 0)
                return;

            DeleteByAssessmentId(assessmentId);
            Save(patientIdAssessment.PatientId, assessment);

        }

        public void Save(int patientId, List<clsAssessmentModel> assessment)
        {
            int assessmentId = SaveAssessmentEntry(patientId, assessment);
            if (assessmentId != 0)
                SaveAssessmentDetails(assessmentId, assessment);
        }

        private int SaveAssessmentEntry(int patientId, List<clsAssessmentModel> assessment)
        {
            int result = 0;

            foreach (var item in assessment)
            {
                connect = new clsConnectorData();
                connect.Link();
                connect.con.Open();
                connect.cmd.CommandText = clsQuery.DeleteAssessmentByAssessmentId;
                connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", patientId));
                connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", item.AssessmentDate));
                connect.cmd.ExecuteNonQuery();
                connect.con.Close();

                if (GetByPatientId(patientId).Count == 0)
                    return result;

                var mentByPatientId = GetByPatientId(patientId)
                                .OrderByDescending(x =>x.AssessementId)
                                .First();

                if (mentByPatientId != null)
                    result = mentByPatientId.AssessementId;
            }

            return result;
        }

        private void SaveAssessmentDetails(int assessmentId, List<clsAssessmentModel> assessment)
        {
            foreach (var item in assessment)
            {
                SaveUpperJoint(assessmentId, item.UpperJoint);
                SaveLowerJoint(assessmentId, item.LowerJoint);
                SaveOtherAssessment(assessmentId, item.OtherAssessment);
            }
        }

        private void SaveUpperJoint(int assessmentId, clsUpperJointModel upperJoint)
        {
            foreach (var item in upperJoint.Shoulder.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Shoulder.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.ElbowAndForemarm.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.ElbowAndForemarm.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.Wrist.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Wrist.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.Thumb.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Thumb.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.IndexFinger.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.IndexFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.MiddleFinger.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.MiddleFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.RingFinger.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.RingFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in upperJoint.LittleFinger.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.LittleFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }
        }

        private void SaveLowerJoint(int assessmentId, clsLowerJointModel lowerJoint)
        {
            foreach (var item in lowerJoint.Ankle.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Ankle.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in lowerJoint.Hip.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Hip.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }

            foreach (var item in lowerJoint.Knee.MotionValue)
            {
                if (string.IsNullOrWhiteSpace(item.LeftValue) || string.IsNullOrWhiteSpace(item.RightValue))
                    continue;

                SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Knee.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
            }
        }

        private void SaveOtherAssessment(int assessmentId, clsOtherAssessmentModel otherAssessment)
        {
            if (string.IsNullOrWhiteSpace(otherAssessment.OtherAssessment))
                return;

            SaveAssessment(assessmentId, (int)otherAssessment.JointPartType, 0, 0, "EMPTY", "EMPTY", otherAssessment.OtherAssessment);
        }

        private void SaveAssessment(int assessmentId, int jointPartType, int jointType, int motionType, string leftValue = "EMPTY", string rightValue = "EMPTY", string otherAssessment = "EMPTY")
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.SaveAssessmentDetails;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", assessmentId));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", (int)jointPartType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", (int)jointType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", (int)motionType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", leftValue));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", rightValue));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", otherAssessment));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
