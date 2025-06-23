using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Creature
    {
        private int threatLevel;
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int ThreatLevel
        { get ; set; }
        public string Status { get; set; }
        public List<IncidentReport> IncidentReports { get; set; }

        public Creature()
        {
            IncidentReports = new List<IncidentReport>();
        }
        public Creature(string type, int threatLevel, string status)
        {
            Type = type;
            ThreatLevel = threatLevel;
            Status = status;
            IncidentReports = new List<IncidentReport>();
        }
        public Creature(string type, int threatLevel, string status, List<IncidentReport> incidentReports)
        {
            Type = type;
            ThreatLevel = threatLevel;
            Status = status;
            IncidentReports = incidentReports;
        }
    }
}
