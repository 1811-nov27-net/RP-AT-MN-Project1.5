using Project1_5_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Models
{
    public class CheckoutView
    {
        public int Id { get; set; }
        
        public Reservation Reservation { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }

        public List<Customer> CustomerList { get; set; }
        public List<EventCustomer> EventsCustomer { get; set; }
        
        public decimal TotalCost { get; set; }
    }
}
