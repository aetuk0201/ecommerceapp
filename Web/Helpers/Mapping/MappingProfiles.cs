using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.Orders;
using Web.Helpers.Mapping;
using Web.Models;

namespace Shop.Web.Helpers.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>())
                .ReverseMap();

            CreateMap<ProductType, ProductTypeDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerCart, CustomerCartDto>().ReverseMap();

            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductOrderedId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.ImageUrl))
            .ForMember(d => d.ImageUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}