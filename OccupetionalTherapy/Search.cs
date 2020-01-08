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
    public partial class Search : Form
    {
        private clsPatientDetails patientDetails;
        private clsDateEntry dateEntry;
        private clsMedicalRecord medicalRecord;

        private List<clsPatientModel> patients;
        private int selectedPatient = 0;

        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RetrievePatient();
            SearchFilter();

            if (patients.Count > 0)
                AssignToGrid();
        }

       



        /// <summary>
        /// Retrieve patients data
        /// </summary>
        private void RetrievePatient()
        {
            patients = new List<clsPatientModel>();
            patientDetails = new clsPatientDetails();
            dateEntry = new clsDateEntry();
            medicalRecord = new clsMedicalRecord();

            patients = patientDetails.Retrieve();
            if (patients.Count > 0)
            {
                foreach (var item in patients)
                {
                    item.DateEntry = new clsDateEntryModel();
                    item.MedicalRecords = new clsPatientMedicalRecordModel();

                    item.DateEntry = dateEntry.GetbyPatientId(item.PatientId);
                    item.MedicalRecords = medicalRecord.GetByPatientId(item.PatientId);
                }
            }

        }
        private void SearchFilter()
        {
            if (patients.Count > 0)
            {
                List<clsPatientModel> searchResult = new List<clsPatientModel>();

                searchResult = searchResult
                                   .Concat(
                                           from patient in patients
                                           where patient.DateEntry.EntryDate.Date == Convert.ToDateTime(dptEntryDate.Value.Date)
                                           select patient)
                                   .ToList();

                searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.PatientDetails.DOB.Date == Convert.ToDateTime(dpDOB.Value.Date)
                                            select patient)
                                    .ToList();

                if (!string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.PatientDetails.Surname.ToLowerInvariant().Contains(txtSurname.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.PatientDetails.Name.ToLowerInvariant().Contains(txtName.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (!string.IsNullOrWhiteSpace(txtAge.Text))
                {
                    int safeAge = 0;
                    int.TryParse(txtAge.Text, out safeAge);

                    if (safeAge != 0)
                    {
                        searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.PatientDetails.Age == Convert.ToInt32(txtAge.Text.Trim())
                                            select patient)
                                    .ToList();
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtOccupation.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.PatientDetails.Occupation.ToLowerInvariant().Contains(txtOccupation.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (!string.IsNullOrWhiteSpace(txtDiagnosis.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.MedicalRecords.Diagnosis.ToLowerInvariant().Contains(txtDiagnosis.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (!string.IsNullOrWhiteSpace(txtBriefHistory.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.MedicalRecords.BriefHistory.ToLowerInvariant().Contains(txtBriefHistory.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (!string.IsNullOrWhiteSpace(txtPassMedicalHistory.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.MedicalRecords.PastMedicalHistory.ToLowerInvariant().Contains(txtPassMedicalHistory.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }


                searchResult = searchResult
                                .Concat(
                                        from patient in patients
                                        where patient.MedicalRecords.Swelling = cbxSwelling.Checked
                                        select patient)
                                .ToList();

                searchResult = searchResult
                               .Concat(
                                       from patient in patients
                                       where patient.MedicalRecords.Tenderness = cbxTenderness.Checked
                                       select patient)
                               .ToList();

                searchResult = searchResult
                               .Concat(
                                       from patient in patients
                                       where patient.MedicalRecords.Sensation = cbxSensation.Checked
                                       select patient)
                               .ToList();



                if (!string.IsNullOrWhiteSpace(txtSensation.Text))
                {
                    searchResult = searchResult
                                    .Concat(
                                            from patient in patients
                                            where patient.MedicalRecords.SensationDetails.ToLowerInvariant().Contains(txtSensation.Text.ToLowerInvariant().Trim())
                                            select patient)
                                    .ToList();
                }

                if (searchResult.Count > 0)
                {
                    patients = new List<clsPatientModel>();
                    patients = searchResult
                                    .Distinct()
                                    .ToList();
                }
            }
        }

        /// <summary>
        /// Assign search result to grid and formatting
        /// </summary>
        private void AssignToGrid()
        {
            grdPatient.DataSource = null;
            grdPatient.Columns.Clear();
            grdPatient.Rows.Clear();
            grdPatient.DataBindings.Clear();

            if (patients.Count > 0)
            {
                grdPatient.ColumnCount = 4;
                grdPatient.Columns[0].Name = "patientId";
                grdPatient.Columns[1].Name = "Surname";
                grdPatient.Columns[2].Name = "Name";
                grdPatient.Columns[3].Name = "Entry Date";

                foreach (var item in patients)
                {
                    string[] row = new string[] { item.PatientId.ToString(), item.PatientDetails.Surname, item.PatientDetails.Name, item.DateEntry.EntryDate.ToString("dd/MM/yyyy HH:mm:ss") };
                    grdPatient.Rows.Add(row);
                }

                grdPatient.Columns[0].Visible = false;
                GridFormatting();
            }
        }

        private void GridFormatting()
        {
            grdPatient.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grdPatient.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            grdPatient.CellBorderStyle = DataGridViewCellBorderStyle.None;

            grdPatient.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            grdPatient.DefaultCellStyle.SelectionForeColor = Color.White;

            grdPatient.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //grdPatient.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdPatient.AllowUserToResizeColumns = false;

            grdPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdPatient.RowHeadersVisible = false;
            grdPatient.AllowUserToAddRows = false;
            grdPatient.AllowUserToResizeRows = false;
            grdPatient.MultiSelect = false;

            grdPatient.ReadOnly = true;

            foreach (DataGridViewColumn column in grdPatient.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            grdPatient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPatient.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
        }

        /// <summary>
        /// Selected record and assign to patient Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdPatient.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    selectedPatient = Convert.ToInt32(grdPatient.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatient == 0)
                    throw new Exception("Select a patient to view details");

                ViewPatient viewPatient = new ViewPatient(selectedPatient, NavigationType.Search);
                viewPatient.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
