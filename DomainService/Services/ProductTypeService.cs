using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DomainService.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IGenericRepository<ProductType> _repository;
        private readonly ILogger<ProductTypeService> _logger;
        public ProductTypeService(IGenericRepository<ProductType> repository, ILogger<ProductTypeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return _repository.GetAll();
        }
    }
}