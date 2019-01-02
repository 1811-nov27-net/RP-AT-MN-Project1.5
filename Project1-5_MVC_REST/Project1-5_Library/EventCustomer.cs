using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_Library
{
    public partial class EventCustomer
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public bool Paid { get; set; }
        
        public virtual Customer Customer { get; set; }

        public virtual Event Event { get; set; }
    }
}
