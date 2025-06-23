namespace Supernatural_Creature_Monitoring_System
{
    partial class MainPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreatures = new Button();
            btnAgents = new Button();
            btnIncidentReports = new Button();
            lblMainPage = new Label();
            SuspendLayout();
            // 
            // btnCreatures
            // 
            btnCreatures.ForeColor = SystemColors.ButtonHighlight;
            btnCreatures.Location = new Point(85, 107);
            btnCreatures.Name = "btnCreatures";
            btnCreatures.Size = new Size(92, 29);
            btnCreatures.TabIndex = 1;
            btnCreatures.Text = "Creatures";
            btnCreatures.UseVisualStyleBackColor = true;
            btnCreatures.Click += btnCreatures_Click;
            // 
            // btnAgents
            // 
            btnAgents.ForeColor = SystemColors.ButtonHighlight;
            btnAgents.Location = new Point(85, 160);
            btnAgents.Name = "btnAgents";
            btnAgents.Size = new Size(94, 29);
            btnAgents.TabIndex = 2;
            btnAgents.Text = "Agents";
            btnAgents.UseVisualStyleBackColor = true;
            btnAgents.Click += btnAgents_Click;
            // 
            // btnIncidentReports
            // 
            btnIncidentReports.ForeColor = SystemColors.ButtonHighlight;
            btnIncidentReports.Location = new Point(44, 239);
            btnIncidentReports.Name = "btnIncidentReports";
            btnIncidentReports.Size = new Size(182, 29);
            btnIncidentReports.TabIndex = 3;
            btnIncidentReports.Text = "Incident Reports";
            btnIncidentReports.UseVisualStyleBackColor = true;
            btnIncidentReports.Click += btnIncidentReports_Click;
            // 
            // lblMainPage
            // 
            lblMainPage.Font = new Font("Perpetua Titling MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMainPage.ForeColor = SystemColors.ButtonHighlight;
            lblMainPage.Location = new Point(229, 61);
            lblMainPage.Name = "lblMainPage";
            lblMainPage.Size = new Size(342, 51);
            lblMainPage.TabIndex = 4;
            lblMainPage.Text = "Supernatural Creature Monitoring System";
            lblMainPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMainPage);
            Controls.Add(btnIncidentReports);
            Controls.Add(btnAgents);
            Controls.Add(btnCreatures);
            Name = "MainPage";
            Size = new Size(884, 497);
            Load += MainPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreatures;
        private Button btnAgents;
        private Button btnIncidentReports;
        private Label lblMainPage;
    }
}
