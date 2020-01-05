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

        /// <summary>
        /// Select process method and sub method include get by patientId or assesssmentid
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
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

        public List<clsAssessmentModel> GetDetailsByAssessmentId(int assessmentId)
        {
            List<clsAssessmentModel> result = new List<clsAssessmentModel>();
            DataTable dataTable = new DataTable();

            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.GetAssessementDetailsByAssessmentId;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assess", assessmentId));
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

                    ProcessJointPartType(data, item);
                }
            }

            return result;
        }

        private void ProcessJointPartType(clsAssessmentModel data, DataRow item)
        {
            switch (Convert.ToInt32(item[2]))
            {
                case (int)JointPartType.UpperJoint:
                    data.UpperJoint = new clsUpperJointModel
                    {
                        JointPartType = JointPartType.UpperJoint
                    };
                    ProcessJointType(data, item);
                    break;
                case (int)JointPartType.LowerJoint:
                    data.LowerJoint = new clsLowerJointModel
                    {
                        JointPartType = JointPartType.LowerJoint
                    };
                    ProcessJointType(data, item);
                    break;
                case (int)JointPartType.OtherAssessment:
                    data.OtherAssessment = new clsOtherAssessmentModel
                    {
                        JointPartType = JointPartType.OtherAssessment,
                        OtherAssessment = item[7].ToString()
                    };
                    break;
                default:
                    break;
            }
        }

        private void ProcessJointType(clsAssessmentModel data, DataRow item)
        {
            switch (Convert.ToInt32(item[3]))
            {
                case (int)JointType.Shoulder:
                    data.UpperJoint.Shoulder = new clsShoulderModel()
                    {
                        JointType = JointType.Shoulder,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.ElbowForarm:
                    data.UpperJoint.ElbowAndForemarm = new clsElbowAndForemarmModel()
                    {
                        JointType = JointType.ElbowForarm,
                        MotionValue = ProcessMotionType(item)

                    };
                    break;
                case (int)JointType.Wrist:
                    data.UpperJoint.Wrist = new clsWristModel()
                    {
                        JointType = JointType.Wrist,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.Thumb:
                    data.UpperJoint.Thumb = new clsThumbModel()
                    {
                        JointType = JointType.Thumb,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.IndexFinger:
                    data.UpperJoint.IndexFinger = new clsIndexFingerModel()
                    {
                        JointType = JointType.IndexFinger,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.MiddleFinger:
                    data.UpperJoint.MiddleFinger = new clsMiddleFingerModel()
                    {
                        JointType = JointType.MiddleFinger,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.RingFinger:
                    data.UpperJoint.RingFinger = new clsRingFingerModel()
                    {
                        JointType = JointType.RingFinger,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.LittleFinger:
                    data.UpperJoint.LittleFinger = new clsLittleFingerModel()
                    {
                        JointType = JointType.LittleFinger,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.Hip:
                    data.LowerJoint.Hip = new clsHipModel()
                    {
                        JointType = JointType.Hip,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.Knee:
                    data.LowerJoint.Knee = new clsKneeModel()
                    {
                        JointType = JointType.Knee,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                case (int)JointType.Ankle:
                    data.LowerJoint.Ankle = new clsAnkleModel()
                    {
                        JointType = JointType.Ankle,
                        MotionValue = ProcessMotionType(item)
                    };
                    break;
                default:
                    break;
            }
        }

        private List<Motion> ProcessMotionType(DataRow item)
        {
            List<Motion> result = new List<Motion>();

            switch (Convert.ToInt32(item[4]))
            {
                case (int)MotionType.Flexion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Flexion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Extension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Extension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.HorizontalAbduction:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.HorizontalAbduction,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.HorizontalAdduction:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.HorizontalAdduction,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.InternalRotation:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.InternalRotation,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.ExternalRotation:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.ExternalRotation,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.InternalRotationAlt:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.InternalRotationAlt,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.ExternalRotationAlt:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.ExternalRotationAlt,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.FlexsionExtension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.FlexsionExtension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Supination:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Supination,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Pronation:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Pronation,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.CMFlexsion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.CMFlexsion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.CMExtension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.CMExtension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.MPFlexsionExtension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.MPFlexsionExtension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.IPFlexsionExtension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.IPFlexsionExtension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Abduction:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Abduction,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Opposition:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Opposition,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.DIPFlexsionExtension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.DIPFlexsionExtension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Adduction:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Adduction,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Flextion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Flextion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Hypoextension:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Hypoextension,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Dorsiflexsion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Dorsiflexsion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Plantaflexsion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Plantaflexsion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Inversion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Inversion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.Eversion:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.Eversion,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.UlnarDeviation:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.UlnarDeviation,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                case (int)MotionType.RadiatDeviation:
                    result.Add(new Motion()
                    {
                        MotionType = MotionType.RadiatDeviation,
                        RightValue = item[5].ToString(),
                        LeftValue = item[6].ToString(),
                    });
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// All delete method
        /// </summary>
        /// <param name="selectedAssessmentId"></param>
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

        /// <summary>
        /// update method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="assessment"></param>
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

        /// <summary>
        /// Save method and sub method
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="assessment"></param>
        public void Save(int patientId, List<clsAssessmentModel> assessment)
        {
            SaveAssessmentEntry(patientId, assessment);
        }

        private void SaveAssessmentEntry(int patientId, List<clsAssessmentModel> assessment)
        {
            int assessmentId = 0;

            foreach (var item in assessment)
            {
                connect = new clsConnectorData();
                connect.Link();
                connect.con.Open();
                connect.cmd.CommandText = clsQuery.InsertAssessmentEntry;
                connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@patient", patientId));
                connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assdate", item.AssessmentDate));
                connect.cmd.ExecuteNonQuery();
                connect.con.Close();

                if (GetByPatientId(patientId).Count == 0)
                    throw new Exception("Fail to save assessment");

                var mentByPatientId = GetByPatientId(patientId)
                                .OrderByDescending(x => x.AssessementId)
                                .First();

                if (mentByPatientId != null)
                    assessmentId = mentByPatientId.AssessementId;

                if (assessmentId != 0)
                    SaveAssessmentDetails(assessmentId, item);
            }
        }

        private void SaveAssessmentDetails(int assessmentId, clsAssessmentModel item)
        {

            SaveUpperJoint(assessmentId, item.UpperJoint);
            SaveLowerJoint(assessmentId, item.LowerJoint);
            SaveOtherAssessment(assessmentId, item.OtherAssessment);

        }

        private void SaveUpperJoint(int assessmentId, clsUpperJointModel upperJoint)
        {
            if (upperJoint.Shoulder != null)
            {
                foreach (var item in upperJoint.Shoulder.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Shoulder.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.ElbowAndForemarm != null)
            {
                foreach (var item in upperJoint.ElbowAndForemarm.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.ElbowAndForemarm.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.Wrist != null)
            {
                foreach (var item in upperJoint.Wrist.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Wrist.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }
            
            if (upperJoint.Thumb != null)
            {
                foreach (var item in upperJoint.Thumb.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.Thumb.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.IndexFinger != null)
            {
                foreach (var item in upperJoint.IndexFinger.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.IndexFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.MiddleFinger != null)
            {
                foreach (var item in upperJoint.MiddleFinger.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.MiddleFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.RingFinger != null)
            {
                foreach (var item in upperJoint.RingFinger.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.RingFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (upperJoint.LittleFinger != null)
            {
                foreach (var item in upperJoint.LittleFinger.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)upperJoint.JointPartType, (int)upperJoint.LittleFinger.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }
        }

        private void SaveLowerJoint(int assessmentId, clsLowerJointModel lowerJoint)
        {
            if (lowerJoint.Ankle != null)
            {
                foreach (var item in lowerJoint.Ankle.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Ankle.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (lowerJoint.Hip != null)
            {
                foreach (var item in lowerJoint.Hip.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Hip.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }

            if (lowerJoint.Knee != null)
            {
                foreach (var item in lowerJoint.Knee.MotionValue)
                {
                    if (string.IsNullOrWhiteSpace(item.LeftValue) && string.IsNullOrWhiteSpace(item.RightValue))
                        continue;

                    SaveAssessment(assessmentId, (int)lowerJoint.JointPartType, (int)lowerJoint.Knee.JointType, (int)item.MotionType, item.LeftValue, item.RightValue);
                }
            }
            
        }

        private void SaveOtherAssessment(int assessmentId, clsOtherAssessmentModel otherAssessment)
        {
            if (otherAssessment != null)
            {
                if (string.IsNullOrWhiteSpace(otherAssessment.OtherAssessment))
                    return;

                SaveAssessment(assessmentId, (int)otherAssessment.JointPartType, 0, 0, "EMPTY", "EMPTY", otherAssessment.OtherAssessment);
            }
            
        }

        private void SaveAssessment(int assessmentId, int jointPartType, int jointType, int motionType, string leftValue = "EMPTY", string rightValue = "EMPTY", string otherAssessment = "EMPTY")
        {
            connect = new clsConnectorData();
            connect.Link();
            connect.con.Open();
            connect.cmd.CommandText = clsQuery.InsertAssessmentDetails;
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@assess", assessmentId));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@jpt", (int)jointPartType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@jt", (int)jointType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@mt", (int)motionType));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@rv", rightValue));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@lv", leftValue));
            connect.cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@oa", otherAssessment));
            connect.cmd.ExecuteNonQuery();
            connect.con.Close();
        }
    }
}
