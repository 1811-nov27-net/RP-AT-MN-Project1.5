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
    public class RoomRepository : IRoomRepository
    {
        private readonly Project15Context _db;

        public RoomRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public Room Create(Room model)
        {
            Rooms room = Mapper.Map<Room, Rooms>(model);

            _db.Add(room);

            model = Mapper.Map<Rooms, Room>(room);
            return model;
        }

        public void Delete(int id)
        {
            //Rooms tracked = Mapper.Map<Room, Rooms>(GetById(id));
            Rooms tracked = _db.Rooms.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Room with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public IEnumerable GetAll()
        {
            List<Rooms> list = _db.Rooms
                                    .OrderBy(m => m.Id)
                                    .ToList();

            return Mapper.Map<List<Rooms>, List<Room>>(list);
        }

        public Room GetById(int id)
        {
            return Mapper.Map<Rooms, Room>(_db.Rooms.Find(id));
        }

        public Room Update(Room model, int? id = null)
        {
            Rooms room = Mapper.Map<Room, Rooms>(model);

            if (id == null)
            {
                throw new ArgumentException("Nedded id", nameof(id));
            }

            Rooms tracked = _db.Rooms.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Room with this id", nameof(id));
            }

            _db.Entry(tracked).CurrentValues.SetValues(room);
            model = Mapper.Map<Rooms, Room>(room);

            return model;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
