using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_5_DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Project15Context _db;

        public EventRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }
        
        public async Task<IList<Event>> GetAllAsync()
        {
            List<Events> list = _db.Events
                                        .OrderBy(m => m.Id)
                                        .ToList();

            return Mapper.Map<List<Events>, List<Event>>(list);
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return Mapper.Map<Events, Event>(_db.Events.Find(id));
        }

        public async Task<Event> CreateAsync(Event model)
        {
            Events eventDataAccess = Mapper.Map<Event, Events>(model);

            _db.Add(eventDataAccess);

            model = Mapper.Map<Events, Event>(eventDataAccess);
            return model;
        }

        public async Task<Event> UpdateAsync(Event model, int? id = null)
        {
            Events eventDataAccess = Mapper.Map<Event, Events>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Events tracked = _db.Events.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Event with this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(eventDataAccess);
            model = Mapper.Map<Events, Event>(eventDataAccess);

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            //Events tracked = Mapper.Map<Event, Events>(GetById(id));
            Events tracked = _db.Events.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Event with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public async Task SaveChangesAsync()
        {
            _db.SaveChanges();
        }
    }
}
