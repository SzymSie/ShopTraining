﻿using Microsoft.EntityFrameworkCore;
using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
