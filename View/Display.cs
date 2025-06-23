using Business;
using Business.Controllers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace View
{
    public class Display
    {
        private readonly CreatureController creatureController;
        private readonly AgentController agentController;
        private readonly IncidentReportController incidentReportController;

        public Display(
            CreatureController creatureController,
            AgentController agentController,
            IncidentReportController incidentReportController)
        {
            this.agentController = agentController;
            this.creatureController = creatureController;
            this.incidentReportController = incidentReportController;
        }

        public void Run()
        {
            while (true)
            {
                try
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
                            throw new ArgumentException("Invalid option in Main Menu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        private void AgentMenu()
        {
            while (true)
            {
                try
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
                            char rank;
                            while (true)
                            {
                                Console.Write("Rank (S, A, B, C, D, E): ");
                                string rankInput = Console.ReadLine().Trim().ToUpper();
                                if (rankInput.Length == 1 && "SABCDE".Contains(rankInput[0]))
                                {
                                    rank = rankInput[0];
                                    break;
                                }
                                Console.WriteLine("Invalid rank. Please enter one of the following: S, A, B, C, D, E.");
                            }

                            Console.Write("Artifacts (separated by ','): ");
                            var artifacts = Console.ReadLine();

                            List<IncidentReport> linkedReports = new List<IncidentReport>();
                            Console.Write("Incident Report ID (optional): ");
                            string reportInput = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(reportInput))
                            {
                                if (int.TryParse(reportInput, out int reportId))
                                {
                                    var report = incidentReportController.Read(reportId);
                                    if (report != null)
                                    {
                                        linkedReports.Add(report);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Warning: Incident Report not found. The agent has been added without an incident report.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Warning: Invalid Incident Report ID. The agent has been added without an incident report.");
                                }
                            }

                            Agent newAgent = new Agent(name, rank, artifacts, linkedReports);
                            agentController.Create(newAgent);
                            Console.WriteLine("Agent added. Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "2":
                            var agents = agentController.ReadAll();
                            Console.WriteLine("--- Agents List ---");
                            foreach (var agent in agents)
                            {
                                var reportIds = (agent.IncidentReports != null && agent.IncidentReports.Any())
                                    ? string.Join(", ", agent.IncidentReports.Select(r => r.Id))
                                    : "None";

                                Console.WriteLine($"{agent.Id}: {agent.Name}; Rank: {agent.Rank}; Artifacts: {agent.Artifacts}; Incident Report IDs: {reportIds}");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Write("Enter Agent ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int updateAgentId))
                            {
                                var agentToUpdate = agentController.Read(updateAgentId);
                                if (agentToUpdate != null)
                                {
                                    Console.Write("New Name: ");
                                    agentToUpdate.Name = Console.ReadLine();

                                    string newRankInput;
                                    while (true)
                                    {
                                        Console.Write("New Rank (S, A, B, C, D, E): ");
                                        newRankInput = Console.ReadLine().Trim().ToUpper();
                                        if (newRankInput.Length == 1 && "SABCDE".Contains(newRankInput))
                                            break;
                                        Console.WriteLine("Invalid rank. Please enter one of the following: S, A, B, C, D, E.");
                                    }
                                    agentToUpdate.Rank = newRankInput[0];

                                    Console.Write("New Artifacts (separated by ','): ");
                                    agentToUpdate.Artifacts = Console.ReadLine();

                                    Console.Write("Incident Report ID (optional): ");
                                    string updateReportInput = Console.ReadLine();  
                                    if (!string.IsNullOrWhiteSpace(updateReportInput))
                                    {
                                        if (int.TryParse(updateReportInput, out int reportId))
                                        {
                                            var report = incidentReportController.Read(reportId);
                                            if (report != null)
                                            {
                                                agentToUpdate.IncidentReports = new List<IncidentReport> { report };
                                            }
                                            else
                                            {
                                                Console.WriteLine("Warning: Incident Report not found. Incident report ID not changed.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Warning: Invalid Incident Report ID. Incident report ID not changed.");
                                        }
                                    }

                                    agentController.Update(agentToUpdate);
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
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;



                        case "4":
                            Console.Write("Enter Agent ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteAgentId))
                            {
                                agentController.Delete(deleteAgentId);
                                Console.WriteLine("Agent deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "0":
                            return;

                        default:
                            throw new ArgumentException("Invalid option in Agent Menu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                }
            }
        }

        private void CreatureMenu()
        {
            while (true)
            {
                try
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
                            Console.Write("Threat Level (between 1 and 10): ");
                            if (!int.TryParse(Console.ReadLine(), out int threatLevel))
                            {
                                if (threatLevel < 0 || threatLevel > 10)
                                {
                                    Console.WriteLine("Threat level must be a whole number between 1 and 10.");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            Console.Write("Status: ");
                            var status = Console.ReadLine();

                            List<IncidentReport> linkedReports = new List<IncidentReport>();
                            Console.Write("Incident Report ID (optional): ");
                            string reportInput = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(reportInput))
                            {
                                if (int.TryParse(reportInput, out int reportId))
                                {
                                    var report = incidentReportController.Read(reportId);
                                    if (report != null)
                                    {
                                        linkedReports.Add(report);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Warning: Incident Report not found. The creature has been added without an incident report.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Warning: Invalid Incident Report ID. The creature has been added without an incident report.");
                                }
                            }

                            Creature newCreature = new Creature(type, threatLevel, status, linkedReports);
                            creatureController.Create(newCreature);
                            Console.WriteLine("Creature added. Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "2":
                            var creatures = creatureController.ReadAll();
                            Console.WriteLine("--- Creatures List ---");
                            foreach (var creature in creatures)
                            {
                                Console.WriteLine($"{creature.Id}: {creature.Type}; Threat Level: {creature.ThreatLevel}; Status: {creature.Status}");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Write("Enter Creature ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int updateCreatureId))
                            {
                                var creatureToUpdate = creatureController.Read(updateCreatureId);
                                if (creatureToUpdate != null)
                                {
                                    Console.Write("New Type: ");
                                    creatureToUpdate.Type = Console.ReadLine();

                                    Console.Write("New Threat Level (between 1 and 10): ");
                                    if (int.TryParse(Console.ReadLine(), out int newThreatLevel))
                                    {
                                        if (newThreatLevel > 0 || newThreatLevel < 10)
                                        {
                                            creatureToUpdate.ThreatLevel = newThreatLevel;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid threat level input. Threat level has not been changed.");
                                    }

                                    Console.Write("New Status: ");
                                    creatureToUpdate.Status = Console.ReadLine();

                                    Console.Write("Incident Report ID(s) (optional): ");
                                    string updateReportInput = Console.ReadLine();  
                                    if (!string.IsNullOrWhiteSpace(updateReportInput))
                                    {
                                        if (int.TryParse(updateReportInput, out int reportId))
                                        {
                                            var report = incidentReportController.Read(reportId);
                                            if (report != null)
                                            {
                                                creatureToUpdate.IncidentReports = new List<IncidentReport> { report };
                                            }
                                            else
                                            {
                                                Console.WriteLine("Warning: Incident Report(s) not found. This creature's Incident Report(s) have not been updated.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Warning: Invalid Incident Report ID(s). This creature's Incident Report(s) have not been updated.");
                                        }
                                    }

                                    creatureController.Update(creatureToUpdate);
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
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;



                        case "4":
                            Console.Write("Enter Creature ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteCreatureId))
                            {
                                creatureController.Delete(deleteCreatureId);
                                Console.WriteLine("Creature deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "0":
                            return;

                        default:
                            throw new ArgumentException("Invalid option in Creature Menu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                }
            }
        }

        private void IncidentReportMenu()
        {
            while (true)
            {
                try
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
                            Console.Write("Date (dd/MM/yyyy): ");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime date))
                                newReport.Date = date;
                            else
                            {
                                Console.WriteLine("Invalid date format.");
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

                            incidentReportController.Create(newReport);
                            Console.WriteLine("Incident Report added.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "2":
                            var reports = incidentReportController.ReadAll();
                            Console.WriteLine("--- Incident Reports List ---");
                            foreach (var report in reports)
                            {
                                Console.WriteLine($"{report.Id}: {report.Date.ToString("dd/mm/yyyy")} at {report.Location}; Agent ID: {report.AgentId}; Creature ID: {report.CreatureId}");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Write("Enter Incident Report ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int updateReportId))
                            {
                                var reportToUpdate = incidentReportController.Read(updateReportId);
                                if (reportToUpdate != null)
                                {
                                    Console.Write("New date (dd/mm/yyyy): ");
                                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/mm/yyyy", null, DateTimeStyles.None, out DateTime newDate))
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
                                    incidentReportController.Update(reportToUpdate);
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
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "4":
                            Console.Write("Enter Incident Report ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteReportId))
                            {
                                incidentReportController.Delete(deleteReportId);
                                Console.WriteLine("Incident Report deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;

                        case "0":
                            return;

                        default:
                            throw new ArgumentException("Invalid option in Incident Report Menu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                }
            }
        }
    }
}
