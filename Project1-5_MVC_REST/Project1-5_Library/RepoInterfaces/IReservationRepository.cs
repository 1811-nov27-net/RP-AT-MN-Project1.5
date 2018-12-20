using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.RepoInterfaces
{
    public interface IReservationRepository
    {
        IEnumerable GetAll();
        Reservation GetById(int id);

        Reservation Create(Reservation model);
        Reservation Update(Reservation model, int? id = null);

        void Delete(int id);

        void SaveChanges();
    }
}
