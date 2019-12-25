namespace OccupetionalTherapy
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new XanderUI.XUIButton();
            this.btnPatients = new XanderUI.XUIButton();
            this.btnNewPatient = new XanderUI.XUIButton();
            this.btnAppointments = new XanderUI.XUIButton();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).BeginInit();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splContainer
            // 
            this.splContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContainer.Location = new System.Drawing.Point(0, 0);
            this.splContainer.Name = "splContainer";
            // 
            // splContainer.Panel1
            // 
            this.splContainer.Panel1.Controls.Add(this.btnSearch);
            this.splContainer.Panel1.Controls.Add(this.btnPatients);
            this.splContainer.Panel1.Controls.Add(this.btnNewPatient);
            this.splContainer.Panel1.Controls.Add(this.btnAppointments);
            this.splContainer.Size = new System.Drawing.Size(1002, 679);
            this.splContainer.SplitterDistance = 239;
            this.splContainer.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundColor = System.Drawing.Color.White;
            this.btnSearch.ButtonImage = null;
            this.btnSearch.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.ClickBackColor = System.Drawing.Color.Black;
            this.btnSearch.ClickTextColor = System.Drawing.Color.Black;
            this.btnSearch.CornerRadius = 5;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSearch.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSearch.HoverBackgroundColor = System.Drawing.Color.Black;
            this.btnSearch.HoverTextColor = System.Drawing.Color.White;
            this.btnSearch.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnSearch.Location = new System.Drawing.Point(0, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(239, 50);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextColor = System.Drawing.Color.Black;
            this.btnSearch.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPatients
            // 
            this.btnPatients.BackgroundColor = System.Drawing.Color.White;
            this.btnPatients.ButtonImage = null;
            this.btnPatients.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnPatients.ButtonText = "Patients";
            this.btnPatients.ClickBackColor = System.Drawing.Color.Black;
            this.btnPatients.ClickTextColor = System.Drawing.Color.Black;
            this.btnPatients.CornerRadius = 5;
            this.btnPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnPatients.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnPatients.HoverBackgroundColor = System.Drawing.Color.Black;
            this.btnPatients.HoverTextColor = System.Drawing.Color.White;
            this.btnPatients.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnPatients.Location = new System.Drawing.Point(0, 100);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(239, 50);
            this.btnPatients.TabIndex = 2;
            this.btnPatients.TextColor = System.Drawing.Color.Black;
            this.btnPatients.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.BackgroundColor = System.Drawing.Color.White;
            this.btnNewPatient.ButtonImage = null;
            this.btnNewPatient.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnNewPatient.ButtonText = "New Patient";
            this.btnNewPatient.ClickBackColor = System.Drawing.Color.Black;
            this.btnNewPatient.ClickTextColor = System.Drawing.Color.Black;
            this.btnNewPatient.CornerRadius = 5;
            this.btnNewPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnNewPatient.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnNewPatient.HoverBackgroundColor = System.Drawing.Color.Black;
            this.btnNewPatient.HoverTextColor = System.Drawing.Color.White;
            this.btnNewPatient.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnNewPatient.Location = new System.Drawing.Point(0, 50);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(239, 50);
            this.btnNewPatient.TabIndex = 1;
            this.btnNewPatient.TextColor = System.Drawing.Color.Black;
            this.btnNewPatient.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackgroundColor = System.Drawing.Color.White;
            this.btnAppointments.ButtonImage = null;
            this.btnAppointments.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAppointments.ButtonText = "Appointments";
            this.btnAppointments.ClickBackColor = System.Drawing.Color.Black;
            this.btnAppointments.ClickTextColor = System.Drawing.Color.Black;
            this.btnAppointments.CornerRadius = 5;
            this.btnAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAppointments.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAppointments.HoverBackgroundColor = System.Drawing.Color.Black;
            this.btnAppointments.HoverTextColor = System.Drawing.Color.White;
            this.btnAppointments.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAppointments.Location = new System.Drawing.Point(0, 0);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(239, 50);
            this.btnAppointments.TabIndex = 0;
            this.btnAppointments.TextColor = System.Drawing.Color.Black;
            this.btnAppointments.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 679);
            this.Controls.Add(this.splContainer);
            this.Name = "Main";
            this.Text = "Form1";
            this.splContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).EndInit();
            this.splContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splContainer;
        private XanderUI.XUIButton btnSearch;
        private XanderUI.XUIButton btnPatients;
        private XanderUI.XUIButton btnNewPatient;
        private XanderUI.XUIButton btnAppointments;
    }
}

