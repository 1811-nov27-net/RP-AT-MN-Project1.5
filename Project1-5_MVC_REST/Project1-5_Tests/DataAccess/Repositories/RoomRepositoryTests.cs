using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_DataAccess;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Project1_5_Tests.DataAccess.Repositories
{
    public class RoomRepositoryTests : ARepositoriesTest
    {
        public RoomRepositoryTests() : base() {}

        [Fact]
        public override void CreateWorks()
        {
            Room roomSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_room_test_create").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                //Create customer
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                roomSaved = repo.Create(room);
                repo.SaveChanges();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                Room room = Mapper.Map<Rooms, Room>(db.Rooms.First(m => m.RoomType == "Standard"));

                Assert.NotEqual(0, room.Id); // should get some generated ID
                Assert.Equal(roomSaved.Id, room.Id);
                Assert.Equal(1, room.Beds);
                Assert.Equal(50, room.Cost);
                Assert.Equal("Standard", room.RoomType);
            }
        }

        [Fact]
        public override void DeleteWithIdThatDoesntExistThrowsException()
        {
            int id = 1000;

            // arrange (use the context directl - we assume that it works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("dp_room_test-delete").Options;

            using (var db = new Project15Context(options));

            using(var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = repo.GetById(id);

                Assert.Null(room);

                Assert.Throws<ArgumentException>(() => repo.Delete(id));
            }
        }

        [Fact]
        public override void DeleteWorks()
        {
            Room roomSaved = null;
            int id = 0;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_room_test_delete").Options;
            using (var db = new Project15Context(options));

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                //Create customer
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                roomSaved = repo.Create(room);
                repo.SaveChanges();

                id = roomSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                Room room = repo.GetById(id);

                Assert.NotEqual(0, room.Id); // should get some generated ID
                Assert.Equal(roomSaved.Id, room.Id);
                Assert.Equal(1, room.Beds);
                Assert.Equal(50, room.Cost);
                Assert.Equal("Standard", room.RoomType);

                repo.Delete(id);
                repo.SaveChanges();
                room = repo.GetById(id);

                Assert.Null(room);
            }
        }

        [Fact]
        public override void GetAllWorks()
        {
            List<Room> list = new List<Room>();
            Room roomSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_room_test_getAll").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                for(int i = 0; i < 10; i++)
                {
                    Room room = new Room
                    {
                        Cost = 150,
                        Beds = 3,
                        RoomType = $"Room {i}"
                    };
                    roomSaved = repo.Create(room);
                    repo.SaveChanges();
                    list.Add(roomSaved);
                }
            }
            
            // asssert (for assert, once again use the context directly for verification.)
            using(var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                List<Room> rooms = (List<Room>)repo.GetAll();

                // should equal the same amount of rooms
                Assert.Equal(list.Count, rooms.Count);

                for (int i = 0; i < list.Count; i++)
                {
                    Assert.Equal(list[i].Cost, rooms[i].Cost);
                    Assert.Equal(list[i].Beds, rooms[i].Beds);
                    Assert.Equal(list[i].RoomType, rooms[i].RoomType);

                }
            }

        }

        [Fact]
        public override void GetByIdThatDoesntExistReturnsNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override void GetByIdWorks()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override void UpdateWithNoIdShouldReturnException()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override void UpdateWithWorngIdShouldReturnException()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override void UpdateWorks()
        {
            throw new NotImplementedException();
        }
    }
}
