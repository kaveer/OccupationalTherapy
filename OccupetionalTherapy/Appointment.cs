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
    public partial class Appointment : Form
    {
        private clsAppointment appointment;
        private clsPatientDetails patientDetails;
        private List<clsPatientModel> patients;
        private int selectedPatient = 0;

        public Appointment()
        {
            InitializeComponent();

            try
            {
                RetrieveTodayAppointment();
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

                ViewPatient viewPatient = new ViewPatient(selectedPatient, NavigationType.Appointments);
                viewPatient.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewToday_Click(object sender, EventArgs e)
        {
            RetrieveTodayAppointment();
            AssignToGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                patients = new List<clsPatientModel>();
                appointment = new clsAppointment();
                patientDetails = new clsPatientDetails();

                DateTime from = Convert.ToDateTime(dpFrom.Value);
                DateTime to = Convert.ToDateTime(dpTo.Value);

                if ((from > to) || (from == to))
                    throw new Exception("Invalid date");

                var patientsRow = appointment.Retrieve();
                if (patientsRow.Count > 0)
                {
                    foreach (var item in patientsRow)
                    {
                        item.PatientDetails = new clsPatientDetailsModel();
                        item.PatientDetails = patientDetails.GetByPatientId(item.PatientId);
                    }
                }

                foreach (var item in patientsRow)
                {
                    foreach (var appointment in item.Appointments)
                    {
                        if ((appointment.Appointment.Date >= from.Date) && (appointment.Appointment.Date <= to.Date))
                        {
                            clsPatientModel sort = new clsPatientModel
                            {
                                PatientDetails = new clsPatientDetailsModel(),
                                Appointments = new List<clsAppointmentModel>(),

                                PatientId = item.PatientId
                            };
                            sort.PatientDetails = item.PatientDetails;
                            sort.Appointments.Add(appointment);

                            patients.Add(sort);
                        }
                    }
                }

                AssignToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void xuiButton1_Click(object sender, EventArgs e)
        //{
        //    RangeOfMotion range = new RangeOfMotion(this, NavigationType.Appointments);
        //    range.ShowDialog();
        //}

        //public void SetLabel(string label)
        //{
        //    //lblTest.Text = label;
        //}

        private void RetrieveTodayAppointment()
        {
            patients = new List<clsPatientModel>();
            appointment = new clsAppointment();
            patientDetails = new clsPatientDetails();

            var patientsRow = appointment.Retrieve();
            if (patientsRow.Count > 0)
            {
                foreach (var item in patientsRow)
                {
                    item.PatientDetails = new clsPatientDetailsModel();
                    item.PatientDetails = patientDetails.GetByPatientId(item.PatientId);
                }
            }

            foreach (var item in patientsRow)
            {
                foreach (var appointment in item.Appointments)
                {
                    if (appointment.Appointment.ToString("MM/dd/yyyy") == DateTime.Today.ToString("MM/dd/yyy"))
                    {
                        clsPatientModel sort = new clsPatientModel
                        {
                            PatientDetails = new clsPatientDetailsModel(),
                            Appointments = new List<clsAppointmentModel>(),

                            PatientId = item.PatientId
                        };
                        sort.PatientDetails = item.PatientDetails;
                        sort.Appointments.Add(appointment);

                        patients.Add(sort);
                    }
                }
            }
        }

        private void AssignToGrid()
        {
            grdAppointment.DataSource = null;
            grdAppointment.Columns.Clear();
            grdAppointment.Rows.Clear();
            grdAppointment.DataBindings.Clear();

            if (patients.Count > 0)
            {
                grdAppointment.ColumnCount = 4;
                grdAppointment.Columns[0].Name = "patientId";
                grdAppointment.Columns[1].Name = "Surname";
                grdAppointment.Columns[2].Name = "Name";
                grdAppointment.Columns[3].Name = "Appoitment";

                foreach (var item in patients)
                {
                    if (item.Appointments.Count > 0)
                    {
                        foreach (var appoinment in item.Appointments)
                        {
                            string[] row = new string[] { item.PatientId.ToString(), item.PatientDetails.Surname, item.PatientDetails.Name, appoinment.Appointment.ToString() };
                            grdAppointment.Rows.Add(row);
                        }
                    }
                }

                grdAppointment.Columns[0].Visible = false;
                GridFormatting();
            }

        }

        private void GridFormatting()
        {
            grdAppointment.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grdAppointment.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            grdAppointment.CellBorderStyle = DataGridViewCellBorderStyle.None;

            grdAppointment.DefaultCellStyle.SelectionBackColor = Color.Black;
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
        }

        private void grdAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAppointment.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedPatient = Convert.ToInt32(grdAppointment.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
