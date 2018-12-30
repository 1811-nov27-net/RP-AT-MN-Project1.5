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
    public class CustomerRepositoryTests : ARepositoriesTest
    {
        public CustomerRepositoryTests() : base() { }
        
        [Fact]
        public override async Task CreateAsync()
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
                customerSaved = await repo.Create(customer);
                await repo.SaveChanges();
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
        public override Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            throw new NotImplementedException();
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
