using Microsoft.EntityFrameworkCore;
using Project1_5_DataAccess;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using System;
using System.Collections.Generic;
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
                Reservation reservation = AutoMapper.Mapper.Map<Reservations, Reservation>(db.Reservation.First(m => m.Paid == true));

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
        public override async Task DeleteWorksAsync()
        {
            int id = 0;
            Reservation reservationSaved = null;
            Customer customerSaved = null;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_delete").Options;

            using (var db = new Project15Context(options)) ;

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

                // Create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                // Create reservation
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
                id = reservationSaved.Id;
            }
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, reservation.Id);
                Assert.Equal(customerSaved.Id, reservation.CustomerId);
                Assert.Equal(roomSaved.Id, reservation.RoomId);
                Assert.True(reservation.Paid);

                await repo.DeleteAsync(id);
                await repo.SaveChangesAsync();

                reservation = await repo.GetByIdAsync(id);

                Assert.Null(reservation);
                
            }
        }

        [Fact]
        public override async Task GetAllWorksAsync()
        {
            List<Reservation> reservationList = new List<Reservation>();
            Reservation reservationSaved = null;
            Customer customerSaved = null;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_getall").Options;

            using (var db = new Project15Context(options));

            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                var customerRepo = new CustomerRepository(db);
                var roomRepo = new RoomRepository(db);

                //Create customer
                Customer customer = new Customer { Name = "Axel", Address1 = "111 Address" };
                customer = await customerRepo.CreateAsync(customer);
                await customerRepo.SaveChangesAsync();

                // Create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                for (int i = 0; i < 5; i++)
                {
                    Reservation reservation = new Reservation
                    {
                        CustomerId = customer.Id,
                        RoomId = room.Id,
                    };
                    reservationSaved = await repo.CreateAsync(reservation);
                    await repo.SaveChangesAsync();
                    reservationList.Add(reservationSaved);
                }

                roomSaved = room;
                customerSaved = customer;
            }
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                List<Reservation> list = (List<Reservation>)await repo.GetAllAsync();

                Assert.Equal(reservationList.Count, list.Count);

                for (int i = 0; i < 5; i++)
                {
                    Assert.Equal(reservationList[i].CustomerId, list[i].CustomerId);
                    Assert.Equal(reservationList[i].RoomId, list[i].RoomId);
                    Assert.NotEqual(0, list[i].Id);
                }
            }
        }

        [Fact]
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_reservation_test_getId").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options));

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);

                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.Null(reservation);
            }
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
            int id = 0;
            Reservation reservationSaved = null;
            Customer customerSaved = null;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_getById").Options;

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

                // Create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                // Create reservation
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
                id = reservationSaved.Id;
            }
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, reservation.Id);
                Assert.Equal(customerSaved.Id, reservation.CustomerId);
                Assert.Equal(roomSaved.Id, reservation.RoomId);
                Assert.True(reservation.Paid);
            }
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_reservation_test_updateByWrongId_Exception").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);

                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.Null(reservation);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(reservation, id));
            }
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            int id = 0;
            int wrongId = 1000;
            Reservation reservationSaved = null;
            Customer customerSaved = null;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_getById").Options;

            using (var db = new Project15Context(options)) ;

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

                // Create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                // Create reservation
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
                id = reservationSaved.Id;
            }
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, reservation.Id);
                Assert.Equal(customerSaved.Id, reservation.CustomerId);
                Assert.Equal(roomSaved.Id, reservation.RoomId);
                Assert.True(reservation.Paid);

                reservation.Paid = false;

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(reservation, wrongId));
            }
        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {
            int id = 0;         
            Reservation reservationSaved = null;
            Customer customerSaved = null;
            Room roomSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_reservation_test_getById").Options;

            using (var db = new Project15Context(options)) ;

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

                // Create room
                Room room = new Room { Beds = 1, Cost = 50, RoomType = "Standard" };
                room = await roomRepo.CreateAsync(room);
                await roomRepo.SaveChangesAsync();

                // Create reservation
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
                id = reservationSaved.Id;
            }
            using (var db = new Project15Context(options))
            {
                var repo = new ReservationRepository(db);
                Reservation reservation = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, reservation.Id);
                Assert.Equal(customerSaved.Id, reservation.CustomerId);
                Assert.Equal(roomSaved.Id, reservation.RoomId);
                Assert.True(reservation.Paid);

                reservation.Paid = false;

                await repo.UpdateAsync(reservation, id);

                Assert.False(reservation.Paid);
            }
        }
    }
}
