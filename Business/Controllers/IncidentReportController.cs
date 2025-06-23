using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Controllers
{
    public class IncidentReportController : ICrudOperations<IncidentReport>
    {
        MyAppContext context = new MyAppContext();

        public IncidentReportController(MyAppContext context)
        {
            this.context = context;
        }

        public void Create(IncidentReport item)
        {
            context.IncidentReports.Add(item);
            context.SaveChanges();
        }

        public IncidentReport Read(int id)
        {
            return context.IncidentReports.FirstOrDefault(ir=>ir.Id == id);
        }

        public List<IncidentReport> ReadAll()
        {
            return context.IncidentReports.ToList();
        }

        public void Update(IncidentReport item)
        {
            var existing = context.IncidentReports.Find(item.Id);
            if (existing != null)
            {
                existing.Date = item.Date;
                existing.Location = item.Location;
                existing.CreatureId = item.CreatureId;
                existing.AgentId = item.AgentId;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var report = context.IncidentReports.Find(id);
            if (report != null)
            {
                context.IncidentReports.Remove(report);
                context.SaveChanges();
            }
        }
    }
}
