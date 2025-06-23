using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supernatural_Creature_Monitoring_System
{
    public partial class MainPage : UserControl
    {
        private MainForm parent;
        public MainPage(MainForm form)
        {
            InitializeComponent();
            parent = form;
            this.BackColor = Color.FromArgb(183, 187, 189);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            SetRelativeSize(lblMainPage, 1, 0.3);
            CenterControl(lblMainPage, 1);
            lblMainPage.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.03f);
            lblMainPage.Text = "Supernatural Creature\nMonitoring System";

            SetRelativeSize(btnCreatures, 0.3, 0.1);
            CenterControl(btnCreatures, 7);
            btnCreatures.FlatStyle = FlatStyle.Flat;
            btnCreatures.BackColor = Color.FromArgb(183, 187, 189);
            btnCreatures.FlatAppearance.BorderSize = 0;
            btnCreatures.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.02f);

            SetRelativeSize(btnAgents, 0.3, 0.1);
            CenterControl(btnAgents,10);
            btnAgents.FlatStyle = FlatStyle.Flat;
            btnAgents.BackColor = Color.FromArgb(183, 187, 189);
            btnAgents.FlatAppearance.BorderSize = 0;
            btnAgents.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.02f);

            SetRelativeSize(btnIncidentReports, 0.3, 0.1);
            CenterControl(btnIncidentReports, 13);
            btnIncidentReports.FlatStyle = FlatStyle.Flat;
            btnIncidentReports.BackColor = Color.FromArgb(183, 187, 189);
            btnIncidentReports.FlatAppearance.BorderSize = 0;
            btnIncidentReports.Font = new Font("Perpetua Titling MT", this.ClientSize.Width * 0.02f);

        }

        private void btnCreatures_Click(object sender, EventArgs e)
        {
            parent.LoadPage(new CreaturesPage());
        }

        private void btnAgents_Click(object sender, EventArgs e)
        {
            parent.LoadPage(new AgentsPage());
        }

        private void btnIncidentReports_Click(object sender, EventArgs e)
        {
            parent.LoadPage(new IncidentReportsPage());
        }

        private void CenterControl(Control control, int partOfSixteen)
        {
            control.Anchor = AnchorStyles.None;
            control.Left = (int)(this.ClientSize.Width - control.Width) / 2;
            control.Top = (int)(this.ClientSize.Height - control.Height) * partOfSixteen / 16;
        }
        private void SetRelativeSize(Control control, double widthRatio, double heightRatio)
        {
            control.Width = (int)(this.ClientSize.Width * widthRatio);
            control.Height = (int)(this.ClientSize.Height * heightRatio);
        }
    }
}
