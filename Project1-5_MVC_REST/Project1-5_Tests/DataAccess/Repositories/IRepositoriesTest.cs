using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Tests.DataAccess.Repositories
{
    interface IRepositoriesTest
    {
        void CreateAddressesWorks();
        void UpdateWorks();
        void UpdateWithWorngIdShouldReturnException();
        void UpdateWithNoIdShouldReturnException();
        void GetAllWorks();
        void GetByIdWorks();
        void GetByIdThatDoesntExistReturnsNull();
        void DeleteWorks();
        void DeleteWithIdThatDoesntExistThrowsException();
    }
}
