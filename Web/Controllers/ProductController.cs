

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using DomainService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Controllers;
using Web.Errors;
using Web.Helpers.Paging;
using Web.Models;

namespace Shop.Web.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _productTypeService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
                                    IDepartmentService departmentService,
                                    ICategoryService categoryService,
                                    IProductTypeService productTypeService,
                                    IMapper mapper, ILogger<ProductController> logger)
        {
            _productService = productService;
            _departmentService = departmentService;
            _categoryService = categoryService;
            _productTypeService = productTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetProducts();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet]
        public async Task<PagedList<ProductDto>> GetProductsWithSpec(
                                [FromQuery] ProductSpecParams productSpecParams)
        {
            //specifation for product(s) with department, category, and product type
            var spec = new ProductsWithDeptCatProdTypeSpec(productSpecParams);
            //specification for total count of filtered products
            var countSpec = new ProductWithFiltersCountSpec(productSpecParams);

            var totalItems = await _productService.Count(countSpec);

            var products = await _productService.GetProductsWithSpec(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            _logger.LogInformation("Products retreived: {{{ string.Join(", ", data.Name)}}}");

            return new PagedList<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data);
        }

        [HttpGet("{productId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);

            if (product == null) return NotFound(new ApiResponse(AppConstants.NotFound404));

            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductByIdWithSpec(int productId)
        {
            var spec = new ProductsWithDeptCatProdTypeSpec(productId);
            var product = await _productService.GetProductByIdWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(AppConstants.NotFound404));

            _logger.LogInformation("Retrieved { Product } successfully", product.Name);

            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet]
        public async Task<ActionResult<DepartmentDto>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();

            return Ok(_mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentDto>>(departments));
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(categories));
        }

        [HttpGet]
        public async Task<ActionResult<ProductTypeDto>> GetProductTypes()
        {
            var productTypes = await _productTypeService.GetProductTypes();

            return Ok(_mapper.Map<IReadOnlyList<ProductType>, IReadOnlyList<ProductTypeDto>>(productTypes));
        }

    }
}


//Log.Information("Contact {@contact} added to cache with key {@cacheKey}", contact, cacheKey);
