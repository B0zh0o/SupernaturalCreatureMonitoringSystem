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
using System.Xml.Linq;

namespace Supernatural_Creature_Monitoring_System
{
    public partial class CreaturesPage : UserControl
    {
        private static MyAppContext context = new MyAppContext();
        private CreatureController creatureController = new CreatureController(context);
        private readonly IncidentReportController incidentReportController = new IncidentReportController(context);
        private int editId = 0;
        public CreaturesPage()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(183, 187, 189);
        }

        private void CreaturesPage_Load(object sender, EventArgs e)
        {
            CreateDataGridView();
            lblType.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblThreatLevel.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblStatus.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);
            lblIncidentReports.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.015f);

            float margin = this.ClientSize.Width * 0.005f;
            txtType.Left = (int)(lblType.Left + lblType.Width + margin);
            txtThreatLevel.Left = (int)(lblThreatLevel.Left + lblThreatLevel.Width + margin);
            txtStatus.Left = (int)(lblStatus.Left + lblStatus.Width + margin);
            txtIncidentReports.Left = (int)(lblIncidentReports.Left);

            txtType.Width = (int)(dataGridView.Left - (lblType.Left + lblType.Width + margin + margin));
            txtThreatLevel.Width = (int)(dataGridView.Left - (lblThreatLevel.Left + lblThreatLevel.Width + margin + margin));
            txtStatus.Width = (int)(dataGridView.Left - (lblStatus.Left + lblStatus.Width + margin + margin));
            txtIncidentReports.Width = (int)(dataGridView.Left - (lblIncidentReports.Left + margin));

            btnAdd.Left = txtIncidentReports.Left;
            int buttonWidth = (int)((dataGridView.Left - (btnAdd.Left + margin + 2 * margin / 2)) / 3);
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
                var creatureData = context.Creatures
                    .Include(c => c.IncidentReports)
                    .Select(c => new
                    {
                        c.Id,
                        c.Type,
                        c.ThreatLevel,
                        c.Status,
                        ReportIDs = string.Join(", ", c.IncidentReports.Select(r => r.Id))
                    })
                    .ToList();

                dataGridView.DataSource = creatureData;
                dataGridView.ReadOnly = true;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            txtType.Clear();
            txtThreatLevel.Clear();
            txtStatus.Clear();
            txtIncidentReports.Clear();
        }
        private void UpdateTextBoxes(int id)
        {
            Creature update = creatureController.Read(id);
            txtType.Text = update.Type;
            txtThreatLevel.Text = update.ThreatLevel.ToString();
            txtStatus.Text = update.Status;
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
        private Creature GetEditedCreature()
        {
            Creature creature = new Creature();

            creature.Id = editId;

            var type = txtType.Text;
            int threatLevel;
            int.TryParse(txtThreatLevel.Text, out threatLevel);
            var status = txtStatus.Text;
            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr =>
                        {
                            bool success = int.TryParse(idStr.Trim(), out int id);
                            return new { success, id };
                        }).Where(x => x.success)
                .Select(x => x.id).ToList();
            creature.Type = type;
            creature.ThreatLevel = threatLevel;
            creature.Status = status;
            creature.IncidentReports = incidentReports.Select(id => incidentReportController.Read(id)).Where(report => report != null).ToList();

            return creature;
        }
        private void ResetSelected()
        {
            dataGridView.ClearSelection();
            dataGridView.Enabled = true;
        }
        private bool DoAllAddAndSaveChecks()
        {
            if (string.IsNullOrWhiteSpace(txtType.Text) || string.IsNullOrWhiteSpace(txtThreatLevel.Text) || string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields(except Incident Reports IDs) before adding a creature.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtThreatLevel.Text, out int threatLevelResult) || threatLevelResult < 0 || threatLevelResult > 10)
            {
                MessageBox.Show("Threat Level must be a number between 0 and 10.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr =>
            {
                bool success = int.TryParse(idStr.Trim(), out int id);
                return new { success, id };
            }).Where(x => x.success)
    .Select(x => x.id).ToList();

            foreach (int incidentReportId in incidentReports)
            {
                if (!context.IncidentReports.Contains(incidentReportController.Read(incidentReportId)))
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

            var type = txtType.Text;
            int threatLevel;
            int.TryParse(txtThreatLevel.Text, out threatLevel);
            var status = txtStatus.Text;
            var incidentReports = txtIncidentReports.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(idStr => int.TryParse(idStr.Trim(), out var id) ? id : (int?)null)
                .Where(id => id.HasValue).Select(id => id.Value).Distinct().ToList();

            Creature creature = new Creature(type, threatLevel, status, incidentReports.Select(id => incidentReportController.Read(id)).Where(report => report != null).ToList());

            creatureController.Create(creature);
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
                creatureController.Delete(id);
                UpdateGrid();
                ResetSelected();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!DoAllAddAndSaveChecks())
            return;

            Creature editedCreature = GetEditedCreature();
            creatureController.Update(editedCreature);
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
