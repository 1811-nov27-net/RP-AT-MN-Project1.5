using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("Events", Schema = "Hotel")]
    public partial class Events
    {
        public Events()
        {
            EventsCustomers = new HashSet<EventsCustomers>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }

        [InverseProperty("Event")]
        public virtual ICollection<EventsCustomers> EventsCustomers { get; set; }
    }
}
