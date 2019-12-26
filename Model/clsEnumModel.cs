﻿using System;
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
        LowerJoint = 2
    }

    public enum JointType
    {
        Shoulder = 1,
        Wrist = 2,

    }

    public enum MotionType
    {
        Flexion = 1
    }
}
