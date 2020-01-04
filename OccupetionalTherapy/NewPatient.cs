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
    public partial class NewPatient : Form
    {
        clsPatientModel patient;

        public NewPatient()
        {
            InitializeComponent();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Click button trigger events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAssesment_Click(object sender, EventArgs e)
        {
            RangeOfMotion app = new RangeOfMotion(this);
            app.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    AssignValue();
                    SavePatient();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            patient = new clsPatientModel()
            {
                Appointments = new List<clsAppointmentModel>(),
                Assessment = new List<clsAssessmentModel>(),
                DateEntry = new clsDateEntryModel(),
                MedicalRecords = new clsPatientMedicalRecordModel(),
                PatientDetails = new clsPatientDetailsModel(),
                PatientId = 0,
                Prescription = new clsPrescriptionModel()
            };

            ///Patient details
            txtSurname.Clear();
            txtName.Clear();
            txtTel.Clear();
            txtMobile1.Clear();
            txtMobile2.Clear();
            txtAge.Clear();
            txtOccupation.Clear();

            ///medical record
            txtDiagnosis.Clear();
            txtBriefHistory.Clear();
            txtPastMedicalHistory.Clear();
            cbxSwelling.Checked = false;
            cbxTenderness.Checked = false;
            cbxSensation.Checked = false;
            txtSensation.Clear();

            ///motion
            grdAssessement.DataSource = null;
            grdAssessement.Columns.Clear();
            grdAssessement.Rows.Clear();
            grdAssessement.DataBindings.Clear();

            ///prescription
            txtAdvise.Clear();
            txtPrescription.Clear();
        }

        /// <summary>
        /// Assign value to object from textbox
        /// </summary>
        private void AssignValue()
        {
            patient = new clsPatientModel()
            {
                Appointments = new List<clsAppointmentModel>(),
                Assessment = new List<clsAssessmentModel>(),
                DateEntry = new clsDateEntryModel(),
                MedicalRecords = new clsPatientMedicalRecordModel(),
                PatientDetails = new clsPatientDetailsModel(),
                PatientId = 0,
                Prescription = new clsPrescriptionModel()
            };


            patient.DateEntry.EntryDate = Convert.ToDateTime(txtEntryDate.Text);

            AssignPatientDetails();
            AssignMedicalRecord();
            AssignPrescription();
            AssignAppointment();

        }

        private void AssignAppointment()
        {
            DateTime newAppointment = dpNextAppointment.Value.Date + dpNextAppointment.Value.TimeOfDay;
        }

        public void AssignMotion(List<clsAssessmentModel> item)
        {
            if (item.Count > 0)
                this.patient.Assessment = item;
            
        }

        private void AssignPrescription()
        {
            patient.Prescription.Advise = txtAdvise.Text;
            patient.Prescription.Prescription = txtPrescription.Text;
        }

        private void AssignMedicalRecord()
        {
            patient.MedicalRecords.Diagnosis = txtDiagnosis.Text;
            patient.MedicalRecords.BriefHistory = txtBriefHistory.Text;
            patient.MedicalRecords.PastMedicalHistory = txtPastMedicalHistory.Text;
            patient.MedicalRecords.Swelling = cbxSwelling.Checked;
            patient.MedicalRecords.Tenderness = cbxTenderness.Checked;
            patient.MedicalRecords.Sensation = cbxSensation.Checked;
            patient.MedicalRecords.SensationDetails = txtSensation.Text;
        }

        private void AssignPatientDetails()
        {
            patient.PatientDetails.Surname = txtSurname.Text;
            patient.PatientDetails.Name = txtName.Text;
            patient.PatientDetails.Tel = txtTel.Text;
            patient.PatientDetails.Mobile1 = txtMobile1.Text;
            patient.PatientDetails.Mobile2 = txtMobile2.Text;
            patient.PatientDetails.DOB = dpDOB.Value;
            patient.PatientDetails.Age = string.IsNullOrWhiteSpace(txtAge.Text) ? 0 : Convert.ToInt32(txtAge.Text);
            patient.PatientDetails.Occupation = txtOccupation.Text;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        private void Configuration()
        {
            txtEntryDate.Enabled = false;
            txtEntryDate.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Validation of name, surname, diagnosis only
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txtSurname.Text))
                throw new Exception("Surname required");

            if (string.IsNullOrWhiteSpace(txtName.Text))
                throw new Exception("Name required");

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
                throw new Exception("Diagnosis details required");

            return result;
        }

        /// <summary>
        /// Save patient details
        /// </summary>
        private void SavePatient()
        {
            throw new NotImplementedException();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    RangeOfMotion app = new RangeOfMotion(this, NavigationType.NewPatient);
        //    app.ShowDialog();
        //}

        //public void SetName(string name)
        //{
        //    txtSurname.Text = name;
        //}
    }
}
