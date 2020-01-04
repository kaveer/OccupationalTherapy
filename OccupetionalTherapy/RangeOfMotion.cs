using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OccupetionalTherapy
{
    public partial class RangeOfMotion : Form
    {
        /// <summary>
        /// Reference : https://grantwinney.com/passing-data-between-two-forms-in-winforms/
        /// </summary>
        private ViewPatient ViewPatient;
        private NewPatient newPatient;

        private clsAssessment assessment;

        private clsPatientModel patient;

        public NavigationType navigationType;
        private bool isNew;
        private int assessmentId;
        private int patientId;

        public RangeOfMotion()
        {
            InitializeComponent();
        }

        public RangeOfMotion(ViewPatient viewPatient, bool isNew, int assessmentId, int patientId)
        {
            InitializeComponent();
            this.ViewPatient = viewPatient;
            this.navigationType = NavigationType.ViewPatient;
            this.isNew = isNew;
            this.assessmentId = assessmentId;
            this.patientId = patientId;
        }

        public RangeOfMotion(NewPatient newPatient)
        {
            InitializeComponent();
            this.newPatient = newPatient;
            this.navigationType = NavigationType.NewPatient;
            this.isNew = true;
        }

        private void RangeOfMotion_Load(object sender, EventArgs e)
        {
            Navigation();
        }

        private void Navigation()
        {
            switch (navigationType)
            {
                case NavigationType.Appointments:
                    break;
                case NavigationType.NewPatient:

                    break;
                case NavigationType.Patients:
                    break;
                case NavigationType.Search:
                    break;
                case NavigationType.RnageOfMotion:
                    break;
                case NavigationType.ViewPatient:
                    if (!isNew)
                    {
                        btnUpsert.Text = "Update";
                        assessment = new clsAssessment();
                        patient = new clsPatientModel()
                        {
                            Assessment = new List<clsAssessmentModel>()
                        };
                        patient.Assessment = assessment.GetDetailsByAssessmentId(assessmentId);
                        //assign to textbox;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Button click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {




        }



        private void btnUpsert_Click(object sender, EventArgs e)
        {
            AssignValueToModel();

            switch (navigationType)
            {
                case NavigationType.Appointments:
                    break;
                case NavigationType.NewPatient:
                    this.newPatient.AssignMotion(patient.Assessment);
                    break;
                case NavigationType.Patients:
                    break;
                case NavigationType.Search:
                    break;
                case NavigationType.RnageOfMotion:
                    break;
                case NavigationType.ViewPatient:
                    if (isNew)
                        assessment.Save(patientId, patient.Assessment);
                    else
                        assessment.Update(assessmentId, patient.Assessment);
                        
                    this.ViewPatient.ReloadForm();
                    MessageBox.Show("Action completed with success");
                    this.Close();
                    break;
                default:
                    break;
            }

            this.Close();
        }

        /// <summary>
        /// Assign value main method
        /// </summary>
        private void AssignValueToModel()
        {
            clsAssessmentModel assessment = new clsAssessmentModel()
            {
                AssessmentDate = DateTime.Now,
                OtherAssessment = AssignOtherAssessment(),
                UpperJoint = AssignUpperJoint(),
                LowerJoint = AssignlowerJoint()
            };

            patient = new clsPatientModel
            {
                Assessment = new List<clsAssessmentModel>()
                {
                    assessment
                }
            };
        }

        /// <summary>
        /// Assign value to upper body
        /// </summary>
        /// <returns></returns>
        private clsUpperJointModel AssignUpperJoint()
        {
            clsUpperJointModel result = new clsUpperJointModel()
            {
                JointPartType = JointPartType.UpperJoint,
                Shoulder = AssignShoulder(),
                ElbowAndForemarm = AssignElbow(),
                Wrist = AssignWrist(),
                Thumb = AssignThumb(),
                IndexFinger = AssignIndexFinger(),
                MiddleFinger = AssignMiddleFinger(),
                RingFinger = AssignRingFinger(),
                LittleFinger = AssignLittleFinger()
            };

            return result;
        }

        /// <summary>
        /// Assign value to each joint type
        /// </summary>
        /// <returns></returns>
        private clsShoulderModel AssignShoulder()
        {
            bool isNull = true;
            clsShoulderModel result = new clsShoulderModel()
            {
                JointType = JointType.Shoulder,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_SL_flexsion.Text) || !string.IsNullOrWhiteSpace(txt_SR_flexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Flexion,
                       LeftValue = txt_SL_flexsion.Text,
                       RightValue = txt_SL_flexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_extension.Text) || !string.IsNullOrWhiteSpace(txt_SR_extension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Extension,
                       LeftValue = txt_SL_extension.Text,
                       RightValue = txt_SR_extension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_horizontalAbduction.Text) || !string.IsNullOrWhiteSpace(txt_SR_horizontalAbduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.HorizontalAbduction,
                       LeftValue = txt_SL_horizontalAbduction.Text,
                       RightValue = txt_SR_horizontalAbduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_horizontalAdduction.Text) || !string.IsNullOrWhiteSpace(txt_SR_horizontalAdduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.HorizontalAdduction,
                       LeftValue = txt_SL_horizontalAdduction.Text,
                       RightValue = txt_SR_horizontalAdduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_internalRotation.Text) || !string.IsNullOrWhiteSpace(txt_SR_internalRotation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.InternalRotation,
                       LeftValue = txt_SL_internalRotation.Text,
                       RightValue = txt_SR_internalRotation.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_externalRotation.Text) || !string.IsNullOrWhiteSpace(txt_SR_externalRotation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.ExternalRotation,
                       LeftValue = txt_SL_externalRotation.Text,
                       RightValue = txt_SR_externalRotation.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_InternalRotationAlt.Text) || !string.IsNullOrWhiteSpace(txt_SR_InternalRotationAlt.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.InternalRotationAlt,
                       LeftValue = txt_SL_InternalRotationAlt.Text,
                       RightValue = txt_SR_InternalRotationAlt.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SL_ExternalRotationAlt.Text) || !string.IsNullOrWhiteSpace(txt_SR_ExternalRotationAlt.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.ExternalRotationAlt,
                       LeftValue = txt_SL_ExternalRotationAlt.Text,
                       RightValue = txt_SR_ExternalRotationAlt.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsElbowAndForemarmModel AssignElbow()
        {
            bool isNull = true;
            clsElbowAndForemarmModel result = new clsElbowAndForemarmModel()
            {
                JointType = JointType.ElbowForarm,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_EL_FlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_ER_FlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.FlexsionExtension,
                       LeftValue = txt_EL_FlexsionExtension.Text,
                       RightValue = txt_ER_FlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_EL_Supination.Text) || !string.IsNullOrWhiteSpace(txt_ER_Supination.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Supination,
                       LeftValue = txt_EL_Supination.Text,
                       RightValue = txt_ER_Supination.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_EL_Pronation.Text) || !string.IsNullOrWhiteSpace(txt_ER_Pronation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Pronation,
                       LeftValue = txt_EL_Pronation.Text,
                       RightValue = txt_ER_Pronation.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsWristModel AssignWrist()
        {
            bool isNull = true;
            clsWristModel result = new clsWristModel()
            {
                JointType = JointType.Wrist,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_WL_Flexsion.Text) || !string.IsNullOrWhiteSpace(txt_WR_Flexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Flexion,
                       LeftValue = txt_WL_Flexsion.Text,
                       RightValue = txt_WR_Flexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_WL_Extension.Text) || !string.IsNullOrWhiteSpace(txt_WR_Extension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Extension,
                       LeftValue = txt_WL_Extension.Text,
                       RightValue = txt_WR_Extension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_WL_UlnarDeviation.Text) || !string.IsNullOrWhiteSpace(txt_WR_UlnarDeviation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.UlnarDeviation,
                       LeftValue = txt_WL_UlnarDeviation.Text,
                       RightValue = txt_WR_UlnarDeviation.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_WL_RadiatDeviation.Text) || !string.IsNullOrWhiteSpace(txt_WR_RadiatDeviation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.RadiatDeviation,
                       LeftValue = txt_WL_RadiatDeviation.Text,
                       RightValue = txt_WR_RadiatDeviation.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsThumbModel AssignThumb()
        {
            bool isNull = true;
            clsThumbModel result = new clsThumbModel()
            {
                JointType = JointType.Thumb,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_TL_CMflexsion.Text) || !string.IsNullOrWhiteSpace(txt_TR_CMflexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.CMFlexsion,
                       LeftValue = txt_TL_CMflexsion.Text,
                       RightValue = txt_TR_CMflexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_TL_CmExtension.Text) || !string.IsNullOrWhiteSpace(txt_TR_CMExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.CMExtension,
                       LeftValue = txt_TL_CmExtension.Text,
                       RightValue = txt_TR_CMExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_TL_MpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_TR_MpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.MPFlexsionExtension,
                       LeftValue = txt_TL_MpFlexsionExtension.Text,
                       RightValue = txt_TR_MpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_TL_IpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_TR_IpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.IPFlexsionExtension,
                       LeftValue = txt_TL_IpFlexsionExtension.Text,
                       RightValue = txt_TR_IpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_TL_AbductionCm.Text) || !string.IsNullOrWhiteSpace(txt_TR_AbductionCm.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_TL_AbductionCm.Text,
                       RightValue = txt_TR_AbductionCm.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_TL_OppositionCm.Text) || !string.IsNullOrWhiteSpace(txt_TR_OppositionCm.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Opposition,
                       LeftValue = txt_TL_OppositionCm.Text,
                       RightValue = txt_TR_OppositionCm.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsLittleFingerModel AssignLittleFinger()
        {
            bool isNull = true;
            clsLittleFingerModel result = new clsLittleFingerModel()
            {
                JointType = JointType.LittleFinger,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_LFL_MpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_LFR_MpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.MPFlexsionExtension,
                       LeftValue = txt_LFL_MpFlexsionExtension.Text,
                       RightValue = txt_LFR_MpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_LFL_IpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_LFR_IpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.IPFlexsionExtension,
                       LeftValue = txt_LFL_IpFlexsionExtension.Text,
                       RightValue = txt_LFR_IpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_LFL_DipFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_LFR_DipFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.DIPFlexsionExtension,
                       LeftValue = txt_LFL_DipFlexsionExtension.Text,
                       RightValue = txt_LFR_DipFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_LFL_Abduction.Text) || !string.IsNullOrWhiteSpace(txt_LFR_Abduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_LFL_Abduction.Text,
                       RightValue = txt_LFR_Abduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_LFL_Adduction.Text) || !string.IsNullOrWhiteSpace(txt_LFR_Adduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Adduction,
                       LeftValue = txt_LFL_Adduction.Text,
                       RightValue = txt_LFR_Adduction.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsRingFingerModel AssignRingFinger()
        {
            bool isNull = true;
            clsRingFingerModel result = new clsRingFingerModel()
            {
                JointType = JointType.RingFinger,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_RFL_MpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_RFR_MpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.MPFlexsionExtension,
                       LeftValue = txt_RFL_MpFlexsionExtension.Text,
                       RightValue = txt_RFR_MpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_RFL_IpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_RFR_IpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.IPFlexsionExtension,
                       LeftValue = txt_RFL_IpFlexsionExtension.Text,
                       RightValue = txt_RFR_IpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_RFL_DipFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_RFR_DipFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.DIPFlexsionExtension,
                       LeftValue = txt_RFL_DipFlexsionExtension.Text,
                       RightValue = txt_RFR_DipFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_RFL_Abduction.Text) || !string.IsNullOrWhiteSpace(txt_RFR_Abduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_RFL_Abduction.Text,
                       RightValue = txt_RFR_Abduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_RFL_Adduction.Text) || !string.IsNullOrWhiteSpace(txt_RFR_Adduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Adduction,
                       LeftValue = txt_RFL_Adduction.Text,
                       RightValue = txt_RFR_Adduction.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsMiddleFingerModel AssignMiddleFinger()
        {
            bool isNull = true;
            clsMiddleFingerModel result = new clsMiddleFingerModel()
            {
                JointType = JointType.MiddleFinger,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_MFL_MpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_MFR_MpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.MPFlexsionExtension,
                       LeftValue = txt_MFL_MpFlexsionExtension.Text,
                       RightValue = txt_MFR_MpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_MFL_IpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_MFR_IpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.IPFlexsionExtension,
                       LeftValue = txt_MFL_IpFlexsionExtension.Text,
                       RightValue = txt_MFR_IpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_MFL_DipFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_MFR_DipFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.DIPFlexsionExtension,
                       LeftValue = txt_MFL_DipFlexsionExtension.Text,
                       RightValue = txt_MFR_DipFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_MFL_Abduction.Text) || !string.IsNullOrWhiteSpace(txt_MFR_Abduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_MFL_Abduction.Text,
                       RightValue = txt_MFR_Abduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_MFL_Adduction.Text) || !string.IsNullOrWhiteSpace(txt_MFR_Adduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Adduction,
                       LeftValue = txt_MFL_Adduction.Text,
                       RightValue = txt_MFR_Adduction.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsIndexFingerModel AssignIndexFinger()
        {
            bool isNull = true;
            clsIndexFingerModel result = new clsIndexFingerModel()
            {
                JointType = JointType.IndexFinger,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_IFL_MpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_IFR_MpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.MPFlexsionExtension,
                       LeftValue = txt_IFL_MpFlexsionExtension.Text,
                       RightValue = txt_IFR_MpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_IFL_IpFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_IFR_IpFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.IPFlexsionExtension,
                       LeftValue = txt_IFL_IpFlexsionExtension.Text,
                       RightValue = txt_IFR_IpFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_IFL_DipFlexsionExtension.Text) || !string.IsNullOrWhiteSpace(txt_IFR_DipFlexsionExtension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.DIPFlexsionExtension,
                       LeftValue = txt_IFL_DipFlexsionExtension.Text,
                       RightValue = txt_IFR_DipFlexsionExtension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_IFL_Abduction.Text) || !string.IsNullOrWhiteSpace(txt_IFR_Abduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_IFL_Abduction.Text,
                       RightValue = txt_IFR_Abduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_IFL_Adduction.Text) || !string.IsNullOrWhiteSpace(txt_IFR_Adduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Adduction,
                       LeftValue = txt_IFL_Adduction.Text,
                       RightValue = txt_IFR_Adduction.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        /// <summary>
        /// Assign value to lower joint of body
        /// </summary>
        /// <returns></returns>
        private clsLowerJointModel AssignlowerJoint()
        {
            clsLowerJointModel result = new clsLowerJointModel()
            {
                JointPartType = JointPartType.LowerJoint,
                Ankle = AssignAnkle(),
                Hip = AssignHip(),
                Knee = AssignKnee()
            };

            return result;
        }

        private clsAnkleModel AssignAnkle()
        {
            bool isNull = true;
            clsAnkleModel result = new clsAnkleModel()
            {
                JointType = JointType.Ankle,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_KL_Dorsiflexsion.Text) || !string.IsNullOrWhiteSpace(txt_KR_Dorsiflexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Dorsiflexsion,
                       LeftValue = txt_KL_Dorsiflexsion.Text,
                       RightValue = txt_KR_Dorsiflexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_KL_Plantaflexsion.Text) || !string.IsNullOrWhiteSpace(txt_KR_Plantaflexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Plantaflexsion,
                       LeftValue = txt_KL_Plantaflexsion.Text,
                       RightValue = txt_KR_Plantaflexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_KL_Inversion.Text) || !string.IsNullOrWhiteSpace(txt_KR_Inversion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Inversion,
                       LeftValue = txt_KL_Inversion.Text,
                       RightValue = txt_KR_Inversion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_KL_Eversion.Text) || !string.IsNullOrWhiteSpace(txt_KR_Eversion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Eversion,
                       LeftValue = txt_KL_Eversion.Text,
                       RightValue = txt_KR_Eversion.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsHipModel AssignHip()
        {
            bool isNull = true;
            clsHipModel result = new clsHipModel()
            {
                JointType = JointType.Hip,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_HL_flexsion.Text) || !string.IsNullOrWhiteSpace(txt_HR_flexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Flexion,
                       LeftValue = txt_HL_flexsion.Text,
                       RightValue = txt_HR_flexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_HL_extension.Text) || !string.IsNullOrWhiteSpace(txt_HR_extension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Extension,
                       LeftValue = txt_HL_extension.Text,
                       RightValue = txt_HR_extension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_HL_Abduction.Text) || !string.IsNullOrWhiteSpace(txt_HR_Abduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Abduction,
                       LeftValue = txt_HL_Abduction.Text,
                       RightValue = txt_HR_Abduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_HL_Adduction.Text) || !string.IsNullOrWhiteSpace(txt_HR_Adduction.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Adduction,
                       LeftValue = txt_HL_Adduction.Text,
                       RightValue = txt_HR_Adduction.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_HL_internalRotation.Text) || !string.IsNullOrWhiteSpace(txt_HR_internalRotation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.InternalRotation,
                       LeftValue = txt_HL_internalRotation.Text,
                       RightValue = txt_HR_internalRotation.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_HL_externalRotation.Text) || !string.IsNullOrWhiteSpace(txt_HR_externalRotation.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.ExternalRotation,
                       LeftValue = txt_HL_externalRotation.Text,
                       RightValue = txt_HR_externalRotation.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        private clsKneeModel AssignKnee()
        {
            bool isNull = true;
            clsKneeModel result = new clsKneeModel()
            {
                JointType = JointType.Knee,
                MotionValue = new List<Motion>()
            };

            if (!string.IsNullOrWhiteSpace(txt_KL_flexsion.Text) || !string.IsNullOrWhiteSpace(txt_KR_flexsion.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Flexion,
                       LeftValue = txt_KL_flexsion.Text,
                       RightValue = txt_KR_flexsion.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_KL_extension.Text) || !string.IsNullOrWhiteSpace(txt_KR_extension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Extension,
                       LeftValue = txt_KL_extension.Text,
                       RightValue = txt_KR_extension.Text
                   });
                isNull = false;
            }

            if (!string.IsNullOrWhiteSpace(txt_KL_Hypoextension.Text) || !string.IsNullOrWhiteSpace(txt_KR_Hypoextension.Text))
            {
                result.MotionValue.Add(
                   new Motion()
                   {
                       MotionType = MotionType.Hypoextension,
                       LeftValue = txt_KL_Hypoextension.Text,
                       RightValue = txt_KR_Hypoextension.Text
                   });
                isNull = false;
            }

            if (isNull)
                return null;

            return result;
        }

        /// <summary>
        /// Other assesssment without sub method
        /// </summary>
        /// <returns></returns>
        private clsOtherAssessmentModel AssignOtherAssessment()
        {
            clsOtherAssessmentModel result = new clsOtherAssessmentModel();

            if (string.IsNullOrWhiteSpace(txtOtherAssessment.Text.Trim()))
                return null;

            result = new clsOtherAssessmentModel()
            {
                JointPartType = JointPartType.OtherAssessment,
                OtherAssessment = txtOtherAssessment.Text
            };

            return result;
        }

    }
}
