using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_DataAccess;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using System;
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
            throw new NotImplementedException();
        }

        [Fact]
        public override void DeleteWorks()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override void GetAllWorks()
        {
            throw new NotImplementedException();
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
