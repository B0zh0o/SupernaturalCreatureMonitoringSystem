namespace Supernatural_Creature_Monitoring_System
{
    public partial class MainForm : Form
    {
        private Panel contentPanel;
        public MainForm()
        {
            InitializeComponent();
            InitializeDynamicUI();
            LoadPage(new MainPage(this));
        }
        private void InitializeDynamicUI()
        {
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            Controls.Add(contentPanel);
            contentPanel.SendToBack();
        }
        public void LoadPage(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
