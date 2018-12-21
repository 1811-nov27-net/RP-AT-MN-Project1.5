using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("Reservation", Schema = "Hotel")]
    public partial class Reservations
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalCost { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Reservation")]
        public virtual Customers Customer { get; set; }
        [ForeignKey("RoomId")]
        [InverseProperty("Reservation")]
        public virtual Rooms Room { get; set; }
    }
}
