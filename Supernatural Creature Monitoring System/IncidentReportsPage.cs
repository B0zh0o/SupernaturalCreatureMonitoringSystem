using Business.Controllers;
using Data;
using Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Supernatural_Creature_Monitoring_System
{
    public partial class IncidentReportsPage : UserControl
    {
        private static MyAppContext context = new MyAppContext();
        private IncidentReportController incidentReportController = new IncidentReportController(context);
        private CreatureController creatureController = new CreatureController(context);
        private AgentController agentController = new AgentController(context);
        private int editId = 0;
        public IncidentReportsPage()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(183, 187, 189);
        }

        private void IncidentReportsPage_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            lblDate.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblLocation.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblCreature.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblAgent.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);

            txtDate.Left = (int)(lblDate.Left + lblDate.Width + this.ClientSize.Width * 0.005f);
            txtLocation.Left = (int)(lblLocation.Left + lblLocation.Width + this.ClientSize.Width * 0.005f);
            txtCreature.Left = (int)(lblCreature.Left + lblCreature.Width + this.ClientSize.Width * 0.005f);
            txtAgent.Left = (int)(lblAgent.Left + lblAgent.Width + this.ClientSize.Width * 0.005f);

            float margin = this.ClientSize.Width * 0.005f;
            txtDate.Width = (int)(dataGridView.Left - (lblDate.Left + lblDate.Width + margin + 6 * margin));
            txtLocation.Width = (int)(dataGridView.Left - (lblLocation.Left + lblLocation.Width + margin + 6 * margin));
            txtCreature.Width = (int)(dataGridView.Left - (lblCreature.Left + lblCreature.Width + margin + 6 *  margin));
            txtAgent.Width = (int)(dataGridView.Left - (lblAgent.Left + lblAgent.Width + margin + 6 * margin));

            btnAdd.Left = lblAgent.Left;
            int buttonWidth = (int)((dataGridView.Left - (btnAdd.Left + 6 * margin + 2 * margin / 2)) / 3);
            btnAdd.Width = buttonWidth;
            btnUpdate.Left = (int)(btnAdd.Left + btnAdd.Width + margin / 2);
            btnUpdate.Width = buttonWidth;
            btnDelete.Left = (int)(btnUpdate.Left + btnUpdate.Width + margin / 2);
            btnDelete.Width = buttonWidth;

            btnSave.Left = btnAdd.Left;
            btnSave.Width = (int)(btnAdd.Width + btnUpdate.Width + btnDelete.Width + 2 * margin / 2);

            btnBack.Left = 0;
            btnBack.Top = 0;
            btnBack.Width = (int)(lblAgent.Left) - 10;
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
            dataGridView.DataSource = incidentReportController.ReadAll();
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridView.Columns["Date"] != null)
            {
                dataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/mm/yyyy";
            }
        }

        private void ClearTextBoxes()
        {
            txtDate.Clear();
            txtLocation.Clear();
            txtCreature.Clear();
            txtAgent.Clear();
        }
        private void UpdateTextBoxes(int id)
        {
            IncidentReport update = incidentReportController.Read(id);
            txtDate.Text = update.Date.ToString("dd/mm/yyyy");
            txtLocation.Text = update.Location;
            txtCreature.Text = update.CreatureId.ToString();
            txtAgent.Text = update.AgentId.ToString();
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
        private IncidentReport GetEditedIncidentReport()
        {
            IncidentReport incidentReport = new IncidentReport();

            incidentReport.Id = editId;

            DateTime date = DateTime.ParseExact(txtDate.Text, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var location = txtLocation.Text;
            var creature = txtCreature.Text;
            var agent = txtAgent.Text;

            incidentReport.Date = date;
            incidentReport.Location = location;
            incidentReport.CreatureId = Convert.ToInt32(creature);
            incidentReport.AgentId = Convert.ToInt32(agent);

            return incidentReport;
        }
        private void ResetSelected()
        {
            dataGridView.ClearSelection();
            dataGridView.Enabled = true;
        }

        private bool DoAllAddAndSaveChecks()
        {
            if (string.IsNullOrWhiteSpace(txtDate.Text) || string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(txtCreature.Text))
            {
                MessageBox.Show("Please fill in all fields before adding an incident report.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!context.Creatures.Contains(creatureController.Read(Convert.ToInt32(txtCreature.Text))))
            {
                MessageBox.Show("There is no such creature with this ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!context.Agents.Contains(agentController.Read(Convert.ToInt32(txtAgent.Text))))
            {
                MessageBox.Show("There is no such agent with this ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParseExact(txtDate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                MessageBox.Show("Date must be in format DD/MM/YYYY and valid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!DoAllAddAndSaveChecks())
                return;

            DateTime date = DateTime.ParseExact(txtDate.Text, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string location = txtLocation.Text;
            var creatureId = Convert.ToInt32(txtCreature.Text);
            var agentId = Convert.ToInt32(txtAgent.Text);

            IncidentReport incidentReport = new IncidentReport(date, location, creatureId, agentId);
            incidentReportController.Create(incidentReport);
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
                incidentReportController.Delete(id);
                UpdateGrid();
                ResetSelected();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DoAllAddAndSaveChecks())
                return;

            IncidentReport editedIncidentReport = GetEditedIncidentReport();
            incidentReportController.Update(editedIncidentReport);
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
