﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using Model;

namespace OccupetionalTherapy
{
    public partial class ViewPatient : Form
    {
        private int selectedPatient;
        private NavigationType navigateFrom;

        clsPatientDetails patientDetail;
        clsDateEntry dateEntry;
        clsMedicalRecord medicalRecord;
        clsAssessment assessment;
        clsAppointment appointment;
        clsPrescription prescription;

        clsPatientModel patient;
        int selectedAssessmentId = 0;
        int selectedAppointmentId = 0;

        public ViewPatient()
        {
            InitializeComponent();
            Configuration();
        }

        public ViewPatient(int selectedPatient, NavigationType navigation)
        {
            InitializeComponent();

            try
            {
                this.selectedPatient = selectedPatient;
                navigateFrom = navigation;

                Navigation();

                if (patient != null || patient.PatientId != 0)
                    AssignValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// Navigation
        /// </summary>
        private void Navigation()
        {
            if (selectedPatient == 0)
                this.Close();

            patientDetail = new clsPatientDetails();
            dateEntry = new clsDateEntry();
            medicalRecord = new clsMedicalRecord();
            assessment = new clsAssessment();
            appointment = new clsAppointment();
            prescription = new clsPrescription();

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
                case NavigationType.Patients:
                case NavigationType.Search:
                    patient.PatientDetails = patientDetail.GetByPatientId(selectedPatient);
                    patient.DateEntry = dateEntry.GetbyPatientId(selectedPatient);
                    patient.MedicalRecords = medicalRecord.GetByPatientId(selectedPatient);
                    patient.Prescription = prescription.GetByPatientId(selectedPatient);
                    patient.Assessment = assessment.GetByPatientId(selectedPatient);
                    patient.Appointments = appointment.GetByPatientId(selectedPatient);
                    break;
                case NavigationType.NewPatient:
                    break;
                case NavigationType.RnageOfMotion:
                    break;
                case NavigationType.ViewPatient:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Assign value
        /// </summary>
        private void AssignValue()
        {
            Configuration();

            if (patient.DateEntry.EntryDate != null)
                txtEntryDate.Text = patient.DateEntry.EntryDate.ToString("dd/MM/yyy HH:mm:ss");

            AssignPatientDetails();
            AssignMedicalRecord();
            AssignPrescription();
            AssignMotion();
            AssignAppointment();
        }

        private void AssignAppointment()
        {
            grdAppointment.DataSource = null;
            grdAppointment.Columns.Clear();
            grdAppointment.Rows.Clear();
            grdAppointment.DataBindings.Clear();

            if (patient.Appointments.Count > 0)
            {
                grdAppointment.ColumnCount = 2;
                grdAppointment.Columns[0].Name = "AppointmentId";
                grdAppointment.Columns[1].Name = "Appointment";

                foreach (var item in patient.Appointments)
                {
                    string[] row = new string[] { item.AppointmentId.ToString(), item.Appointment.ToString("dd/MM/yyyy HH:mm:ss") };
                    grdAppointment.Rows.Add(row);
                }

                grdAppointment.Columns[0].Visible = false;
                AppointmentGridFormatting();
            }
        }

        private void AssignMotion()
        {
            grdAssessment.DataSource = null;
            grdAssessment.Columns.Clear();
            grdAssessment.Rows.Clear();
            grdAssessment.DataBindings.Clear();

            if (patient.Assessment.Count > 0)
            {
                grdAssessment.ColumnCount = 2;
                grdAssessment.Columns[0].Name = "AssessementId";
                grdAssessment.Columns[1].Name = "Date";

                foreach (var item in patient.Assessment)
                {
                    string[] row = new string[] { item.AssessementId.ToString(), item.AssessmentDate.ToString("dd/MM/yyyy") };
                    grdAssessment.Rows.Add(row);
                }

                grdAssessment.Columns[0].Visible = false;
                AssessmentGridFormatting();
            }
        }

        private void AssignPrescription()
        {
            if (patient.Prescription != null)
            {
                txtAdvise.Text = patient.Prescription.Advise;
                txtPrescription.Text = patient.Prescription.Prescription;
            }
        }

        private void AssignMedicalRecord()
        {
            if (patient.MedicalRecords != null)
            {
                txtDiagnosis.Text = patient.MedicalRecords.Diagnosis;
                txtBriefHistory.Text = patient.MedicalRecords.BriefHistory;
                txtPastMedicalHistory.Text = patient.MedicalRecords.PastMedicalHistory;
                cbxSwelling.Checked = patient.MedicalRecords.Swelling;
                cbxTenderness.Checked = patient.MedicalRecords.Tenderness;
                cbxSensation.Checked = patient.MedicalRecords.Sensation;
                txtSensation.Text = patient.MedicalRecords.SensationDetails;
            }
        }

        private void AssignPatientDetails()
        {
            if (patient.PatientDetails != null)
            {
                txtSurname.Text = patient.PatientDetails.Surname;
                txtName.Text = patient.PatientDetails.Name;
                txtTel.Text = patient.PatientDetails.Tel;
                txtMobile1.Text = patient.PatientDetails.Mobile1;
                txtMobile2.Text = patient.PatientDetails.Mobile2;
                dpDOB.Value = patient.PatientDetails.DOB;
                txtAge.Text = patient.PatientDetails.Age.ToString();
                txtOccupation.Text = patient.PatientDetails.Occupation;
            }
        }

        /// <summary>
        /// Configuration of controls
        /// </summary>
        private void Configuration()
        {
            txtEntryDate.Enabled = false;
        }

        private void AppointmentGridFormatting()
        {
            grdAppointment.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grdAppointment.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            grdAppointment.CellBorderStyle = DataGridViewCellBorderStyle.None;

            grdAppointment.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            grdAppointment.DefaultCellStyle.SelectionForeColor = Color.White;

            grdAppointment.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //grdAppointment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdAppointment.AllowUserToResizeColumns = false;

            grdAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdAppointment.RowHeadersVisible = false;
            grdAppointment.AllowUserToAddRows = false;
            grdAppointment.AllowUserToResizeRows = false;
            grdAppointment.MultiSelect = false;

            grdAppointment.ReadOnly = true;

            foreach (DataGridViewColumn column in grdAppointment.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            grdAppointment.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAppointment.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

        }

        private void AssessmentGridFormatting()
        {
            grdAssessment.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grdAssessment.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            grdAssessment.CellBorderStyle = DataGridViewCellBorderStyle.None;

            grdAssessment.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            grdAssessment.DefaultCellStyle.SelectionForeColor = Color.White;

            grdAssessment.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //grdAppointment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdAssessment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdAppointment.AllowUserToResizeColumns = false;

            grdAssessment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdAssessment.RowHeadersVisible = false;
            grdAssessment.AllowUserToAddRows = false;
            grdAssessment.AllowUserToResizeRows = false;
            grdAssessment.MultiSelect = false;

            grdAssessment.ReadOnly = true;

            foreach (DataGridViewColumn column in grdAssessment.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            grdAssessment.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAssessment.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
        }

        /// <summary>
        /// Get value from grid selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdAssessment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdAssessment.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    selectedAssessmentId = Convert.ToInt32(grdAssessment.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void grdAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdAppointment.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    selectedAppointmentId = Convert.ToInt32(grdAppointment.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        /// <summary>
        /// Button click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAssessment_Click(object sender, EventArgs e)
        {
            try
            {
                if (patient == null || patient.PatientId == 0)
                    throw new Exception("Invalid patient");

                RangeOfMotion rangeOfMotion = new RangeOfMotion(this, true, 0, patient.PatientId);
                rangeOfMotion.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnViewAssessment_Click(object sender, EventArgs e)
        {
            try
            {
                if (patient == null || patient.PatientId == 0)
                    throw new Exception("Invalid patient");

                if (selectedAssessmentId == 0)
                    throw new Exception("Select assessment to view");

                RangeOfMotion rangeOfMotion = new RangeOfMotion(this, false, selectedAssessmentId, patient.PatientId);
                rangeOfMotion.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteAssessment_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAssessmentId == 0)
                    throw new Exception("Select assessment to delete");

                assessment = new clsAssessment();
                assessment.DeleteByAssessmentId(selectedAssessmentId);

                Navigation();

                if (patient != null || patient.PatientId != 0)
                    AssignValue();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime newAppointment = dpAddAppointment.Value.Date + dpAppointmentTime.Value.TimeOfDay;
                if (newAppointment.Date == DateTime.Today.Date)
                    throw new Exception("Appointment cannot be today");

                appointment = new clsAppointment();
                appointment.Save(patient.PatientId, newAppointment);

                Navigation();

                if (patient != null || patient.PatientId != 0)
                    AssignValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAppointmentId == 0)
                    throw new Exception("Select appointment to delete");

                appointment = new clsAppointment();
                appointment.DeleteByAppointmentId(selectedAppointmentId);

                Navigation();

                if (patient != null || patient.PatientId != 0)
                    AssignValue();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (patient != null || patient.PatientId != 0)
                {
                    UpdatePatientDetails();
                    UpdateMedicalRecord();
                    UpdatePrescription();

                    MessageBox.Show("Patient updated successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Update event method
        /// </summary>
        private void UpdatePrescription()
        {
            patient.Prescription.Advise = txtAdvise.Text;
            patient.Prescription.Prescription = txtPrescription.Text;

            prescription = new clsPrescription();
            prescription.Update(patient.PatientId, patient.Prescription);
        }

        private void UpdateMedicalRecord()
        {
            patient.MedicalRecords.Diagnosis = txtDiagnosis.Text;
            patient.MedicalRecords.BriefHistory = txtBriefHistory.Text;
            patient.MedicalRecords.PastMedicalHistory = txtPastMedicalHistory.Text;
            patient.MedicalRecords.Swelling = cbxSwelling.Checked;
            patient.MedicalRecords.Tenderness = cbxTenderness.Checked;
            patient.MedicalRecords.Sensation = cbxSensation.Checked;
            patient.MedicalRecords.SensationDetails = txtSensation.Text;

            medicalRecord = new clsMedicalRecord();
            medicalRecord.Update(patient.PatientId, patient.MedicalRecords);
        }

        private void UpdatePatientDetails()
        {
            patient.PatientDetails.Surname = txtSurname.Text;
            patient.PatientDetails.Name = txtName.Text;
            patient.PatientDetails.Tel = txtTel.Text;
            patient.PatientDetails.Mobile1 = txtMobile1.Text;
            patient.PatientDetails.Mobile2 = txtMobile2.Text;
            patient.PatientDetails.DOB = dpDOB.Value;
            patient.PatientDetails.Age = string.IsNullOrWhiteSpace(txtAge.Text) ? 0 : Convert.ToInt32(txtAge.Text);
            patient.PatientDetails.Occupation = txtOccupation.Text;

            patientDetail = new clsPatientDetails();
            patientDetail.Update(patient.PatientId, patient.PatientDetails);
        }

        /// <summary>
        /// Reload form after closing range of motion form
        /// </summary>
        public void ReloadForm()
        {
            try
            {
                Navigation();

                if (patient != null || patient.PatientId != 0)
                    AssignValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
