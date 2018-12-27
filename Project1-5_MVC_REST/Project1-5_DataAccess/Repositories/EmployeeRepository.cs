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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Project15Context _db;

        public EmployeeRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public Employee Create(Employee model)
        {
            Employees employee = Mapper.Map<Employee, Employees>(model);

            _db.Add(employee);

            model = Mapper.Map<Employees, Employee>(employee);
            return model;
        }

        public void Delete(int id)
        {
            //Employees tracked = Mapper.Map<Employee, Employees>(GetById(id));
            Employees tracked = _db.Employees.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Employee with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public IEnumerable GetAll()
        {
            List<Employees> list = _db.Employees
                                        .OrderBy(m => m.Id)
                                        .ToList();

            return Mapper.Map<List<Employees>, List<Employee>>(list);
        }

        public Employee GetById(int id)
        {
            return Mapper.Map<Employees, Employee>(_db.Employees.Find(id));
        }

        public Employee Update(Employee model, int? id = null)
        {
            Employees employee = Mapper.Map<Employee, Employees>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Employees tracked = _db.Employees.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Employee with this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(employee);
            model = Mapper.Map<Employees, Employee>(employee);

            return model;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
