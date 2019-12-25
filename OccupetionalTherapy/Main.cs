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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            metroSetPanel1.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            this.TopLevel = true;
            Appointment app = new Appointment();
            app.TopLevel = false;
            app.FormBorderStyle = FormBorderStyle.None;
            app.Dock = DockStyle.Fill;
            metroSetPanel1.Controls.Clear();
            metroSetPanel1.Controls.Add(app);
            app.Visible = true;
        }

        private void xuiSegment1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
