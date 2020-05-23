using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace DomainService.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepo;

        public ProductService(IGenericRepository<Product> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public async Task<int> Count(ISpecification<Product> spec)
        {
            return await _genericRepo.Count(spec);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _genericRepo.GetById(id);
        }

        public async Task<Product> GetProductByIdWithSpec(ISpecification<Product> spec)
        {
            var product = await _genericRepo.GetEntityWithSpec(spec);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            var products = await _genericRepo.GetAll();
            return products;
        }

        public async Task<IReadOnlyList<Product>> GetProductsWithSpec(ISpecification<Product> spec)
        {
            var products = await _genericRepo.GetAllWithSpec(spec);
            return products;
        }
    }
}