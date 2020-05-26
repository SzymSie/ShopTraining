using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
