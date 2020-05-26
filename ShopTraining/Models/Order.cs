using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        




    }
}
