using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project1_5_Tests.Library
{
    public class ReservationTest
    {
        public static object[][] SameDate =
        {
            new object[] { new DateTime(2018,12,27), new DateTime(2018, 12, 27) },
            new object[] { new DateTime(2018, 12, 27, 0,0,0), new DateTime(2018, 12, 27, 23, 59, 59) },
            new object[] { new DateTime(2018, 12, 27, 9,0,0), new DateTime(2018, 12, 27, 13, 59, 59) }
        };

        public static object[][] DifferentDates =
        {
            new object[] { new DateTime(2018, 12,26), new DateTime(2018, 12, 27), 50.0 },
            new object[] { new DateTime(2018, 12, 26, 0,0,0), new DateTime(2018, 12, 27, 23, 59, 59), 50.0 },
            new object[] { new DateTime(2018, 12, 26, 9,0,0), new DateTime(2018, 12, 27, 13, 59, 59), 50.0 },

            new object[] { new DateTime(2018, 12, 25), new DateTime(2018, 12, 27), 100 },
            new object[] { new DateTime(2018, 12, 25, 0,0,0), new DateTime(2018, 12, 27, 23, 59, 59), 100.0 },
            new object[] { new DateTime(2018, 12, 25, 9,0,0), new DateTime(2018, 12, 27, 23, 59, 59), 100.0 },
            new object[] { new DateTime(2018, 12, 25, 23,59,59), new DateTime(2018, 12, 27, 23, 59, 59), 100.0 },

            new object[] { new DateTime(2018, 12, 25, 0,0,0), new DateTime(2018, 12, 28, 0, 0, 0), 150.0 },
        };

        [Theory, MemberData(nameof(SameDate))]
        public void calculateCostWithSameStartDateAndEndDateShouldReturnException(DateTime startDate, DateTime endDate)
        {
            Room room = new Room() { Beds = 1, Cost = 50, RoomType = "Standart" };
            Reservation r = new Reservation() { CustomerId = 1, Room = room, StartDate = startDate, EndDate = endDate };

            Assert.Throws<ArgumentException>(() => r.calculateCost());
        }
        
        [Theory, MemberData(nameof(DifferentDates))]
        public void calculateCostWithDifferentDatesShouldReturnCost(DateTime startDate, DateTime endDate, decimal expected)
        {
            Room room = new Room() { Beds = 1, Cost = 50, RoomType = "Standart" };
            Reservation r = new Reservation() { CustomerId = 1, Room = room, StartDate = startDate, EndDate = endDate };

            r.calculateCost();

            Assert.Equal(expected, r.TotalCost);
        }
    }
}
