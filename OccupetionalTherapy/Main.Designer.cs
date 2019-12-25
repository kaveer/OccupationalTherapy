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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.btnAppointments = new XanderUI.XUIButton();
            this.btnNewPatient = new XanderUI.XUIButton();
            this.btnPatients = new XanderUI.XUIButton();
            this.btnSearch = new XanderUI.XUIButton();
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
            // btnAppointments
            // 
            this.btnAppointments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAppointments.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAppointments.ButtonImage")));
            this.btnAppointments.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAppointments.ButtonText = "Appointments";
            this.btnAppointments.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnAppointments.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAppointments.CornerRadius = 5;
            this.btnAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppointments.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAppointments.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnAppointments.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAppointments.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAppointments.Location = new System.Drawing.Point(0, 0);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(239, 50);
            this.btnAppointments.TabIndex = 0;
            this.btnAppointments.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnAppointments.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNewPatient.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnNewPatient.ButtonImage")));
            this.btnNewPatient.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnNewPatient.ButtonText = "New Patient";
            this.btnNewPatient.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnNewPatient.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnNewPatient.CornerRadius = 5;
            this.btnNewPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewPatient.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnNewPatient.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnNewPatient.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnNewPatient.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnNewPatient.Location = new System.Drawing.Point(0, 50);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(239, 50);
            this.btnNewPatient.TabIndex = 1;
            this.btnNewPatient.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnNewPatient.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // btnPatients
            // 
            this.btnPatients.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPatients.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnPatients.ButtonImage")));
            this.btnPatients.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnPatients.ButtonText = "Patients";
            this.btnPatients.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnPatients.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnPatients.CornerRadius = 5;
            this.btnPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatients.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnPatients.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnPatients.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnPatients.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnPatients.Location = new System.Drawing.Point(0, 100);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(239, 50);
            this.btnPatients.TabIndex = 2;
            this.btnPatients.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnPatients.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.ButtonImage")));
            this.btnSearch.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnSearch.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.CornerRadius = 5;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearch.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSearch.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSearch.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnSearch.Location = new System.Drawing.Point(0, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(239, 50);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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

