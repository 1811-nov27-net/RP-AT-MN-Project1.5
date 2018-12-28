using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IEventCustomerRepository
    {
        IEnumerable GetAll();
        EventCustomer GetById(int id);

        EventCustomer Create(EventCustomer model);
        EventCustomer Update(EventCustomer model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
