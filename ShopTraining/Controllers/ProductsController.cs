using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopTraining.Data;
using ShopTraining.Dtos;
using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepo repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllProducts()
        {
            var productItems = await _repository.GetAllProductsAsync();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductReadDto>> GetProductById(int id)
        {
            var productItem = await _repository.GetProductByIdAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductReadDto>(productItem));
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto dto)
        {
            var productModel = _mapper.Map<Product>(dto);
            await _repository.CreateProductAsync(productModel);
            await _repository.SaveChangesAsync();

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
            //return Ok(productReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductUpdateDto updatedDto)
        {
            Product productModelFromRepo = _repository.GetProductByIdAsync(id).Result;
            if (productModelFromRepo == null) return NotFound();

            _mapper.Map(updatedDto, productModelFromRepo);
            await _repository.UpdateProductAsync(productModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            var productModelFromRepo = _repository.GetProductByIdAsync(id).Result;
            if (productModelFromRepo == null) return NotFound();

            var productToPatch = _mapper.Map<ProductUpdateDto>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
               return ValidationProblem(ModelState);
            }
            _mapper.Map(productToPatch, productModelFromRepo);
            await _repository.UpdateProductAsync(productModelFromRepo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var productModelFromRepo = _repository.GetProductByIdAsync(id).Result;
            if (productModelFromRepo == null) return NotFound();

            await _repository.DeleteProductAsync(productModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
