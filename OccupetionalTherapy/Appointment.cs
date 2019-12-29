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

        public Appointment()
        {
            InitializeComponent();
            RetrieveTodayAppointment();
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnViewToday_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
            DataTable result = new DataTable();
            appointment = new clsAppointment();
            result = appointment.Retrieve();

            if (result != null || result.Rows.Count > 0)
                grdAppointment.DataSource = result;
        }

      
    }
}
