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
    public partial class RangeOfMotion : Form
    {
        /// <summary>
        /// Reference : https://grantwinney.com/passing-data-between-two-forms-in-winforms/
        /// </summary>
        public NewPatient NewPatient;
        public Appointment Appointment;
        private ViewPatient ViewPatient;
        public NavigationType navigationType;
        private bool isNew;


        public RangeOfMotion()
        {
            InitializeComponent();
        }

        public RangeOfMotion(ViewPatient viewPatient, NavigationType navigation, bool isNew)
        {
            InitializeComponent();
            this.ViewPatient = viewPatient;
            this.navigationType = navigation;
            this.isNew = isNew;
        }

        public RangeOfMotion(NewPatient newPatient, NavigationType navigation)
        {
            InitializeComponent();
            this.NewPatient = newPatient;
            this.navigationType = navigation;
        }

        public RangeOfMotion(Appointment appointment, NavigationType navigation)
        {
            InitializeComponent();
            this.Appointment = appointment;
            this.navigationType = navigation;
        }

        private void RangeOfMotion_Load(object sender, EventArgs e)
        {
            switch (navigationType)
            {
                case NavigationType.Appointments:
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
                    if (true)
                    {

                    }
                    break;
                default:
                    break;
            }
        }


            //private void button1_Click(object sender, EventArgs e)
            //{
            //    switch (navigationType)
            //    {
            //        case NavigationType.Appointments:
            //            Appointment.SetLabel("tets");
            //            break;
            //        case NavigationType.NewPatient:
            //            NewPatient.SetName("some test here");
            //            break;
            //        case NavigationType.Patients:
            //            break;
            //        case NavigationType.Search:
            //            break;
            //        default:
            //            break;
            //    }

            //    this.Close();
            //}
        }
}
