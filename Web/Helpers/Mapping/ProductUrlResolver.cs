
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Web.Models;

public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
{
    private readonly IConfiguration _config;

    public ProductUrlResolver(IConfiguration config)
    {
        _config = config;
    }
    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
        {
            return _config["ApiUrl"] + source.ImageUrl;
        }

        return null;
    }
}
