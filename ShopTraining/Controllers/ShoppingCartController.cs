using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopTraining.Data;
using ShopTraining.Models;

namespace ShopTraining.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepo productRepo, ShoppingCart shoppingCart)
        {
            _productRepo = productRepo;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public ActionResult GetShoppingCart()
        {
            return Ok(_shoppingCart.GetShoppingCartItems());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddToShoppingCart(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product != null)
            {
                _shoppingCart.AddToCart(product, 1);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromShoppingCart(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product != null)
            {
                _shoppingCart.RemoveFromCart(product);
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult ClearShoppingCart()
        {
            _shoppingCart.ClearCart();
            return NoContent();
        }

        [HttpGet("total")]
        public ActionResult GetShoppingCartTotal()
        {
            return Ok(_shoppingCart.GetShoppingCartTotal());
        }

    }
}