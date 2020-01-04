using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class clsAssessmentModel
    {
        public int AssessementId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int AssessmentDetailsId { get; set; }
        public clsUpperJointModel UpperJoint { get; set; }
        public clsLowerJointModel LowerJoint { get; set; }
        public clsOtherAssessmentModel OtherAssessment { get; set; }
    }

    public class clsOtherAssessmentModel
    {
        public JointPartType JointPartType { get; set; }
        public string OtherAssessment { get; set; }
    }

    public class clsUpperJointModel
    {
        public JointPartType JointPartType { get; set; }
        public clsShoulderModel Shoulder { get; set; }
        public clsElbowAndForemarmModel ElbowAndForemarm { get; set; }
        public clsWristModel Wrist { get; set; }
        public clsThumbModel Thumb { get; set; }
        public clsIndexFingerModel IndexFinger { get; set; }
        public clsMiddleFingerModel MiddleFinger { get; set; }
        public clsRingFingerModel RingFinger { get; set; }
        public clsLittleFingerModel LittleFinger { get; set; }
    }
    public class clsLowerJointModel
    {
        public JointPartType JointPartType { get; set; }
        public clsHipModel Hip { get; set; }
        public clsKneeModel Knee { get; set; }
        public clsAnkleModel Ankle { get; set; }
    }
    public class clsShoulderModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsWristModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsElbowAndForemarmModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsThumbModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsIndexFingerModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsMiddleFingerModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsRingFingerModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsLittleFingerModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsHipModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsKneeModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class clsAnkleModel
    {
        public JointType JointType { get; set; }
        public List<Motion> MotionValue { get; set; }
    }
    public class Motion
    {
        public MotionType MotionType { get; set; }
        public string RightValue { get; set; }
        public string LeftValue { get; set; }
    }
}
