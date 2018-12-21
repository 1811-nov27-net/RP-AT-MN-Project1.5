﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public Customer Create(Customer model)
        {
            Customers customer = Mapper.Map<Customer, Customers>(model);

            _db.Add(customer);

            model = Mapper.Map<Customers, Customer>(customer);
            return model;
        }

        public void Delete(int id)
        {
            Customer tracked = GetById(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Customer with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public IEnumerable GetAll()
        {
            List<Customers> list = _db.Customers
                                        .Include(ev => ev.EventsCustomers)
                                        .ThenInclude(e => e.Event)
                                        .Include(cr => cr.Reservation)
                                        .ThenInclude(r => r.Room)
                                        .OrderBy(m => m.Id)
                                        .ToList();

            return Mapper.Map<List<Customers>, List<Customer>>(list);
        }

        public Customer GetById(int id)
        {
            return Mapper.Map<Customers, Customer>(_db.Customers.Find(id));
        }

        public Customer Update(Customer model, int? id = null)
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

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}