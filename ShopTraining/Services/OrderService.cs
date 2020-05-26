using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.DependencyInjection;
using ShopTraining.Data;
using ShopTraining.Models;
using System;
using System.Linq;
using AppContext = ShopTraining.Data.AppContext;

namespace ShopTraining.Services
{
    public class OrderService
    {
        private readonly IOrderRepo _repo;

        public OrderService(IOrderRepo repo)
        {
            _repo = repo;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // public Order GetBasket (IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var conttext = services.GetService<AppContext>();

        //    string basketId = session.GetString("CustomerId") ?? Guid.NewGuid().ToString();
        //    session.SetString("BasketId", basketId);
        //    return new Order(conttext) { CustomerId = basketId };
            
            
        //}
         

    }
}
