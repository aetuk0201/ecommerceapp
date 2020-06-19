using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.ShoppingCart;
using Microsoft.Extensions.Logging;

namespace DomainService.Services
{
    public class CartService : ICartService
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly ILogger<CartService> _logger;
        public CartService(IShoppingCartRepository cartRepository, ILogger<CartService> logger)
        {
            _logger = logger;
            _cartRepository = cartRepository;

        }
        public async Task<CustomerCart> AddUpdateCustomerCart(CustomerCart cart)
        {
            return await _cartRepository.AddUpdateCustomerCart(cart);
        }

        public async Task<bool> DeleteCustomerCart(string cartId)
        {
            return await _cartRepository.DeleteCustomerCart(cartId);
        }

        public async Task<CustomerCart> GetCustomerCart(string cartId)
        {
            return await _cartRepository.GetCustomerCart(cartId);
        }
    }
}