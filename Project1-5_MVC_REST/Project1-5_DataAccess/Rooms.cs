using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("Rooms", Schema = "Hotel")]
    public partial class Rooms
    {
        public Rooms()
        {
            Reservation = new HashSet<Reservations>();
        }

        public int Id { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        public int Beds { get; set; }
        public bool Reserved { get; set; }
        [Required]
        [StringLength(50)]
        public string RoomType { get; set; }

        [InverseProperty("Room")]
        public virtual ICollection<Reservations> Reservation { get; set; }
    }
}
