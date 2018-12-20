using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    interface IEmployeeRepository
    {
        IEnumerable GetAll();
        Employee GetById(int id);

        Employee Create(Employee model);
        Employee Update(Employee model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
