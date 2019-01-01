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
           
        }

        [Fact]
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
          
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
           
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
          
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
           
        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {
            
        }
    }
}
