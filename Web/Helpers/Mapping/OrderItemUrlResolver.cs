using AutoMapper;
using Core.Entities.Orders;
using Microsoft.Extensions.Configuration;
using Web.Models;

namespace Web.Helpers.Mapping
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public IConfiguration _config { get; }
        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (source != null && source.ItemOrdered != null && !string.IsNullOrEmpty(source.ItemOrdered.ImageUrl))
            {
                return _config["ApiUrl"] + source.ItemOrdered.ImageUrl;
            }

            return null;
        }
    }
}