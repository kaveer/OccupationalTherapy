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
    public partial class Patients : Form
    {
        private clsPatientDetails patientDetails;
        private clsDateEntry dateEntry;

        private List<clsPatientModel> patients;
        private int selectedPatient = 0;

        public Patients()
        {
            InitializeComponent();
            btnDelete.Visible = false;
        }

        /// <summary>
        /// Load form and retrieve patients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Patients_Load(object sender, EventArgs e)
        {
            try
            {
                RetrievePatient();
                AssignToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve patients data
        /// </summary>
        private void RetrievePatient()
        {
            patients = new List<clsPatientModel>();
            patientDetails = new clsPatientDetails();

            patients = patientDetails.Retrieve();
            GetEntryDate();
        }

        private void GetEntryDate()
        {
            if (patients != null || patients.Count > 0)
            {
                foreach (var item in patients)
                {
                    dateEntry = new clsDateEntry();
                    item.DateEntry = dateEntry.GetbyPatientId(item.PatientId);
                }
            }
        }

        /// <summary>
        /// Assign to grid and formatting
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
                    string[] row = new string[] { item.PatientId.ToString(), item.PatientDetails.Surname, item.PatientDetails.Name, item.DateEntry.EntryDate.ToString("MM/dd/yyyy HH:mm:ss") };
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

            grdPatient.DefaultCellStyle.SelectionBackColor = Color.Black;
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
        /// Cell click to retrieve patientId
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSurname.Text) && string.IsNullOrWhiteSpace(txtName.Text))
                    throw new Exception("Enter patient details to search");

                RetrievePatient();
                string surname = txtSurname.Text.Trim();
                string name = txtName.Text.Trim();

                List<clsPatientModel> patientSearch = new List<clsPatientModel>();
                List<clsPatientModel> surnameSearch = new List<clsPatientModel>();
                List<clsPatientModel> nameSearch = new List<clsPatientModel>();

                if (!string.IsNullOrWhiteSpace(surname))
                {
                    surnameSearch = (from patient in patients
                                     where patient.PatientDetails.Surname.Contains(surname)
                                     select patient).ToList();
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    nameSearch = (from patient in patients
                                  where patient.PatientDetails.Name.Contains(name)
                                  select patient).ToList();
                }

                patientSearch = surnameSearch
                                    .Concat(nameSearch)
                                    .Distinct()
                                    .ToList();

                if (patientSearch.Count > 0)
                {
                    patients = new List<clsPatientModel>();
                    patients = patientSearch;
                }

                AssignToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnAllPatients_Click(object sender, EventArgs e)
        {
            try
            {
                RetrievePatient();
                AssignToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatient == 0)
                    throw new Exception("Select a patient to view details");

                ViewPatient viewPatient = new ViewPatient(selectedPatient, NavigationType.Patients);
                viewPatient.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ///VIsisble = false
            ///will not implement this function for now
        }
    }
}
