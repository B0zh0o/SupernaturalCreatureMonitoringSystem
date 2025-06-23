using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Controllers
{
    public class AgentController
    {
        MyAppContext context = new MyAppContext();

        public AgentController(MyAppContext context)
        {
            this.context = context;
        }

        public Agent Read(int id)
        {
            return context.Agents.Include(a=>a.IncidentReports).FirstOrDefault(a => a.Id == id);
        }

        public List<Agent> ReadAll()
        {
            return context.Agents.ToList();
        }

        public void Create(Agent agent)
        {
            context.Agents.Add(agent);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (Read(id) != null)
            { 
                context.Agents.Remove(Read(id));
                context.SaveChanges();
            }
        }

        public void Update(Agent item)
        {
            var existing = context.Agents.Include(a => a.IncidentReports).FirstOrDefault(a => a.Id == item.Id);

            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Rank = item.Rank;
                existing.Artifacts = item.Artifacts;

                existing.IncidentReports.Clear();

                foreach (var report in item.IncidentReports)
                {


                    var attachedReport = context.IncidentReports.Find(report.Id);
                    if (attachedReport != null)
                    {
                        existing.IncidentReports.Add(attachedReport);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
