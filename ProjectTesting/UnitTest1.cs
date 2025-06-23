using NUnit.Framework;
using Data;
using Business;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Business.Controllers;
using System;

namespace ProjectTesting
{
    public class Tests
    {
        private MyAppContext _context;
        private AgentController _agentController;
        private CreatureController _creatureController;
        private IncidentReportController _incidentController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
            .Options;

            _context = new MyAppContext(options);
            _agentController = new AgentController(_context);
            _creatureController = new CreatureController(_context);
            _incidentController = new IncidentReportController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void Agent_CRUD_Works()
        {
            var agent = new Agent("Fox", 'S', "Glove of Truth", new List<IncidentReport>());
            _agentController.Create(agent);

            var all = _agentController.ReadAll();
            Assert.That(all.Count, Is.EqualTo(1));

            var fetched = _agentController.Read(all[0].Id);
            Assert.That(fetched.Name, Is.EqualTo("Fox"));

            fetched.Name = "Mulder";
            _agentController.Update(fetched);

            var updated = _agentController.Read(fetched.Id);
            Assert.That(updated.Name, Is.EqualTo("Mulder"));

            _agentController.Delete(updated.Id);
            Assert.That(_agentController.ReadAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void Creature_CRUD_Works()
        {
            var creature = new Creature("Hydra", 8, "Uncontained", new List<IncidentReport>());
            _creatureController.Create(creature);

            var all = _creatureController.ReadAll();
            Assert.That(all.Count, Is.EqualTo(1));

            var fetched = _creatureController.Read(all[0].Id);
            Assert.That(fetched.Type, Is.EqualTo("Hydra"));

            fetched.Status = "Neutralized";
            _creatureController.Update(fetched);

            var updated = _creatureController.Read(fetched.Id);
            Assert.That(updated.Status, Is.EqualTo("Neutralized"));

            _creatureController.Delete(updated.Id);
            Assert.That(_creatureController.ReadAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void IncidentReport_CRUD_Works()
        {
            var agent = new Agent("Dana", 'B', "Spectacles of Sight", new List<IncidentReport>());
            var creature = new Creature("Wendigo", 7, "Loose", new List<IncidentReport>());

            _context.Agents.Add(agent);
            _context.Creatures.Add(creature);
            _context.SaveChanges();

            var report = new IncidentReport
            {
                Date = DateTime.Today,
                Location = "Zone Alpha",
                AgentId = agent.Id,
                CreatureId = creature.Id
            };

            _incidentController.Create(report);

            var all = _incidentController.ReadAll();
            Assert.That(all.Count, Is.EqualTo(1));
            Assert.That(all[0].Location, Is.EqualTo("Zone Alpha"));

            var fetched = _incidentController.Read(all[0].Id);
            _incidentController.Delete(fetched.Id);
            Assert.That(_incidentController.ReadAll().Count, Is.EqualTo(0));
        }
    }
}
