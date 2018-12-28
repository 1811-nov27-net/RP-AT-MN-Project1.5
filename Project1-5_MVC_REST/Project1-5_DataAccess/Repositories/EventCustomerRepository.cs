using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project1_5_DataAccess.Repositories
{
    public class EventCustomerRepository : IEventCustomerRepository
    {
        private readonly Project15Context _db;

        public EventCustomerRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public EventCustomer Create(EventCustomer model)
        {
            EventsCustomers eventDataAccess = Mapper.Map<EventCustomer, EventsCustomers>(model);

            _db.Add(eventDataAccess);

            model = Mapper.Map<EventsCustomers, EventCustomer>(eventDataAccess);
            return model;
        }

        public void Delete(int id)
        {
            //EventsCustomers tracked = Mapper.Map<Event, EventsCustomers>(GetById(id));
            EventsCustomers tracked = _db.EventsCustomers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No EventCustomerwith this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public IEnumerable GetAll()
        {
            List<EventsCustomers> list = _db.EventsCustomers
                                        .OrderBy(m => m.Id)
                                        .ToList();

            return Mapper.Map<List<EventsCustomers>, List<EventCustomer>>(list);
        }

        public EventCustomer GetById(int id)
        {
            return Mapper.Map<EventsCustomers, EventCustomer>(_db.EventsCustomers.Find(id));
        }

        public EventCustomer Update(EventCustomer model, int? id = null)
        {
            EventsCustomers eventDataAccess = Mapper.Map<EventCustomer, EventsCustomers>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            EventsCustomers tracked = _db.EventsCustomers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No EventCustomerwith this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(eventDataAccess);
            model = Mapper.Map<EventsCustomers, EventCustomer>(eventDataAccess);

            return model;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
