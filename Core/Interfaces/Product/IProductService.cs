
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

public interface IProductService
{
    Task<Product> GetProductById(int id);
    Task<Product> GetProductByIdWithSpec(ISpecification<Product> spec);
    Task<IReadOnlyList<Product>> GetProducts();
    Task<IReadOnlyList<Product>> GetProductsWithSpec(ISpecification<Product> spec);
    Task<int> Count(ISpecification<Product> spec);
}