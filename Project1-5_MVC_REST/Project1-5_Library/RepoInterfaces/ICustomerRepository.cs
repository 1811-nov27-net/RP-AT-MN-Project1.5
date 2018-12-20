using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    public interface ICustomerRepository
    {
        IEnumerable GetAll();
        Customer GetById(int id);

        Customer Create(Customer model);
        Customer Update(Customer model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
