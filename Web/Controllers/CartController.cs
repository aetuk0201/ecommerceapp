using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IMapper mapper, ILogger<CartController> logger)
        {
            _mapper = mapper;
            _cartService = cartService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart>> GetCartById(string id)
        {
            var cart = await _cartService.GetCustomerCart(id);
            return Ok(cart ?? new CustomerCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerCartDto>> AddOrUpdateCart(CustomerCartDto cart)
        {
            var customerCart = _mapper.Map<CustomerCartDto, CustomerCart>(cart);
            var updatedCart = await _cartService.AddUpdateCustomerCart(customerCart);

            return _mapper.Map<CustomerCart, CustomerCartDto>(updatedCart);
        }

        [HttpDelete]
        public async Task DeleteCart(string id)
        {
            await _cartService.DeleteCustomerCart(id);
        }
    }
}