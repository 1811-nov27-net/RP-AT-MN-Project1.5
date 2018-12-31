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
    public class EmployeeRepositoryTests : ARepositoriesTest
    {
        public EmployeeRepositoryTests() : base() { }

        [Fact]
        public override async Task CreateWorksAsync()
        {
            Employee employeeSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Employee_test_create").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                //Create Employee
                Employee employee = new Employee { Name = "Axel", Salary = 60000, Role = "developer" };
                employeeSaved = await repo.CreateAsync(employee);
                await repo.SaveChangesAsync();
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);
                Employee employee = Mapper.Map<Employees, Employee>(db.Employees.First(m => m.Name == "Axel"));

                Assert.NotEqual(0, employee.Id); // should get some generated ID
                Assert.Equal(employeeSaved.Id, employee.Id);
                Assert.Equal("Axel", employee.Name);
                Assert.Equal(60000, employee.Salary);
                Assert.Equal("developer", employee.Role);
            }
        }

        [Fact]
        public override async Task DeleteWithIdThatDoesntExistThrowsExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Employee_test_delete").Options;

            // arrange (use the context directl - we assume that it works)
            using (var db = new Project15Context(options)) ;


            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee Employee = await repo.GetByIdAsync(id);

                Assert.Null(Employee);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.DeleteAsync(id));
            }
        }

        [Fact]
        public override async Task DeleteWorksAsync()
        {
            Employee EmployeeSaved = null;
            int id = 0;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Employee_test_delete").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                //Create Employee
                Employee Employee = new Employee { Name = "Axel", Salary = 60000, Role = "developer" };
                EmployeeSaved = await repo.CreateAsync(Employee);
                await repo.SaveChangesAsync();

                id = EmployeeSaved.Id;
            }

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);
                Employee employee = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, employee.Id); // should get some generated ID
                Assert.Equal(EmployeeSaved.Id, employee.Id);
                Assert.Equal("Axel", employee.Name);
                Assert.Equal(60000, employee.Salary);
                Assert.Equal("developer", employee.Role);

                await repo.DeleteAsync(id);
                await repo.SaveChangesAsync();
                employee = await repo.GetByIdAsync(id);

                Assert.Null(employee);
            }
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
