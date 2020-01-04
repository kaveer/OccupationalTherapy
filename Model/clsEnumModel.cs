using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class clsEnumModel
    {
    }

    public enum NavigationType
    {
        Appointments = 1,
        NewPatient = 2,
        Patients = 3,
        Search = 4,

        //In show dialog
        RnageOfMotion = 5,
        ViewPatient = 6
    }

    public enum JointPartType
    {
        UpperJoint = 1,
        LowerJoint = 2,
        OtherAssessment = 3
    }

    public enum JointType
    {
        Shoulder = 1,
        ElbowForarm = 2,
        Wrist = 3,
        Thumb = 4,
        IndexFinger = 5,
        MiddleFinger = 6,
        RingFinger = 7,
        LittleFinger = 8,
        Hip = 9,
        Knee = 10,
        Ankle = 11,


    }

    public enum MotionType
    {
        Flexion = 1,
        Extension = 2,
        HorizontalAbduction = 3,
        HorizontalAdduction = 4,
        InternalRotation = 5,
        ExternalRotation = 6,
        InternalRotationAlt = 7,
        ExternalRotationAlt = 8,
        FlexsionExtension = 9,
        Supination = 10,
        Pronation = 11,
        CMFlexsion = 12,
        CMExtension = 13,
        MPFlexsionExtension = 14,
        IPFlexsionExtension = 15,
        Abduction = 16,
        Opposition = 17,
        DIPFlexsionExtension = 18,
        Adduction = 19,
        Flextion = 20,
        Hypoextension = 21,
        Dorsiflexsion = 22,
        Plantaflexsion = 23,
        Inversion = 24,
        Eversion = 25,
        UlnarDeviation = 26,
        RadiatDeviation = 27
    }
}
