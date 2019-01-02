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
    public class EventCustomerRepository : IEventCustomerRepository
    {
        private readonly Project15Context _db;

        public EventCustomerRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }
    
        public async Task<IList<EventCustomer>> GetAllAsync()
        {
            List<EventsCustomers> list = _db.EventsCustomers
                                        .Include(ec => ec.Customer)
                                        .Include(ev => ev.Event)
                                        .OrderBy(m => m.Id)
                                        .ToList();

            foreach(var item in list)
            {
                item.Customer.EventsCustomers = null;
                item.Event.EventsCustomers = null;
            }

            return Mapper.Map<List<EventsCustomers>, List<EventCustomer>>(list);
        }

        public async Task<EventCustomer> GetByIdAsync(int id)
        {
            EventsCustomers eventCustomer = _db.EventsCustomers
                                            .Include(ec => ec.Customer)
                                            .Include(ev => ev.Event)
                                            .SingleOrDefault(e => e.Id == id);

            if (eventCustomer != null)
            {
                if(eventCustomer.Customer != null)
                    eventCustomer.Customer.EventsCustomers = null;
                if (eventCustomer.Event != null)
                    eventCustomer.Event.EventsCustomers = null;

                return Mapper.Map<EventsCustomers, EventCustomer>(eventCustomer);
            }
            return null;
        }

        public async Task<EventCustomer> CreateAsync(EventCustomer model)
        {
            EventsCustomers eventDataAccess = Mapper.Map<EventCustomer, EventsCustomers>(model);

            _db.Add(eventDataAccess);

            model = Mapper.Map<EventsCustomers, EventCustomer>(eventDataAccess);
            return model;
        }

        public async Task<EventCustomer> UpdateAsync(EventCustomer model, int? id = null)
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

        public async Task DeleteAsync(int id)
        {
            //EventsCustomers tracked = Mapper.Map<Event, EventsCustomers>(GetById(id));
            EventsCustomers tracked = _db.EventsCustomers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No EventCustomerwith this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public async Task<IList<EventCustomer>> GetByCustomerIdAsync(int id)
        {
            return Mapper.Map<List<EventsCustomers>, List<EventCustomer>>(
                                                                _db.EventsCustomers
                                                                //.Include(ec => ec.Customer)
                                                                .Include(ev => ev.Event)
                                                                .Where(e => e.CustomerId == id)
                                                                .ToList()
                                                             );
        }

        public async Task SaveChangesAsync()
        {
            _db.SaveChanges();
        }
    }
}
