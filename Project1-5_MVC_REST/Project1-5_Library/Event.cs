using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_Library
{
    public partial class Event
    {
        public Event()
        {
            EventsCustomers = new HashSet<EventCustomer>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
        
        public virtual ICollection<EventCustomer> EventsCustomers { get; set; }
    }
}
