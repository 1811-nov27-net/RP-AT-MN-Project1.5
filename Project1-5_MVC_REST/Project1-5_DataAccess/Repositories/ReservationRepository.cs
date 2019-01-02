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
    public class ReservationRepository : IReservationRepository
    {
        private readonly Project15Context _db;

        public ReservationRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }
        
        public async Task<IList<Reservation>> GetAllAsync()
        {
            List<Reservations> list = _db.Reservation
                                        .Include(c => c.Customer)
                                        .Include(r => r.Room)
                                        .Where(r => r.Paid == false)
                                        .OrderBy(m => m.Id)
                                        .ToList();

            foreach(var item in list)
            {
                item.Customer.Reservation = null;
                item.Room.Reservation = null;
            }

            return Mapper.Map<List<Reservations>, List<Reservation>>(list);
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            Reservations reservation = _db.Reservation
                                            .Include(r => r.Customer)
                                            .Include(r => r.Room)
                                            .Where(r => r.Id == id)
                                            .FirstOrDefault();

            if(reservation != null) { 
                if(reservation.Customer.Reservation != null)
                    reservation.Customer.Reservation = null;
                if (reservation.Room.Reservation != null)
                    reservation.Room.Reservation = null;

                return Mapper.Map<Reservations, Reservation>(reservation);
            }
            return null;
        }

        public async Task<Reservation> CreateAsync(Reservation model)
        {
            Reservations reservation = Mapper.Map<Reservation, Reservations>(model);

            _db.Add(reservation);

            model = Mapper.Map<Reservations, Reservation>(reservation);
            return model;
        }

        public async Task<Reservation> UpdateAsync(Reservation model, int? id = null)
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

        public async Task DeleteAsync(int id)
        {
            //Reservations tracked = Mapper.Map<Reservation, Reservations>(GetById(id));
            Reservations tracked = _db.Reservation.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Reservation with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public async Task<IList<Reservation>> GetByCustomerIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            _db.SaveChanges();
        }
    }
}
