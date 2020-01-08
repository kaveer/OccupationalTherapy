using Model;
using Model.Commun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OccupetionalTherapy
{
    public partial class Main : Form
    {
        public Main()
        {
            // To deploy
            //https://www.youtube.com/watch?v=tHFpyemNfrk

            InitializeComponent();
            splContainer.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);
            Configuration();

            try
            {
                Navigation(NavigationType.Appointments);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Navigation fails");
            }     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Configuration()
        {
            splContainer.Panel1.BackColor = clsHelper.navigationBackground;

            ButtonConfiguration();
        }

        private void ButtonConfiguration()
        {
            btnAppointments.BackgroundColor = clsHelper.buttonBackground;
            btnAppointments.HoverBackgroundColor = clsHelper.hoverBackground;
            btnAppointments.TextColor = clsHelper.bottonTextColor;
            btnAppointments.HoverTextColor = clsHelper.HoverTextColor;

            btnNewPatient.BackgroundColor = clsHelper.buttonBackground;
            btnNewPatient.HoverBackgroundColor = clsHelper.hoverBackground;
            btnNewPatient.TextColor = clsHelper.bottonTextColor;
            btnNewPatient.HoverTextColor = clsHelper.HoverTextColor;

            btnPatients.BackgroundColor = clsHelper.buttonBackground;
            btnPatients.HoverBackgroundColor = clsHelper.hoverBackground;
            btnPatients.TextColor = clsHelper.bottonTextColor;
            btnPatients.HoverTextColor = clsHelper.HoverTextColor;

            btnSearch.BackgroundColor = clsHelper.buttonBackground;
            btnSearch.HoverBackgroundColor = clsHelper.hoverBackground;
            btnSearch.TextColor = clsHelper.bottonTextColor;
            btnSearch.HoverTextColor = clsHelper.HoverTextColor;
        }

        /// <summary>
        /// nNavigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                Navigation(NavigationType.Appointments);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Navigation fails");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            try
            {
                Navigation(NavigationType.NewPatient);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Navigation fails");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            try
            {
                Navigation(NavigationType.Patients);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Navigation fails");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Navigation(NavigationType.Search);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Navigation fails");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Navigation(NavigationType navigation)
        {
            this.TopLevel = true;
            splContainer.Panel2.Controls.Clear();
           
            switch (navigation)
            {
                case NavigationType.Appointments:
                    Appointment appointment = new Appointment();
                    appointment.TopLevel = false;
                    appointment.FormBorderStyle = FormBorderStyle.None;
                    appointment.Dock = DockStyle.Fill;
                    splContainer.Panel2.Controls.Add(appointment);
                    appointment.Visible = true;

                    ButtonConfiguration();
                    btnAppointments.BackgroundColor = clsHelper.hoverBackground;
                    btnAppointments.TextColor = clsHelper.HoverTextColor;
                    break;
                case NavigationType.NewPatient:
                    NewPatient newPatient = new NewPatient();
                    newPatient.TopLevel = false;
                    newPatient.FormBorderStyle = FormBorderStyle.None;
                    newPatient.Dock = DockStyle.Fill;
                    splContainer.Panel2.Controls.Add(newPatient);
                    newPatient.Visible = true;

                    ButtonConfiguration();
                    btnNewPatient.BackgroundColor = clsHelper.hoverBackground;
                    btnNewPatient.TextColor = clsHelper.HoverTextColor;
                    break;
                case NavigationType.Patients:
                    Patients patient = new Patients();
                    patient.TopLevel = false;
                    patient.FormBorderStyle = FormBorderStyle.None;
                    patient.Dock = DockStyle.Fill;
                    splContainer.Panel2.Controls.Add(patient);
                    patient.Visible = true;

                    ButtonConfiguration();
                    btnPatients.BackgroundColor = clsHelper.hoverBackground;
                    btnPatients.TextColor = clsHelper.HoverTextColor;
                    break;
                case NavigationType.Search:
                    Search search = new Search();
                    search.TopLevel = false;
                    search.FormBorderStyle = FormBorderStyle.None;
                    search.Dock = DockStyle.Fill;
                    splContainer.Panel2.Controls.Add(search);
                    search.Visible = true;

                    ButtonConfiguration();
                    btnSearch.BackgroundColor = clsHelper.hoverBackground;
                    btnSearch.TextColor = clsHelper.HoverTextColor;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
