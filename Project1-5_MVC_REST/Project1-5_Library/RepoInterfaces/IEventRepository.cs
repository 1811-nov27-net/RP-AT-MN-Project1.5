using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    interface IEventRepository
    {
        IEnumerable GetAll();
        Event GetById(int id);

        Event Create(Event model);
        Event Update(Event model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
