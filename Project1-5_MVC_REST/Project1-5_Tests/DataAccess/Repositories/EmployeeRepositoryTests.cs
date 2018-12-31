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
        public override async Task GetAllWorksAsync()
        {
            List<Employee> Employees = new List<Employee>();
            Employee EmployeeSaved = null;

            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_Employee_test_getAll").Options;

            using (var db = new Project15Context(options)) ;

            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                for (int i = 0; i < 5; i++)
                {
                    Employee Employee = new Employee { Name = $"Axel{i}", Salary = i, Role = $"developer {i}" };
                    EmployeeSaved = await repo.CreateAsync(Employee);
                    await repo.SaveChangesAsync();
                    Employees.Add(EmployeeSaved);
                }
            }
            using (var db = new Project15Context(options))
            {

                var repo = new EmployeeRepository(db);
                List<Employee> EmployeeList = (List<Employee>)await repo.GetAllAsync();

                // should equal the same amount of employees
                Assert.Equal(Employees.Count, EmployeeList.Count);

                for (int i = 0; i < Employees.Count; i++)
                {
                    Assert.Equal(Employees[i].Name, EmployeeList[i].Name);
                    Assert.Equal(Employees[i].Salary, EmployeeList[i].Salary);
                    Assert.Equal(Employees[i].Role, EmployeeList[i].Role);
                    Assert.NotEqual(0, Employees[i].Id);
                }

            }
        }

        [Fact]
        public override async Task GetByIdThatDoesntExistReturnsNullAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_Employee_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee Employee = await repo.GetByIdAsync(id);

                Assert.Null(Employee);
            }
        }

        [Fact]
        public override async Task GetByIdWorksAsync()
        {
            int id = 0;

            Employee EmployeeSaved = null;

            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_employee_test_getbyid").Options;
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);
                Employee Employee = new Employee
                {
                    Name = "Axel",
                    Salary = 60000,
                    Role = "developer"
                };
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
            }
        }

        [Fact]
        public override async Task UpdateWithNoIdShouldReturnExceptionAsync()
        {
            int id = 1000;

            var options = new DbContextOptionsBuilder<Project15Context>()
                          .UseInMemoryDatabase("db_Employee_test_getAll").Options;

            // arrange (use the context directly - we assume that works)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee Employee = await repo.GetByIdAsync(id);

                Assert.Null(Employee);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(Employee, id));
            }
        }

        [Fact]
        public override async Task UpdateWithWrongIdShouldReturnExceptionAsync()
        {
            int id = 0;
            int wronId = 10;
            Employee EmployeeSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_employee_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // assert (for assert, once again use the context directly for verify.)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee Employee = new Employee
                {
                    Name = "Axel",
                    Salary = 60000,
                    Role = "developer"
                };
                EmployeeSaved = await repo.CreateAsync(Employee);
                await repo.SaveChangesAsync();
                id = EmployeeSaved.Id;
            }

            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee employee = await repo.GetByIdAsync(id);

                Assert.NotEqual(0, employee.Id); // should get some generated ID
                Assert.Equal(EmployeeSaved.Id, employee.Id);
                Assert.Equal("Axel", employee.Name);
                Assert.Equal(60000, employee.Salary);
                Assert.Equal("developer", employee.Role);

                await Assert.ThrowsAsync<ArgumentException>(() => repo.UpdateAsync(employee, wronId));

            }
        }

        [Fact]
        public override async Task UpdateWorksAsync()
        {
            int id = 0;
            int wronId = 10;
            Employee EmployeeSaved = null;
            // arrange (use the context directly - we assume that works)
            var options = new DbContextOptionsBuilder<Project15Context>()
                .UseInMemoryDatabase("db_employee_test_update").Options;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options)) ;

            // act (for act, only use the repo, to test it)
            using (var db = new Project15Context(options))
            {
                var repo = new EmployeeRepository(db);

                Employee Employee = new Employee
                {
                    Name = "Axel",
                    Salary = 60000,
                    Role = "developer"
                };
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

                employee.Name = "Bob";
                employee.Salary = 50000;

                await repo.UpdateAsync(employee, id);
                await repo.SaveChangesAsync();

                employee = await repo.GetByIdAsync(employee.Id);

                Assert.NotEqual(0, employee.Id);
                Assert.Equal("Bob", employee.Name);
                Assert.Equal(50000, employee.Salary);
            }
        }
    }
}
