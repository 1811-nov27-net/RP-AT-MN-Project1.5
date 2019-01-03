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
    public class CustomerRepositoryTests : ARepositoriesTest
    {
        public CustomerRepositoryTests() : base() { }
        
        [Fact]
        public override async Task CreateWorksAsync()
        {
            Customer customerSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_customer_test_create").Options;
            using (var db = new Project15Context(options));

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                //Create customer
                Customer customer = new Customer { Name = "Axel", Email = "axel@yahoo.com", Address1 = "111 Arlington St." };
                customerSaved = await repo.CreateAsync(customer);
                await repo.SaveChangesAsync();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);
                Customer Customer = Mapper.Map<Customers, Customer>(db.Customers.First(m => m.Name == "Axel"));

                Assert.NotEqual(0, Customer.Id); // should get some generated ID
                Assert.Equal(customerSaved.Id, Customer.Id);
                Assert.Equal("Axel", Customer.Name);
                Assert.Equal("axel@yahoo.com", Customer.Email);
                Assert.Equal("111 Arlington St.", Customer.Address1);
            }
        }

        [Fact]
        public override async Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            int id = 100000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_customer_test_deleteWithIdNotExist").Options;

            // arrange (use the context directl - we assume that it works)
            using (var db = new Project15Context(options));


            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer = await repo.GetByIdAsync(id);

                Assert.Null(customer);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.DeleteAsync(id));
            }
        }

        [Fact]
        public override async Task DeleteWorksAsync()
        {
            Customer customerSaved = null;
            int id = 0;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_customer_test_delete").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                //Create customer
                Customer customer = new Customer { Name = "Axel", Email = "axel@yahoo.com", Address1 = "111 Arlington St." };
                customerSaved = await repo.CreateAsync(customer);
                await repo.SaveChangesAsync();

                id = customerSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);
                Customer customer = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, customer.Id); // should get some generated ID
                Assert.Equal(customerSaved.Id, customer.Id);
                Assert.Equal("Axel", customer.Name);
                Assert.Equal("axel@yahoo.com", customer.Email);
                Assert.Equal("111 Arlington St.", customer.Address1);

                await repo.DeleteAsync(id);
                await repo.SaveChangesAsync();
                customer = await repo.GetByIdAsync(id);

                Assert.Null(customer);
            }
        }

        [Fact]
        public override async Task GetAllWorksAsync()
        {
            List<Customer> customers = new List<Customer>();
            Customer customerSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_customer_test_getAll").Options;

            using (var db = new Project15Context(options));

            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                for (int i = 0; i < 5; i++)
                {
                    Customer customer = new Customer
                    {
                        Name = $"First Name {i}",
                        Email = $"Email {i}",
                        City = $"City {i}"
                    };
                    customerSaved = await repo.CreateAsync(customer);
                    await repo.SaveChangesAsync();
                    customers.Add(customerSaved);
                }
            }
            using (var db = new Project15Context(options))
            {

                var repo = new CustomerRepository(db);
                List<Customer> customerList = (List<Customer>)await repo.GetAllAsync();

                // should equal the same amount of rooms
                Assert.Equal(customers.Count, customerList.Count);

                for (int i = 0; i < customers.Count; i++)
                {
                    Assert.Equal(customers[i].Name, customerList[i].Name);
                    Assert.Equal(customers[i].Email, customerList[i].Email);
                    Assert.Equal(customers[i].City, customerList[i].City);
                    Assert.NotEqual(0, customers[i].Id);
                }

            }
        }

        [Fact]
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_customer_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer= await repo.GetByIdAsync(id);

                Assert.Null(customer);
            }
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
            int id = 0;

            Customer customerSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_room_test_getbyid").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);
                    Customer customer = new Customer
                    {
                        Name = "Axel",
                        Email = "axel@me.com",
                        City = "Lufkin"
                    };
                    customerSaved = await repo.CreateAsync(customer);
                    await repo.SaveChangesAsync();
                    id = customerSaved.Id;
                
            }

                // assert (for assert, once again use the context directly for verify.)
                using (var db = new Project15Context(options))
                {
                    var repo = new CustomerRepository(db);
                    Customer customer = await repo.GetByIdAsync(id);

                    Assert.NotEqual(0, customer.Id);
                    Assert.Equal("Axel", customer.Name);
                    Assert.Equal("axel@me.com", customer.Email);
                    Assert.Equal("Lufkin", customer.City);
            }
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_customer_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options));

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer= await repo.GetByIdAsync(id);

                Assert.Null(customer);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(customer, id));
            }
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            int id = 0;
            int wronId = 10;
            Customer customerSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_rooms_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer = new Customer
                {
                    Name = "Axel",
                    Email = "axel@me.com",
                    City = "Lufkin"
                };
                customerSaved = await repo.CreateAsync(customer);
                await repo.SaveChangesAsync();
                id = customerSaved.Id;
            }

            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, customer.Id);
                Assert.Equal("Axel", customer.Name);
                Assert.Equal("axel@me.com", customer.Email);
                Assert.Equal("Lufkin", customer.City);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(customer, wronId));

            }
        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {

            int id = 0;
            int wronId = 10;
            Customer customerSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_rooms_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer = new Customer
                {
                    Name = "Axel",
                    Email = "axel@me.com",
                    City = "Lufkin"
                };
                customerSaved = await repo.CreateAsync(customer);
                await repo.SaveChangesAsync();
                id = customerSaved.Id;

            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new CustomerRepository(db);

                Customer customer = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, customer.Id);
                Assert.Equal("Axel", customer.Name);
                Assert.Equal("axel@me.com", customer.Email);
                Assert.Equal("Lufkin", customer.City);

                customer.Name = "Bob";
                customer.City = "Dallas";

                await repo.UpdateAsync(customer, id);
                await repo.SaveChangesAsync();

                customer = await repo.GetByIdAsync(customer.Id);

                Assert.NotEqual(0, customer.Id);
                Assert.Equal("Bob", customer.Name);
                Assert.Equal("Dallas", customer.City);
            }
        }
    }
}
