using AutoMapper;
using ShopTraining.Dtos;
using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderReadDto, Order>();
        }
    }
}
