using System;
using System.Threading.Tasks;
using Xunit;

namespace Project1_5_Tests.DataAccess.Repositories
{
    public class EmployeeRepositoryTests : ARepositoriesTest
    {
        public EmployeeRepositoryTests() : base() { }

        [Fact]
        public override Task CreateWorksAsync()
        {
            throw new NotImplementedException();
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
