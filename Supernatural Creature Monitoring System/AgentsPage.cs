using Business.Controllers;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supernatural_Creature_Monitoring_System
{
    public partial class AgentsPage : UserControl
    {
        private static MyAppContext context = new MyAppContext();
        private AgentController agentController = new AgentController(context);
        private readonly IncidentReportController incidentReportController = new IncidentReportController(context);
        private int editId = 0;
        bool btnUpdateIsClicked = false;
        public AgentsPage()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(183, 187, 189);
        }
        private void AgentsPage_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            lblName.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblRank.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblArtifacts.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblIncidentReports.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);

            float margin = this.ClientSize.Width * 0.005f;
            txtName.Left = (int)(lblName.Left + lblName.Width + margin);
            txtRank.Left = (int)(lblRank.Left + lblRank.Width + margin);
            txtArtifacts.Left = lblArtifacts.Left;
            txtIncidentReports.Left = lblIncidentReports.Left;


            txtName.Width = (int)(dataGridView.Left - (lblName.Left + lblName.Width + margin + 6 * margin));
            txtRank.Width = (int)(dataGridView.Left - (lblRank.Left + lblRank.Width + margin + 6 * margin));
            txtArtifacts.Width = (int)(dataGridView.Left - (lblArtifacts.Left + margin + 6 * margin));
            txtIncidentReports.Width = (int)(dataGridView.Left - (lblIncidentReports.Left + margin + 6 * margin));

            btnAdd.Left = txtIncidentReports.Left;
            int buttonWidth = (int)((dataGridView.Left - (btnAdd.Left + 6 * margin + 2 * margin / 2)) / 3);
            btnAdd.Width = buttonWidth;
            btnUpdate.Left = (int)(btnAdd.Left + btnAdd.Width + margin / 2);
            btnUpdate.Width = buttonWidth;
            btnDelete.Left = (int)(btnUpdate.Left + btnUpdate.Width + margin / 2);
            btnDelete.Width = buttonWidth;

            btnSave.Left = btnAdd.Left;
            btnSave.Width = (int)(txtIncidentReports.Width);

            btnBack.Left = 0;
            btnBack.Top = 0;
            btnBack.Width = (int)(lblIncidentReports.Left - 10);
            btnBack.Height = (int)(this.ClientSize.Height);
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.BackColor = Color.FromArgb(183, 187, 189);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.02f);

            SetCRUDButtonStyles(btnAdd);
            SetCRUDButtonStyles(btnUpdate);
            SetCRUDButtonStyles(btnDelete);
            SetCRUDButtonStyles(btnSave);

            UpdateGrid();
            ClearTextBoxes();
            btnSave.Visible = false;
        }
        private void CreateDataGridView()
        {
            dataGridView.Anchor = AnchorStyles.None;
            dataGridView.Left = (int)(this.ClientSize.Width * 0.6);
            dataGridView.Top = (int)(this.ClientSize.Height * 0.05);
            int rightMargin = (int)(this.ClientSize.Width * 0.01);
            dataGridView.Width = (int)(this.ClientSize.Width - dataGridView.Left - rightMargin);
            int bottomMargin = (int)(this.ClientSize.Height * 0.05);
            dataGridView.Height = (int)(this.ClientSize.Height - dataGridView.Top - bottomMargin);
        }
        private void SetCRUDButtonStyles(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(183, 187, 189);
        }

        private void UpdateGrid()
        {
                var agentData = context.Agents
                    .Include(a => a.IncidentReports)
                    .Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.Rank,
                        a.Artifacts,
                        ReportIDs = string.Join(", ", a.IncidentReports.Select(r => r.Id))
                    })
                    .ToList();

                dataGridView.DataSource = agentData;
                dataGridView.ReadOnly = true;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtRank.Clear();
            txtArtifacts.Clear();
            txtIncidentReports.Clear();
        }
        private void UpdateTextBoxes(int id)
        {
            Agent update = agentController.Read(id);
            txtName.Text = update.Name;
            txtRank.Text = update.Rank.ToString();
            txtArtifacts.Text = update.Artifacts;
            txtIncidentReports.Text = string.Join(", ", update.IncidentReports.Select(ir => ir.Id));
        }
        private void ToggleSaveUpdate()
        {
            if (btnUpdate.Visible)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        private void DisableSelect()
        {
            dataGridView.Enabled = false;
        }
        private Agent GetEditedAgent()
        {
            Agent agent = new Agent();

            agent.Id = editId;

            var name = txtName.Text;
            var rank = txtRank.Text;
            var artifacts = txtArtifacts.Text;
            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr => int.TryParse(idStr.Trim(), out var id) ? id : (int?)null)
                .Where(id => id.HasValue).Select(id => id.Value).Distinct().ToList();

            agent.Name = name;
            agent.Rank = Convert.ToChar(rank);
            agent.Artifacts = artifacts;
            agent.IncidentReports = incidentReports.Select(id => incidentReportController.Read(id)).Where(report => report != null).ToList();

            return agent;
        }
        private void ResetSelected()
        {
            dataGridView.ClearSelection();
            dataGridView.Enabled = true;
        }

        private void InvisibleAddDelete()
        {
            btnDelete.Visible = false;
            btnAdd.Visible = false;
        }
        private void VisibleAddDelete()
        {
            btnDelete.Visible = true;
            btnAdd.Visible = true;
        }

        private bool DoAllAddAndSaveChecks()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtRank.Text) || string.IsNullOrWhiteSpace(txtArtifacts.Text))
            {
                MessageBox.Show("Please fill in all fields(except Incident Reports IDs) before adding an agent.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!char.TryParse(txtRank.Text, out char rankResult) || !(rankResult == 'S' || rankResult == 'A' || rankResult == 'B' || rankResult == 'C' || rankResult == 'D' || rankResult == 'E'))
            {
                MessageBox.Show("Please enter a valid rank(E, D, C, B, A, S).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr =>
            {
                bool success = int.TryParse(idStr.Trim(), out int id);
                return new { success, id };
            }).Where(x => x.success)
    .Select(x => x.id).ToList();

            foreach(int incidentReportId in incidentReports)
            {
                if(!context.IncidentReports.Contains(incidentReportController.Read(incidentReportId)))
                {
                    MessageBox.Show("There is no such Incident Report with this ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DoAllAddAndSaveChecks())
            return;

            var name = txtName.Text;
            char rank = Convert.ToChar(txtRank.Text);
            var artifacts = txtArtifacts.Text;
            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr =>
            {
                bool success = int.TryParse(idStr.Trim(), out int id);
                return new { success, id };
            }).Where(x => x.success)
    .Select(x => x.id).ToList();

            Agent agent = new Agent(name, rank, artifacts, incidentReports.Select(id => incidentReportController.Read(id)).Where(report => report != null).ToList());

            agentController.Create(agent);
            UpdateGrid();
            ClearTextBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                InvisibleAddDelete();
                var item = dataGridView.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                editId = id;
                UpdateTextBoxes(id);
                ToggleSaveUpdate();
                DisableSelect();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var item = dataGridView.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                agentController.Delete(id);
                UpdateGrid();
                ResetSelected();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DoAllAddAndSaveChecks())
            return;

            Agent editedAgent = GetEditedAgent();
            agentController.Update(editedAgent);
            UpdateGrid();
            ResetSelected();
            ToggleSaveUpdate();
            ClearTextBoxes();
            VisibleAddDelete();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is MainForm parentForm)
            {
                parentForm.LoadPage(new MainPage(parentForm));
            }
        }
    }
}
