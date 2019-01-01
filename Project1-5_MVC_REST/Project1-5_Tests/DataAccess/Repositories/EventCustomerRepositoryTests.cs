using AutoMapper;
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
    public class EventCustomerRepositoryTests : ARepositoriesTest
    {
        public EventCustomerRepositoryTests() : base() { }

        [Fact]
        public override async Task CreateWorksAsync()
        {
            Customers customerSaved = null;
            Event EventSaved = null;
            EventCustomer eventCustomerSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_eventcustomer_test_create").Options;

            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EventCustomerRepository(db);

                //Create customer
                Customers customer = new Customers { Name = "Axel", Address1 = "111 Address" };      
                await repo.SaveChangesAsync();

                Event Event = new Event { Name = "Jazz Fest", Type = "Music", Cost = 40 };
                await repo.SaveChangesAsync();

                EventCustomer eventCustomer = new EventCustomer
                {
                    CustomerId = customer.Id,
                    EventId = Event.Id,
                    Paid = true
                };
                eventCustomerSaved = await repo.CreateAsync(eventCustomer);
                await repo.SaveChangesAsync();
                customerSaved = customer;
                EventSaved = Event;

            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventCustomerRepository(db);
                EventCustomer eventCustomer = Mapper.Map<EventsCustomers, EventCustomer>(db.EventsCustomers.First(m => m.Paid == true));

                Assert.Equal(customerSaved.Id, eventCustomer.CustomerId);
                Assert.Equal(EventSaved.Id, eventCustomer.EventId);
                Assert.True(eventCustomer.Paid);            
                Assert.NotEqual(0, eventCustomer.Id);
            }
        }

        [Fact]
        public override async Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            int id = 1000;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_eventcustomer_test_delete").Options;
            using (var db = new Project15Context(options));

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventCustomerRepository(db);

                EventCustomer eventCustomer = await repo.GetByIdAsync(id);
              
                Assert.Null(eventCustomer);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.DeleteAsync(id));

            }
        }

        [Fact]
        public override async Task DeleteWorksAsync()
        {
            int id = 0;

            Customer customerSaved = null;
            Event EventSaved = null;
            EventCustomer eventCustomerSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_eventcustomer_test_delete_2").Options;

            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {

                var customerRepo = new CustomerRepository(db);
                var eventRepo = new EventRepository(db);
                var repo = new EventCustomerRepository(db);

                //Create customer
                Customer customer = new Customer { Name = "Axel", Address1 = "111 Address" };
                customer = await customerRepo.CreateAsync(customer);
                await customerRepo.SaveChangesAsync();

                Event Event = new Event { Name = "Jazz Fest", Type = "Music", Cost = 40 };
                Event = await eventRepo.CreateAsync(Event);
                await eventRepo.SaveChangesAsync();

                EventCustomer eventCustomer = new EventCustomer
                {
                    CustomerId = customer.Id,
                    EventId = Event.Id,
                    Paid = true
                };

                eventCustomerSaved = await repo.CreateAsync(eventCustomer);
                await repo.SaveChangesAsync();

                EventSaved = Event;
                customerSaved = customer;

                id = eventCustomerSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventCustomerRepository(db);
                EventCustomer eventCustomer = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, eventCustomer.Id);
                Assert.Equal(eventCustomerSaved.Id, eventCustomer.Id);
                Assert.True(eventCustomer.Paid);

                await repo.DeleteAsync(id);
                await repo.SaveChangesAsync();
                eventCustomer = await repo.GetByIdAsync(id);

                Assert.Null(eventCustomer);
            }
        }

        [Fact]
        public override async Task GetAllWorksAsync()
        {
            List<Event> Events = new List<Event>();
            Event EventSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Event_test_getAll").Options;

            using (var db = new Project15Context(options)) ;

            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                for (int i = 0; i < 5; i++)
                {
                    Event Event = new Event { Name = $"Jazz Fest {i}", Type = $"Music {i}", Cost = i };
                    EventSaved = await repo.CreateAsync(Event);
                    await repo.SaveChangesAsync();
                    Events.Add(EventSaved);
                }
            }
            using (var db = new Project15Context(options))
            {

                var repo = new EventRepository(db);
                List<Event> EventList = (List<Event>)await repo.GetAllAsync();

                // should equal the same amount of Events
                Assert.Equal(Events.Count, EventList.Count);

                for (int i = 0; i < Events.Count; i++)
                {
                    Assert.Equal(Events[i].Name, EventList[i].Name);
                    Assert.Equal(Events[i].Type, EventList[i].Type);
                    Assert.Equal(Events[i].Cost, EventList[i].Cost);
                    Assert.NotEqual(0, Events[i].Id);
                }
            }
        }

        [Fact]
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_Event_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = await repo.GetByIdAsync(id);

                Assert.Null(Event);
            }
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
            int id = 0;

            Event EventSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Event_test_getbyid").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);
                Event Event = new Event { Name = "Jazz Fest", Type = "Music", Cost = 40 };
                EventSaved = await repo.CreateAsync(Event);
                await repo.SaveChangesAsync();
                id = EventSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);
                Event Event = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, Event.Id); // should get some generated ID
                Assert.Equal(EventSaved.Id, Event.Id);
                Assert.Equal("Jazz Fest", Event.Name);
                Assert.Equal("Music", Event.Type);
                Assert.Equal(40, Event.Cost);
            }
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_Event_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = await repo.GetByIdAsync(id);

                Assert.Null(Event);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(Event, id));
            }
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            int id = 0;
            int wronId = 10;
            Event EventSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Event_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = new Event { Name = "Jazz Fest", Type = "Music", Cost = 40 };
                EventSaved = await repo.CreateAsync(Event);
                await repo.SaveChangesAsync();
                id = EventSaved.Id;
            }

            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, Event.Id); // should get some generated ID
                Assert.Equal(EventSaved.Id, Event.Id);
                Assert.Equal("Jazz Fest", Event.Name);
                Assert.Equal("Music", Event.Type);
                Assert.Equal(40, Event.Cost);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(Event, wronId));

            }
        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {
            int id = 0;
            int wrongId = 10;
            Event EventSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Event_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = new Event { Name = $"Jazz Fest", Type = $"Music", Cost = 40 };
                EventSaved = await repo.CreateAsync(Event);
                await repo.SaveChangesAsync();
                id = EventSaved.Id;

            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EventRepository(db);

                Event Event = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, Event.Id); // should get some generated ID
                Assert.Equal(EventSaved.Id, Event.Id);
                Assert.Equal("Jazz Fest", Event.Name);
                Assert.Equal("Music", Event.Type);
                Assert.Equal(40, Event.Cost);


                Event.Name = "Hip-Hop-Night";
                Event.Type = "Music";

                await repo.UpdateAsync(Event, id);
                await repo.SaveChangesAsync();

                Event = await repo.GetByIdAsync(Event.Id);

                Assert.NotEqual(wrongId, Event.Id);
                Assert.Equal("Hip-Hop-Night", Event.Name);
                Assert.Equal("Music", Event.Type);
            }
        }
    }
}
