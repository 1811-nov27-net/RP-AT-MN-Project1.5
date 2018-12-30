using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project1_5_Tests.MVC_Rest.Controllers
{
    class CheckoutControllerTest
    {
        [Fact]
        public void GetShouldReturnRoomValueWhenCustomerDoesntHaveAnyEvent()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnRoomValuePlusEventsCostWhenCustomerHaveEventAllUnpaid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnRoomValuePlusEventsIgnoringPaidEventsCostWhenCustomerHaveEventPaid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnErrorCode404WhenDoesntExistItemWithId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetShouldReturnErrorCode500WhenFail()
        {
            throw new NotImplementedException();
        }
    }
}
