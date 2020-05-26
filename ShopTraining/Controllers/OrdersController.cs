using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTraining.Data;
using ShopTraining.Dtos;
using ShopTraining.Models;

namespace ShopTraining.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        private readonly IOrderRepo _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepo repository, IMapper mapper)
        {
           
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetOrdersByCustomerId")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerId(int id)
        {
            var orders = await _repository.GetOrdersByCustomerId(id);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddProductToOrderAsync(OrderDto dto)
        {
            var orderModel = _mapper.Map<Order>(dto);
            await _repository.AddProductToOrderAsync(orderModel);
            await _repository.SaveChangesAsync();

            var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
            return CreatedAtRoute(nameof(GetOrdersByCustomerId), new { Id = orderReadDto.Id }, orderReadDto);
        }

        [HttpGet("{id}/byId", Name = "GetOrderById")]
       
        public async Task<ActionResult<OrderReadDto>> GetOrderById(int id)
        {
            var productItem = await _repository.GetProductByIdAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderReadDto>(productItem));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var productModelFromRepo = _repository.GetProductByIdAsync(id).Result;
            if (productModelFromRepo == null) return NotFound();

            await _repository.DeleteProductFromOrderAsync(productModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}
