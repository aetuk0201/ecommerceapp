using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.ShoppingCart
{
    public interface IShoppingCartRepository
    {
        Task<CustomerCart> GetCustomerCart(string cartId);
        Task<CustomerCart> AddUpdateCustomerCart(CustomerCart cart);
        Task<bool> DeleteCustomerCart(string cartId);
    }
}