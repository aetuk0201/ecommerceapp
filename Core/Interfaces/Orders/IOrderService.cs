using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Core.Entities.Orders;

namespace Core.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(string customerEmail, int deliveryMethod, string cartId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUser(string customerEmail);
        Task<Order> GetOrderById(int id, string customerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods();
    }
}