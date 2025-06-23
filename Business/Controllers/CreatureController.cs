using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Business.Controllers
{
    public class CreatureController: ICrudOperations<Creature>
    {
        MyAppContext context = new MyAppContext();

        public CreatureController(MyAppContext context)
        {
            this.context = context;
        }

        public Creature Read(int id)
        {
            return context.Creatures.Include(a => a.IncidentReports).FirstOrDefault(c => c.Id == id);
        }
        public List<Creature> ReadAll()
        {
            return context.Creatures.ToList();
        }
        public void Create(Creature creature)
        {
            context.Creatures.Add(creature);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (Read(id) != null)
            {
                context.Creatures.Remove(Read(id));
                context.SaveChanges();
            }
        }

        public void Update(Creature item)
        {
            var existing = context.Creatures.Include(c => c.IncidentReports).FirstOrDefault(c => c.Id == item.Id);

            if (existing != null)
            {
                existing.Type = item.Type;
                existing.ThreatLevel = item.ThreatLevel;
                existing.Status = item.Status;

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
