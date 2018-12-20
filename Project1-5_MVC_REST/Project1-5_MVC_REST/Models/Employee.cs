using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_MVC_Rest.Models
{
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public decimal Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
