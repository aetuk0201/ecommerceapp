using AutoMapper;
using Core.Entities;
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
        }
    }
}