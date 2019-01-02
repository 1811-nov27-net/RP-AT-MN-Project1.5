using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("Customers", Schema = "Hotel")]
    public partial class Customers
    {
        public Customers()
        {
            EventsCustomers = new HashSet<EventsCustomers>();
            Reservation = new HashSet<Reservations>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("email")]
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
        public int? Zipcode { get; set; }
        [StringLength(20)]
        public string CardInfo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<EventsCustomers> EventsCustomers { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Reservations> Reservation { get; set; }
    }
}
