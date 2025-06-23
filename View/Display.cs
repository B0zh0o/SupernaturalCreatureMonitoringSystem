using Business;
using Business.Controllers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Display
    {
        private readonly CreatureController _creatureController;
        private readonly AgentController _agentController;
        private readonly IncidentReportController _incidentReportController;

        public Display(
            CreatureController creatureController,
            AgentController agentController,
            IncidentReportController incidentReportController)
        {
            _agentController = agentController;
            _creatureController = creatureController;
            _incidentReportController = incidentReportController;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Creatures");
                Console.WriteLine("2. Agents");
                Console.WriteLine("3. Incident Reports");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreatureMenu();
                        break;
                    case "2":
                        AgentMenu();
                        break;
                    case "3":
                        IncidentReportMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AgentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Agent Menu ---");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. List Agents");
                Console.WriteLine("3. Update Agent");
                Console.WriteLine("4. Delete Agent");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Rank (single char): ");
                        char rank = Console.ReadKey().KeyChar;
                        Console.ReadLine();
                        Console.Write("Artifacts: ");
                        var artifacts = Console.ReadLine();
                        // Creating Agent without any incident reports at creation
                        Agent newAgent = new Agent(name, rank, artifacts, new List<IncidentReport>());
                        _agentController.Create(newAgent);
                        Console.WriteLine("Agent added. Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        var agents = _agentController.ReadAll();
                        Console.WriteLine("--- Agents List ---");
                        foreach (var agent in agents)
                        {
                            Console.WriteLine($"{agent.Id}: {agent.Name}, Rank: {agent.Rank}, Artifacts: {agent.Artifacts}");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter Agent ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateAgentId))
                        {
                            var agentToUpdate = _agentController.Read(updateAgentId);
                            if (agentToUpdate != null)
                            {
                                Console.Write("New Name: ");
                                agentToUpdate.Name = Console.ReadLine();
                                Console.Write("New Rank (single char): ");
                                agentToUpdate.Rank = Console.ReadKey().KeyChar;
                                Console.ReadLine();
                                Console.Write("New Artifacts: ");
                                agentToUpdate.Artifacts = Console.ReadLine();
                                _agentController.Update(agentToUpdate);
                                Console.WriteLine("Agent updated.");
                            }
                            else
                            {
                                Console.WriteLine("Agent not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Write("Enter Agent ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteAgentId))
                        {
                            _agentController.Delete(deleteAgentId);
                            Console.WriteLine("Agent deleted (if ID existed).");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreatureMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Creature Menu ---");
                Console.WriteLine("1. Add Creature");
                Console.WriteLine("2. List Creatures");
                Console.WriteLine("3. Update Creature");
                Console.WriteLine("4. Delete Creature");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Type: ");
                        var type = Console.ReadLine();
                        Console.Write("Threat Level (int): ");
                        if (!int.TryParse(Console.ReadLine(), out int threatLevel))
                        {
                            Console.WriteLine("Invalid threat level.");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Status: ");
                        var status = Console.ReadLine();
                        // Creating Creature without any incident reports at creation
                        Creature newCreature = new Creature(type, threatLevel, status, new List<IncidentReport>());
                        _creatureController.Create(newCreature);
                        Console.WriteLine("Creature added. Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        var creatures = _creatureController.ReadAll();
                        Console.WriteLine("--- Creatures List ---");
                        foreach (var creature in creatures)
                        {
                            Console.WriteLine($"{creature.Id}: {creature.Type}, Threat Level: {creature.ThreatLevel}, Status: {creature.Status}");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter Creature ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateCreatureId))
                        {
                            var creatureToUpdate = _creatureController.Read(updateCreatureId);
                            if (creatureToUpdate != null)
                            {
                                Console.Write("New Type: ");
                                creatureToUpdate.Type = Console.ReadLine();
                                Console.Write("New Threat Level: ");
                                if (int.TryParse(Console.ReadLine(), out int newThreatLevel))
                                    creatureToUpdate.ThreatLevel = newThreatLevel;
                                else
                                    Console.WriteLine("Invalid threat level input.");
                                Console.Write("New Status: ");
                                creatureToUpdate.Status = Console.ReadLine();
                                _creatureController.Update(creatureToUpdate);
                                Console.WriteLine("Creature updated.");
                            }
                            else
                            {
                                Console.WriteLine("Creature not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Write("Enter Creature ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteCreatureId))
                        {
                            _creatureController.Delete(deleteCreatureId);
                            Console.WriteLine("Creature deleted (if ID existed).");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void IncidentReportMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Incident Report Menu ---");
                Console.WriteLine("1. Add Incident Report");
                Console.WriteLine("2. List Incident Reports");
                Console.WriteLine("3. Update Incident Report");
                Console.WriteLine("4. Delete Incident Report");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        IncidentReport newReport = new IncidentReport();
                        Console.Write("Date (yyyy-mm-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                            newReport.Date = date;
                        else
                        {
                            Console.WriteLine("Invalid date.");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Location: ");
                        newReport.Location = Console.ReadLine();
                        Console.Write("Creature ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int creatureId))
                        {
                            Console.WriteLine("Invalid Creature ID.");
                            Console.ReadKey();
                            break;
                        }
                        newReport.CreatureId = creatureId;
                        Console.Write("Agent ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int agentId))
                        {
                            Console.WriteLine("Invalid Agent ID.");
                            Console.ReadKey();
                            break;
                        }
                        newReport.AgentId = agentId;

                        _incidentReportController.Create(newReport);
                        Console.WriteLine("Incident Report added.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        var reports = _incidentReportController.ReadAll();
                        Console.WriteLine("--- Incident Reports List ---");
                        foreach (var report in reports)
                        {
                            Console.WriteLine($"{report.Id}: {report.Date.ToShortDateString()} at {report.Location}, Agent ID: {report.AgentId}, Creature ID: {report.CreatureId}");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter Incident Report ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateReportId))
                        {
                            var reportToUpdate = _incidentReportController.Read(updateReportId);
                            if (reportToUpdate != null)
                            {
                                Console.Write("New Date (yyyy-mm-dd): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                                    reportToUpdate.Date = newDate;
                                else
                                    Console.WriteLine("Invalid date input.");
                                Console.Write("New Location: ");
                                reportToUpdate.Location = Console.ReadLine();
                                Console.Write("New Creature ID: ");
                                if (int.TryParse(Console.ReadLine(), out int newCreatureId))
                                    reportToUpdate.CreatureId = newCreatureId;
                                else
                                    Console.WriteLine("Invalid Creature ID.");
                                Console.Write("New Agent ID: ");
                                if (int.TryParse(Console.ReadLine(), out int newAgentId))
                                    reportToUpdate.AgentId = newAgentId;
                                else
                                    Console.WriteLine("Invalid Agent ID.");
                                _incidentReportController.Update(reportToUpdate);
                                Console.WriteLine("Incident Report updated.");
                            }
                            else
                            {
                                Console.WriteLine("Incident Report not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Write("Enter Incident Report ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteReportId))
                        {
                            _incidentReportController.Delete(deleteReportId);
                            Console.WriteLine("Incident Report deleted (if ID existed).");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
