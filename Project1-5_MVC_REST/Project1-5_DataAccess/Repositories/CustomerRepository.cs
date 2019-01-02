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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Project15Context _db;
        
        public CustomerRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }
        
        public async Task<IList<Customer>> GetAllAsync()
        {
            List<Customers> list = _db.Customers
                                       /*.Include(ev => ev.EventsCustomers)
                                       .ThenInclude(e => e.Event)
                                       .Include(cr => cr.Reservation)
                                       .ThenInclude(r => r.Room)*/
                                       .OrderBy(m => m.Id)
                                       .ToList();

            return Mapper.Map<List<Customers>, List<Customer>>(list);
        }
        

        public async Task<Customer> GetByIdAsync(int id)
        {
            return Mapper.Map<Customers, Customer>(_db.Customers.Find(id));
        }

        public async Task<Customer> CreateAsync(Customer model)
        {
            Customers customer = Mapper.Map<Customer, Customers>(model);

            _db.Add(customer);

            model = Mapper.Map<Customers, Customer>(customer);
            return model;
        }

        public async Task<Customer> UpdateAsync(Customer model, int? id = null)
        {
            Customers customer = Mapper.Map<Customer, Customers>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Customers tracked = _db.Customers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Customer with this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(customer);
            model = Mapper.Map<Customers, Customer>(customer);

            return model;
        }
        
        public async Task DeleteAsync(int id)
        {
            //Customers tracked = Mapper.Map<Customer, Customers>(GetById(id));
            Customers tracked = _db.Customers.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Customer with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public async Task SaveChangesAsync()
        {
            _db.SaveChanges();
        }
    }
}
