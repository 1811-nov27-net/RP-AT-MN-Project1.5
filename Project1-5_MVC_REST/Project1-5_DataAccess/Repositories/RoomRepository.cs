using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_5_DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Project15Context _db;

        public RoomRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<IList<Room>> GetAllAsync()
        {
            List<Rooms> list = _db.Rooms
                                    .OrderBy(m => m.Id)
                                    .ToList();

            return Mapper.Map<List<Rooms>, List<Room>>(list);
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return Mapper.Map<Rooms, Room>(_db.Rooms.Find(id));
        }

        public async Task<Room> CreateAsync(Room model)
        {
            Rooms room = Mapper.Map<Room, Rooms>(model);

            _db.Add(room);

            model = Mapper.Map<Rooms, Room>(room);
            return model;
        }

        public async Task<Room> UpdateAsync(Room model, int? id = null)
        {
            Rooms room = Mapper.Map<Room, Rooms>(model);

            if (id == null)
            {
                throw new ArgumentException("Needed id", nameof(id));
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

        public async Task DeleteAsync(int id)
        {
            Rooms tracked = _db.Rooms.Find(id);
            if (tracked == null)
            {
                throw new ArgumentException("No Room with this id", nameof(id));
            }
            _db.Remove(tracked);
        }

        public async Task<IList<Room>> CheckRoomAvailabilityAsync(DateTime beginDate)
        {
            List<Rooms> roomsAvailable = new List<Rooms>();

            roomsAvailable = _db.Rooms
                        .FromSql(
                            "SELECT * " +
                            "from Hotel.rooms " +
                            "where id not in " +
                            "( " +
                            "    select distinct RoomId " +
                            "    from Hotel.Reservation " +
                            "    where EndDate >= @beginDate" +
                            ")",
                            new SqlParameter("@beginDate", beginDate)
                        ).ToList();

            return Mapper.Map<List<Rooms>, List<Room>>(roomsAvailable);
        }
        
        public async Task SaveChangesAsync()
        {
            _db.SaveChanges();
        }

    }
}
