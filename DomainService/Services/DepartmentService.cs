using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DomainService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IGenericRepository<Department> repository, ILogger<DepartmentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public Task<IReadOnlyList<Department>> GetDepartments()
        {
            return _repository.GetAll();
        }
    }
}