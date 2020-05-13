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
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var productItems = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);
            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(productItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto dto)
        {
            var productModel = _mapper.Map<Product>(dto);
            _repository.CreateProduct(productModel);
            _repository.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
            //return Ok(productReadDto);
        }



        // TO DO

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductCreateDto updatedDto)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null) return NotFound();

            _mapper.Map(updatedDto, productModelFromRepo);
            _repository.UpdateProduct(productModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


        // TO DO


        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductCreateDto> patchDoc)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null) return NotFound();

            var productToPatch = _mapper.Map<ProductCreateDto>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(productToPatch, productModelFromRepo);
            _repository.UpdateProduct(productModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteProduct(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null) return NotFound();

            _repository.DeleteProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
