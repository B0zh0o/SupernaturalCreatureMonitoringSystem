using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public char Rank { get; set; }
        public string Artifacts { get; set; }
        public List<IncidentReport> IncidentReports { get; set; }

        public Agent()
        {
            IncidentReports = new List<IncidentReport>();
        }
        public Agent(string name, char rank, string artifacts, List<IncidentReport> incidentReports)
        {
            Name = name;
            Rank = rank;
            Artifacts = artifacts;
            IncidentReports = incidentReports;
        }
    }
}
