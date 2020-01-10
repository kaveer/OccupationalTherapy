using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OccupetionalTherapy
{
    public partial class NewPatient : Form
    {
        clsPatientDetails patientDetails;
        clsDateEntry dateEntry;
        clsAppointment appointment;
        clsAssessment assessment;
        clsMedicalRecord medicalRecord;
        clsPrescription prescription;

        clsPatientModel patient = new clsPatientModel()
        {
            Appointments = new List<clsAppointmentModel>(),
            Assessment = new List<clsAssessmentModel>(),
            DateEntry = new clsDateEntryModel(),
            MedicalRecords = new clsPatientMedicalRecordModel(),
            PatientDetails = new clsPatientDetailsModel(),
            PatientId = 0,
            Prescription = new clsPrescriptionModel()
        };

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

                    MessageBox.Show("New patient added");
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
            if (patient != null)
                if (patient.Assessment != null)
                    patient.Assessment = new List<clsAssessmentModel>();

            ///prescription
            txtAdvise.Clear();
            txtPrescription.Clear();
        }

        /// <summary>
        /// Assign value to object from textbox
        /// </summary>
        private void AssignValue()
        {
            patient.DateEntry.EntryDate = DateTime.Now;

            AssignPatientDetails();
            AssignMedicalRecord();
            AssignPrescription();
            AssignAppointment();

        }

        private void AssignAppointment()
        {
            patient.Appointments = new List<clsAppointmentModel>();

            DateTime newAppointment = dpNextAppointment.Value.Date + dpNextAppointment.Value.TimeOfDay;
            patient.Appointments.Add(new clsAppointmentModel()
            {
                Appointment = newAppointment
            });
        }

        public void AssignMotion(List<clsAssessmentModel> item)
        {
            if (item.Count > 0)
            {
                this.patient.Assessment = item;

                AssignValueToGrid(item);
            }

        }

        private void AssignValueToGrid(List<clsAssessmentModel> item)
        {
            if (item.Count > 0)
            {
                grdAssessement.DataSource = null;
                grdAssessement.Columns.Clear();
                grdAssessement.Rows.Clear();
                grdAssessement.DataBindings.Clear();

                grdAssessement.ColumnCount = 1;
                grdAssessement.Columns[0].Name = "Assessment taken for:";

                foreach (var assessment in item)
                {
                    if (assessment.UpperJoint != null)
                    {
                        if (assessment.UpperJoint.Shoulder != null)
                        {
                            string[] row = new string[] { "Shoulder" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.ElbowAndForemarm != null)
                        {
                            string[] row = new string[] { "Elbow And Foremarm" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.Wrist != null)
                        {
                            string[] row = new string[] { "Wrist" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.Thumb != null)
                        {
                            string[] row = new string[] { "Thumb" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.IndexFinger != null)
                        {
                            string[] row = new string[] { "Index Finger" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.MiddleFinger != null)
                        {
                            string[] row = new string[] { "Middle Finger" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.LittleFinger != null)
                        {
                            string[] row = new string[] { "Little Finger" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.UpperJoint.RingFinger != null)
                        {
                            string[] row = new string[] { "Ring Finger" };
                            grdAssessement.Rows.Add(row);
                        }
                    }
                    if (assessment.LowerJoint != null)
                    {
                        if (assessment.LowerJoint.Ankle != null)
                        {
                            string[] row = new string[] { "Ankle" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.LowerJoint.Knee != null)
                        {
                            string[] row = new string[] { "Knee" };
                            grdAssessement.Rows.Add(row);
                        }

                        if (assessment.LowerJoint.Hip != null)
                        {
                            string[] row = new string[] { "Hip" };
                            grdAssessement.Rows.Add(row);
                        }

                    }
                    if (assessment.OtherAssessment != null)
                    {
                        string[] row = new string[] { "Other Assessment" };
                        grdAssessement.Rows.Add(row);
                    }
                }

                GridFormatting();
            }
        }

        private void GridFormatting()
        {
            grdAssessement.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grdAssessement.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            grdAssessement.CellBorderStyle = DataGridViewCellBorderStyle.None;

            grdAssessement.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            grdAssessement.DefaultCellStyle.SelectionForeColor = Color.White;

            grdAssessement.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //grdAppointment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdAssessement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdAppointment.AllowUserToResizeColumns = false;

            grdAssessement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdAssessement.RowHeadersVisible = false;
            grdAssessement.AllowUserToAddRows = false;
            grdAssessement.AllowUserToResizeRows = false;
            grdAssessement.MultiSelect = false;

            grdAssessement.ReadOnly = true;

            foreach (DataGridViewColumn column in grdAssessement.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            grdAssessement.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAssessement.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
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
            int safeAge = 0;
            if (!string.IsNullOrWhiteSpace(txtAge.Text))
                int.TryParse(txtAge.Text, out safeAge);

            patient.PatientDetails.Surname = txtSurname.Text;
            patient.PatientDetails.Name = txtName.Text;
            patient.PatientDetails.Tel = txtTel.Text;
            patient.PatientDetails.Mobile1 = txtMobile1.Text;
            patient.PatientDetails.Mobile2 = txtMobile2.Text;
            patient.PatientDetails.DOB = dpDOB.Value;
            patient.PatientDetails.Age = safeAge;
            patient.PatientDetails.Occupation = txtOccupation.Text;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        private void Configuration()
        {
            txtEntryDate.Enabled = false;
            txtEntryDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
            int patientId = 0;

            patientDetails = new clsPatientDetails();
            patientId = patientDetails.Save(patient.PatientDetails);

            if (patientId == 0)
                throw new Exception("Cannot save patient");

            dateEntry = new clsDateEntry();
            dateEntry.Save(patientId, patient.DateEntry);

            if (patient.Appointments.Count > 0)
            {
                var selectedAppointment = patient.Appointments.First();
                if (selectedAppointment.Appointment.Date != DateTime.Today.Date)
                {
                    appointment = new clsAppointment();
                    appointment.Save(patientId, selectedAppointment.Appointment);
                }
            }

            medicalRecord = new clsMedicalRecord();
            medicalRecord.Save(patientId, patient.MedicalRecords);

            assessment = new clsAssessment();
            assessment.Save(patientId, patient.Assessment);

            prescription = new clsPrescription();
            prescription.Save(patientId, patient.Prescription);
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
