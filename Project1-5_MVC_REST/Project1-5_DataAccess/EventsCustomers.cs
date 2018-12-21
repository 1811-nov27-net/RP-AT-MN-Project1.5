using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("EventsCustomers", Schema = "Hotel")]
    public partial class EventsCustomers
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public bool Paid { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("EventsCustomers")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("EventId")]
        [InverseProperty("EventsCustomers")]
        public virtual Events Event { get; set; }
    }
}
