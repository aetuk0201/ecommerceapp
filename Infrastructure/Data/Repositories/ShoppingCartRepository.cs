using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.ShoppingCart;
using StackExchange.Redis;

namespace Infrastructure.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDatabase _database;
        public ShoppingCartRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteCustomerCart(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId);
        }

        public async Task<CustomerCart> GetCustomerCart(string cartId)
        {
            var data = await _database.StringGetAsync(cartId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerCart>(data);
        }

        public async Task<CustomerCart> AddUpdateCustomerCart(CustomerCart cart)
        {
            var created = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(7));

            if (!created) return null;

            return await GetCustomerCart(cart.Id);
        }
    }
}