using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_MVC_Rest.Models
{
    public partial class Customer
    {
        public Customer()
        {
            EventsCustomers = new HashSet<EventCustomer>();
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [Range(10000,99999)]
        public int? Zipcode { get; set; }

        [StringLength(20)]
        public string CardInfo { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        public virtual ICollection<EventCustomer> EventsCustomers { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
