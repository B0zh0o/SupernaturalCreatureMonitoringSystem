using Business.Controllers;
using Data;
using View;
using System.Windows.Forms;
namespace Supernatural_Creature_Monitoring_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MyAppContext context  = new MyAppContext();
            CreatureController creatureController = new CreatureController(context);
            AgentController agentController = new AgentController(context);
            IncidentReportController incidentReportController = new IncidentReportController(context);

            Console.WriteLine("Choose UI mode:");
            Console.WriteLine("1. Console");
            Console.WriteLine("2. Graphical (WinForms)");
            Console.Write("Enter choice (1 or 2): ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                RunConsoleUI(creatureController, agentController, incidentReportController);
            }
            else if(input == "2")
            {
                RunGraphicalUI();
            }
        }

        static void RunConsoleUI(CreatureController creatureController, AgentController agentController, IncidentReportController incidentReportController)
        {
            Console.WriteLine("Console UI started...");
            var consoleApp = new Display(creatureController, agentController, incidentReportController);
            consoleApp.Run();
        }

        static void RunGraphicalUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}