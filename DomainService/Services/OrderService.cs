using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Interfaces.Orders;
using Core.Interfaces.ShoppingCart;
using Core.Specifications;
using Infrastructure.Data.Repositories;

namespace DomainService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartRepository _cartRepo;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IShoppingCartRepository cartRepo)
        {
            _unitOfWork = unitOfWork;
            _cartRepo = cartRepo;
        }
        public async Task<Order> CreateOrder(string customerEmail, int deliveryMethodId, string cartId, Address shippingAddress)
        {
            var cart = await _cartRepo.GetCustomerCart(cartId);

            //get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in cart.CartItems)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetById(item.Id);
                if (productItem != null)
                {
                    var itemOrdered = new ProductOrdered(productItem.Id, productItem.Name, productItem.ImageUrl);
                    var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                    items.Add(orderItem);
                }
                else
                {
                    throw new ArgumentNullException(productItem.GetType().Name, "product item with Id " + item.Id + " does not exist");
                }
            }

            // delivery method
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetById(deliveryMethodId);

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // create order
            var order = new Order(items, customerEmail, shippingAddress, deliveryMethod, subtotal);
            _unitOfWork.Repository<Order>().Add(order);

            // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // delete cart
            await _cartRepo.DeleteCustomerCart(cartId);

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().GetAll();
        }

        public async Task<Order> GetOrderById(int id, string customerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, customerEmail);

            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUser(string customerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(customerEmail);

            return await _unitOfWork.Repository<Order>().GetAllWithSpec(spec);
        }
    }
}