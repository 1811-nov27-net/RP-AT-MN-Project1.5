using Project1_5_Library.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_Library
{
    public partial class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        public bool Paid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }

        public void calculateCost()
        {
            int diffDays = (int)(EndDate - StartDate).TotalDays;

            if (diffDays < 0)
                throw new EndDateBeforeStartDateException("End date should be after Start Date different");

            if (diffDays == 0)
                throw new SameDateException("Start date and End date should be different");

            TotalCost = Room.Cost * diffDays;
        }
    }
}
