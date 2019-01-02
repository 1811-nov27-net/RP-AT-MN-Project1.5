using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project1_5_DataAccess;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project1_5_Tests.DataAccess.Repositories
{
    public class ReservationRepositoryTests : ARepositoriesTest
    {
        public ReservationRepositoryTests() : base() { }

        [Fact]
        public override async Task CreateWorksAsync()
        {
            Customer customerSaved = null;
            Room roomSaved = null;
            Reservation reservationSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_create").Options;

            using (var db = new Project15Context(options));

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                var customerRepo = new CustomerRepository(db);
                var roomRepo = new RoomRepository(db);

                //Create customer
                Customer customer = new Customer { Name = "Axel", Address1 = "111 Address" };
                customer = await customerRepo.CreateAsync(customer);
                await customerRepo.SaveChangesAsync();

                // create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                Reservation eventCustomer = new Reservation
                {
                    CustomerId = customer.Id,
                    RoomId = room.Id,
                    Paid = true
                };
                reservationSaved = await repo.CreateAsync(eventCustomer);
                await repo.SaveChangesAsync();
                customerSaved = customer;
                roomSaved = room;

            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                Reservation reservation = Mapper.Map<Reservations, Reservation>(db.Reservation.First(m => m.Paid == true));

                Assert.Equal(customerSaved.Id, reservation.CustomerId);
                Assert.Equal(roomSaved.Id, reservation.RoomId);
                Assert.True(reservation.Paid);
                Assert.NotEqual(0, reservation.Id);
            }
        }

        [Fact]
        public override async Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            int id = 1000;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_deleteWithNotId").Options;
            using (var db = new Project15Context(options));

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);

                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.Null(reservation);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.DeleteAsync(id));

            }
        }

        [Fact]
        public override Task DeleteWorksAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task GetAllWorksAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task GetByIdWorksAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public override Task UpdateWorksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
