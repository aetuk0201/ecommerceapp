using System.Linq;
using Core.Interfaces;
using DomainService.Services;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Web.Errors;

namespace Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.Configure<ApiBehaviorOptions>(options =>
               options.InvalidModelStateResponseFactory = actionContext =>
               {
                   var errors = actionContext.ModelState
                                   .Where(e => e.Value.Errors.Count > 0)
                                   .SelectMany(x => x.Value.Errors)
                                   .Select(x => x.ErrorMessage).ToArray();

                   var errorResponse = new ApiValidationErrorResponse
                   {
                       Errors = errors
                   };

                   return new BadRequestObjectResult(errorResponse);
               }
           );

            return services;
        }
    }
}