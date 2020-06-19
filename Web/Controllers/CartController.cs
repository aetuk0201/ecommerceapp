using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ILogger<CartController> __logger;
        private readonly ICartService _cartService;
        public CartController(ICartService cartService, ILogger<CartController> _logger)
        {
            _cartService = cartService;
            __logger = _logger;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCartById(string id)
        {
            var cart = await _cartService.GetCustomerCart(id);
            return Ok(cart ?? new CustomerCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCart>> AddOrUpdateCart(CustomerCart cart)
        {
            var updatedCart = await _cartService.AddUpdateCustomerCart(cart);

            return (updatedCart);
        }

        [HttpDelete]
        public async Task DeleteCart(string id)
        {
            await _cartService.DeleteCustomerCart(id);
        }
    }
}