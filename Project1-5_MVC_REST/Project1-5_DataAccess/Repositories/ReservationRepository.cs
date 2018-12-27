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
    public class ReservationRepository : IReservationRepository
    {
        private readonly Project15Context _db;

        public ReservationRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public Reservation Create(Reservation model)
        {
            Reservations reservation = Mapper.Map<Reservation, Reservations>(model);

            _db.Add(reservation);

            model = Mapper.Map<Reservations, Reservation>(reservation);
            return model;
        }

        public void Delete(int id)
        {
            //Reservations tracked = Mapper.Map<Reservation, Reservations>(GetById(id));
            Reservations tracked = _db.Reservation.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Reservation with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public IEnumerable GetAll()
        {
            List<Reservations> list = _db.Reservation
                                        .Include(c => c.Customer)
                                        .Include(r => r.Room)
                                        .OrderBy(m => m.Id)
                                        .ToList();

            return Mapper.Map<List<Reservations>, List<Reservations>>(list);
        }

        public Reservation GetById(int id)
        {
            return Mapper.Map<Reservations, Reservation>(_db.Reservation.Find(id));
        }

        public Reservation Update(Reservation model, int? id = null)
        {
            Reservations reservation = Mapper.Map<Reservation, Reservations>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Reservations tracked = _db.Reservation.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Reservation with this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(reservation);
            model = Mapper.Map<Reservations, Reservation>(reservation);

            return model;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
