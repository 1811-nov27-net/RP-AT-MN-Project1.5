using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IRoomRepository
    {
        IEnumerable GetAll();
        Room GetById(int id);

        Room Create(Room model);
        Room Update(Room model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
