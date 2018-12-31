using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class ReservationView
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

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }

        public List<Customer> CustomerList;
    }
}
