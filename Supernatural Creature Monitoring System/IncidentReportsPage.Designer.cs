namespace Supernatural_Creature_Monitoring_System
{
    partial class IncidentReportsPage
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
            txtCreature = new TextBox();
            txtLocation = new TextBox();
            txtDate = new TextBox();
            lblAgent = new Label();
            lblCreature = new Label();
            lblLocation = new Label();
            lblDate = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dataGridView = new DataGridView();
            txtAgent = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(15, 236);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(32, 29);
            btnBack.TabIndex = 26;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 397);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(420, 34);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCreature
            // 
            txtCreature.Location = new Point(165, 198);
            txtCreature.Name = "txtCreature";
            txtCreature.Size = new Size(182, 27);
            txtCreature.TabIndex = 23;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(205, 129);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(142, 27);
            txtLocation.TabIndex = 22;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(156, 69);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(191, 27);
            txtDate.TabIndex = 21;
            // 
            // lblAgent
            // 
            lblAgent.AutoSize = true;
            lblAgent.ForeColor = SystemColors.ButtonHighlight;
            lblAgent.Location = new Point(42, 266);
            lblAgent.Name = "lblAgent";
            lblAgent.Size = new Size(71, 20);
            lblAgent.TabIndex = 20;
            lblAgent.Text = "Agent ID:";
            // 
            // lblCreature
            // 
            lblCreature.AutoSize = true;
            lblCreature.ForeColor = SystemColors.ButtonHighlight;
            lblCreature.Location = new Point(36, 201);
            lblCreature.Name = "lblCreature";
            lblCreature.Size = new Size(87, 20);
            lblCreature.TabIndex = 19;
            lblCreature.Text = "Creature ID:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.ForeColor = SystemColors.ButtonHighlight;
            lblLocation.Location = new Point(36, 132);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(69, 20);
            lblLocation.TabIndex = 18;
            lblLocation.Text = "Location:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = SystemColors.ButtonHighlight;
            lblDate.Location = new Point(36, 72);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 20);
            lblDate.TabIndex = 17;
            lblDate.Text = "Date:";
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
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(501, 48);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(333, 408);
            dataGridView.TabIndex = 27;
            // 
            // txtAgent
            // 
            txtAgent.Location = new Point(165, 263);
            txtAgent.Name = "txtAgent";
            txtAgent.Size = new Size(182, 27);
            txtAgent.TabIndex = 28;
            // 
            // IncidentReportsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtAgent);
            Controls.Add(dataGridView);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtCreature);
            Controls.Add(txtLocation);
            Controls.Add(txtDate);
            Controls.Add(lblAgent);
            Controls.Add(lblCreature);
            Controls.Add(lblLocation);
            Controls.Add(lblDate);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "IncidentReportsPage";
            Size = new Size(884, 497);
            Load += IncidentReportsPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnSave;
        private TextBox txtCreature;
        private TextBox txtLocation;
        private TextBox txtDate;
        private Label lblAgent;
        private Label lblCreature;
        private Label lblLocation;
        private Label lblDate;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dataGridView;
        private TextBox txtAgent;
    }
}
