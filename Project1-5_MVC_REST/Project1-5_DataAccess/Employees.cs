using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_5_DataAccess
{
    [Table("Employees", Schema = "Hotel")]
    public partial class Employees
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
