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
        public Appointment()
        {
            InitializeComponent();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            RangeOfMotion range = new RangeOfMotion(this, NavigationType.Appointments);
            range.ShowDialog();
        }

        public void SetLabel(string label)
        {
            //lblTest.Text = label;
        }
    }
}
