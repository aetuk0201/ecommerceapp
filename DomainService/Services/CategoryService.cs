using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DomainService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IGenericRepository<Category> repository, ILogger<CategoryService> logger)
        {
            _repository = repository;
        }

        public Task<IReadOnlyList<Category>> GetCategories()
        {
            return _repository.GetAll();
        }
    }
}