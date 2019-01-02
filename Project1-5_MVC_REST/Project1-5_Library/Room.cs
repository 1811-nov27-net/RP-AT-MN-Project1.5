using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_Library
{
    public partial class Room
    {
        public Room()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int Beds { get; set; }

        public bool Reserved { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomType { get; set; }
        
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
