using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Tests.MVC_Rest.Controllers
{
    public interface IControllerTest
    {
        //Get with no ID
        void GetShouldReturnEmptyListWhenHasNoItems();
        void GetShouldReturnAll();
        void GetShouldReturnErrorCode500WhenFailToGetAll();

        //Get With ID
        void GetWithIdShouldReturnItemWithTheSameId();
        void GetWithIdShouldReturnErrorCode500WhenFailToGetById();
        void GetWithIdShouldReturnErrorCode404WhenDoesntExistItemWithId();

        //Post
        void PostShouldReturnCode201WhenCreate();
        void PostShouldReturnErrorCode500WhenFailToCreate();

        //Put
        void PutShouldReturnCode204WhenUpdate();
        void PutShouldReturnErrorCode500WhenFailSearchById();
        void PutShouldReturnErrorCode404WhenDoesntExistItemWithId();
        void PutShouldReturnErrorCode400WhenTryToUpdateItemWithDifferentIdInUrl();
        void PutShouldReturnErrorCode500WhenFailToUpdate();

        //Delete
        void DeleteShouldReturnCode204WhenDeleted();
        void DeleteShouldReturnErrorCode500WhenFailSearchById();
        void DeleteShouldReturnErrorCode404WhenDoesntExistItemWithId();
        void DeleteShouldReturnErrorCode500WhenFailToDelete();
    }
}
