using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyAppContext: DbContext
    {
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<IncidentReport> IncidentReports { get; set; }

        public MyAppContext() { }

        public MyAppContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Configuration.connectionString);
            }
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>().HasMany(a => a.IncidentReports);
            modelBuilder.Entity<Agent>().HasMany(c => c.IncidentReports);
        }
    }
}
