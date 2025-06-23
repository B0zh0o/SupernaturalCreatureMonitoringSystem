using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class IncidentReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public int CreatureId { get; set; }


        public int AgentId { get; set; }


        public IncidentReport()
        {
        }
        public IncidentReport(DateTime date, string location, int creatureId, int agentId)
        {
            Date = date;
            Location = location;
            CreatureId = creatureId;
            AgentId = agentId;
        }

    }
}
