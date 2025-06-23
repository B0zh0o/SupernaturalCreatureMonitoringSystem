namespace Supernatural_Creature_Monitoring_System
{
    partial class AgentsPage
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
            btnBack = new Button();
            btnSave = new Button();
            txtIncidentReports = new RichTextBox();
            txtRank = new TextBox();
            txtName = new TextBox();
            lblIncidentReports = new Label();
            lblArtifacts = new Label();
            lblRank = new Label();
            lblName = new Label();
            dataGridView = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtArtifacts = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(28, 236);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(32, 29);
            btnBack.TabIndex = 27;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 397);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(420, 34);
            btnSave.TabIndex = 26;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtIncidentReports
            // 
            txtIncidentReports.Location = new Point(70, 262);
            txtIncidentReports.Name = "txtIncidentReports";
            txtIncidentReports.Size = new Size(290, 78);
            txtIncidentReports.TabIndex = 25;
            txtIncidentReports.Text = "";
            // 
            // txtRank
            // 
            txtRank.Location = new Point(218, 72);
            txtRank.Name = "txtRank";
            txtRank.Size = new Size(142, 27);
            txtRank.TabIndex = 23;
            // 
            // txtName
            // 
            txtName.Location = new Point(169, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(191, 27);
            txtName.TabIndex = 22;
            // 
            // lblIncidentReports
            // 
            lblIncidentReports.AutoSize = true;
            lblIncidentReports.ForeColor = SystemColors.ButtonHighlight;
            lblIncidentReports.Location = new Point(40, 239);
            lblIncidentReports.Name = "lblIncidentReports";
            lblIncidentReports.Size = new Size(166, 20);
            lblIncidentReports.TabIndex = 21;
            lblIncidentReports.Text = "ID's of Incident Reports:";
            // 
            // lblArtifacts
            // 
            lblArtifacts.AutoSize = true;
            lblArtifacts.ForeColor = SystemColors.ButtonHighlight;
            lblArtifacts.Location = new Point(40, 116);
            lblArtifacts.Name = "lblArtifacts";
            lblArtifacts.Size = new Size(67, 20);
            lblArtifacts.TabIndex = 20;
            lblArtifacts.Text = "Artifacts:";
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.ForeColor = SystemColors.ButtonHighlight;
            lblRank.Location = new Point(36, 75);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(44, 20);
            lblRank.TabIndex = 19;
            lblRank.Text = "Rank:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = SystemColors.ButtonHighlight;
            lblName.Location = new Point(36, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 18;
            lblName.Text = "Name:";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(523, 44);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(333, 408);
            dataGridView.TabIndex = 17;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(338, 356);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 34);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(190, 356);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(124, 34);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(42, 356);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(124, 34);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtArtifacts
            // 
            txtArtifacts.Location = new Point(70, 139);
            txtArtifacts.Name = "txtArtifacts";
            txtArtifacts.Size = new Size(290, 97);
            txtArtifacts.TabIndex = 28;
            txtArtifacts.Text = "";
            // 
            // AgentsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtArtifacts);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtIncidentReports);
            Controls.Add(txtRank);
            Controls.Add(txtName);
            Controls.Add(lblIncidentReports);
            Controls.Add(lblArtifacts);
            Controls.Add(lblRank);
            Controls.Add(lblName);
            Controls.Add(dataGridView);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "AgentsPage";
            Size = new Size(884, 497);
            Load += AgentsPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnSave;
        private RichTextBox txtIncidentReports;
        private TextBox txtRank;
        private TextBox txtName;
        private Label lblIncidentReports;
        private Label lblArtifacts;
        private Label lblRank;
        private Label lblName;
        private DataGridView dataGridView;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private RichTextBox txtArtifacts;
    }
}
