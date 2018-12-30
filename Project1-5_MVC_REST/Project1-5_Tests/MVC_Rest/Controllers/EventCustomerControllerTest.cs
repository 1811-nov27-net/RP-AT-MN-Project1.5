using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project1_5_Tests.MVC_Rest.Controllers
{
    public class EventCustomerControllerTest : IControllerTest
    {
        [Fact]
        public void DeleteShouldReturnCode204WhenDeleted()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeleteShouldReturnErrorCode404WhenDoesntExistItemWithId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeleteShouldReturnErrorCode500WhenFailSearchById()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeleteShouldReturnErrorCode500WhenFailToDelete()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnAll()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnEmptyListWhenHasNoItems()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnErrorCode500WhenFailToGetAll()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetWithIdShouldReturnErrorCode404WhenDoesntExistItemWithId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetWithIdShouldReturnErrorCode500WhenFailToGetById()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetWithIdShouldReturnItemWithTheSameId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PostShouldReturnCode201WhenCreate()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PostShouldReturnErrorCode500WhenFailToCreate()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutShouldReturnCode204WhenUpdate()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutShouldReturnErrorCode400WhenTryToUpdateItemWithDifferentIdInUrl()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutShouldReturnErrorCode404WhenDoesntExistItemWithId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutShouldReturnErrorCode500WhenFailSearchById()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutShouldReturnErrorCode500WhenFailToUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
