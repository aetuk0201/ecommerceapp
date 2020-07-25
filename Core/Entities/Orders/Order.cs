using System;
using System.Collections.Generic;
using Core.Entities.Identity;

namespace Core.Entities.Orders
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(IReadOnlyList<OrderItem> orderItems, string customerEmail, Address addressToShip, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            OrderItems = orderItems;
            CustomerEmail = customerEmail;
            AddressToShip = addressToShip;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public string CustomerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address AddressToShip { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}