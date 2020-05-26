using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public int ProductID { get; set; }
            public int CustomerID { get; set; }    
    }
}
