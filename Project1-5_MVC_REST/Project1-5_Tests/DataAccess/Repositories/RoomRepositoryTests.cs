using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_DataAccess;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project1_5_Tests.DataAccess.Repositories
{
    public class RoomRepositoryTests : ARepositoriesTest
    {
        public RoomRepositoryTests() : base() {}

        [Fact]
        public override async Task CreateWorksAsync()
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
                roomSaved = await repo.CreateAsync(room);
                await repo.SaveChangesAsync();
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
        public override async Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            int id = 1000;

            // arrange (use the context directl - we assume that it works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("dp_room_test-delete").Options;

            using (var db = new Project15Context(options));

            using(var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = await repo.GetByIdAsync(id);

                Assert.Null(room);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.DeleteAsync(id));
            }
        }

        [Fact]
        public override async Task DeleteWorksAsync()
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
                roomSaved = await repo.CreateAsync(room);
                await repo.SaveChangesAsync();

                id = roomSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                Room room = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, room.Id); // should get some generated ID
                Assert.Equal(roomSaved.Id, room.Id);
                Assert.Equal(1, room.Beds);
                Assert.Equal(50, room.Cost);
                Assert.Equal("Standard", room.RoomType);

                await repo.DeleteAsync(id);
                await repo.SaveChangesAsync();
                room = await repo.GetByIdAsync(id);

                Assert.Null(room);
            }
        }

        [Fact]
        public override async Task GetAllWorksAsync()
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
                    roomSaved = await repo.CreateAsync(room);
                    await repo.SaveChangesAsync();
                    list.Add(roomSaved);
                }
            }
            
            // asssert (for assert, once again use the context directly for verification.)
            using(var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                List<Room> rooms = (List<Room>) await repo.GetAllAsync();

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
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_room_test_getAll").Options;

            using (var db = new Project15Context(options));

            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = await repo.GetByIdAsync(id);

                Assert.Null(room);

            }
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
            int id = 0;

            Room roomSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_room_test_getbyid").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                //Create customer
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                roomSaved = await repo.CreateAsync(room);
                await repo.SaveChangesAsync();
                id = roomSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                Room room = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, room.Id);
                Assert.Equal(1, room.Beds);
                Assert.Equal("Standard", room.RoomType);
            }
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_room_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;          
            
            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = await repo.GetByIdAsync(id);

                Assert.Null(room);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(room, id));
            }
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            int id = 0;
            int wronId = 10;
            Room roomSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_rooms_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options));

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = new Room
                {
                    Cost = 500,
                    RoomType = "Standard"
                };

                roomSaved = await repo.CreateAsync(room);
                await repo.SaveChangesAsync();

                id = roomSaved.Id;

            }

            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, room.Id);
                Assert.Equal(500, room.Cost);
                Assert.Equal("Standard", room.RoomType);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(room, wronId));

            }



        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {
            int id = 0;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
              .UseInMemoryDatabase("db_rooms_test_update").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);

                Room room = new Room
                {
                    Cost = 500,
                    RoomType = "Standard"
                };

                roomSaved = await repo.CreateAsync(room);
                await repo.SaveChangesAsync();

                id = roomSaved.Id;

            }
            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new RoomRepository(db);
                Room room = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, room.Id);
                Assert.Equal(500, room.Cost);
                Assert.Equal("Standard", room.RoomType);

                room.Cost = 400;
                room.RoomType = "Suite";

                await repo.UpdateAsync(room, id);
                await repo.SaveChangesAsync();

                room = await repo.GetByIdAsync(room.Id);

                Assert.NotEqual(0, room.Id);
                Assert.Equal(400, room.Cost);
                Assert.Equal("Suite", room.RoomType);
            }

        }
    }
}
