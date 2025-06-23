namespace Supernatural_Creature_Monitoring_System
{
    partial class CreaturesPage
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
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView = new DataGridView();
            lblType = new Label();
            lblThreatLevel = new Label();
            lblStatus = new Label();
            lblIncidentReports = new Label();
            txtType = new TextBox();
            txtThreatLevel = new TextBox();
            txtStatus = new TextBox();
            txtIncidentReports = new RichTextBox();
            btnSave = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(42, 356);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(124, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(190, 356);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(124, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(338, 356);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(495, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(333, 408);
            dataGridView.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.ForeColor = SystemColors.ButtonHighlight;
            lblType.Location = new Point(36, 23);
            lblType.Name = "lblType";
            lblType.Size = new Size(43, 20);
            lblType.TabIndex = 4;
            lblType.Text = "Type:";
            // 
            // lblThreatLevel
            // 
            lblThreatLevel.AutoSize = true;
            lblThreatLevel.ForeColor = SystemColors.ButtonHighlight;
            lblThreatLevel.Location = new Point(36, 75);
            lblThreatLevel.Name = "lblThreatLevel";
            lblThreatLevel.Size = new Size(92, 20);
            lblThreatLevel.TabIndex = 5;
            lblThreatLevel.Text = "Threat Level:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = SystemColors.ButtonHighlight;
            lblStatus.Location = new Point(36, 126);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status:";
            // 
            // lblIncidentReports
            // 
            lblIncidentReports.AutoSize = true;
            lblIncidentReports.ForeColor = SystemColors.ButtonHighlight;
            lblIncidentReports.Location = new Point(36, 171);
            lblIncidentReports.Name = "lblIncidentReports";
            lblIncidentReports.Size = new Size(166, 20);
            lblIncidentReports.TabIndex = 7;
            lblIncidentReports.Text = "ID's of Incident Reports:";
            // 
            // txtType
            // 
            txtType.Location = new Point(141, 23);
            txtType.Name = "txtType";
            txtType.Size = new Size(191, 27);
            txtType.TabIndex = 8;
            // 
            // txtThreatLevel
            // 
            txtThreatLevel.Location = new Point(190, 72);
            txtThreatLevel.Name = "txtThreatLevel";
            txtThreatLevel.Size = new Size(142, 27);
            txtThreatLevel.TabIndex = 9;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(150, 123);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(182, 27);
            txtStatus.TabIndex = 10;
            // 
            // txtIncidentReports
            // 
            txtIncidentReports.Location = new Point(42, 194);
            txtIncidentReports.Name = "txtIncidentReports";
            txtIncidentReports.Size = new Size(290, 147);
            txtIncidentReports.TabIndex = 11;
            txtIncidentReports.Text = "";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 397);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(420, 34);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(0, 215);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(32, 29);
            btnBack.TabIndex = 13;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // CreaturesPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtIncidentReports);
            Controls.Add(txtStatus);
            Controls.Add(txtThreatLevel);
            Controls.Add(txtType);
            Controls.Add(lblIncidentReports);
            Controls.Add(lblStatus);
            Controls.Add(lblThreatLevel);
            Controls.Add(lblType);
            Controls.Add(dataGridView);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "CreaturesPage";
            Size = new Size(841, 454);
            Load += CreaturesPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView;
        private Label lblType;
        private Label lblThreatLevel;
        private Label lblStatus;
        private Label lblIncidentReports;
        private TextBox txtType;
        private TextBox txtThreatLevel;
        private TextBox txtStatus;
        private RichTextBox txtIncidentReports;
        private Button btnSave;
        private Button btnBack;
    }
}
