using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnUpsert_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                //insert
            }
            else
            {
                
                //ipdate == delete all by assessment id + insert new
            }

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
                    this.ViewPatient.ReloadForm();
                    MessageBox.Show("Action completed with success");
                    this.Close();
                    break;
                default:
                    break;
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    switch (navigationType)
        //    {
        //        case NavigationType.Appointments:
        //            Appointment.SetLabel("tets");
        //            break;
        //        case NavigationType.NewPatient:
        //            NewPatient.SetName("some test here");
        //            break;
        //        case NavigationType.Patients:
        //            break;
        //        case NavigationType.Search:
        //            break;
        //        default:
        //            break;
        //    }

        //    this.Close();
        //}
    }
}
