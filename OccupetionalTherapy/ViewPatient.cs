using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Model;

namespace OccupetionalTherapy
{
    public partial class ViewPatient : Form
    {
        private int selectedPatient;
        private NavigationType navigateFrom;

        clsPatientDetails patientDetail = new clsPatientDetails();
        clsDateEntry dateEntry = new clsDateEntry();
        clsMedicalRecord medicalRecord = new clsMedicalRecord();
        clsAssessment assessment = new clsAssessment();
        clsAppointment appointment = new clsAppointment();
        clsPrescription prescription = new clsPrescription();

        clsPatientModel patient;

        public ViewPatient()
        {
            InitializeComponent();
        }

        public ViewPatient(int selectedPatient, NavigationType navigation)
        {
            InitializeComponent();
            this.selectedPatient = selectedPatient;
            navigateFrom = navigation;

            Navigation();
        }

        private void Navigation()
        {
            if (selectedPatient == 0)
                this.Close();

            patient = new clsPatientModel()
            {
                Appointments = new List<clsAppointmentModel>(),
                Assessment = new List<clsAssessmentModel>(),
                DateEntry = new clsDateEntryModel(),
                MedicalRecords = new clsPatientMedicalRecordModel(),
                PatientDetails = new clsPatientDetailsModel(),
                PatientId = selectedPatient,
                Prescription = new clsPrescriptionModel()
            };

            switch (navigateFrom)
            {
                case NavigationType.Appointments:
                    patient.PatientDetails = patientDetail.GetByPatientId(selectedPatient);
                    patient.DateEntry = dateEntry.GetbyPatientId(selectedPatient);
                    patient.MedicalRecords = medicalRecord.GetByPatientId(selectedPatient);
                    patient.Prescription = prescription.GetByPatientId(selectedPatient);
                    patient.Assessment = assessment.GetByPatientId(selectedPatient);
                    patient.Appointments = appointment.GetByPatientId(selectedPatient);
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
                    break;
                default:
                    break;
            }
        }
    }
}
