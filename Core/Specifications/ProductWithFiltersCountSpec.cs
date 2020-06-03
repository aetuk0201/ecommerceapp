using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersCountSpec : BaseSpecification<Product>
    {
        public ProductWithFiltersCountSpec(ProductSpecParams productSpecParams)
        : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) ||
                                            x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.DepartmentId.HasValue ||
                    x.DepartmentId == (int)productSpecParams.DepartmentId.Value) &&
                (!productSpecParams.CategoryId.HasValue ||
                    x.CategoryId == (int)productSpecParams.CategoryId.Value) &&
                (!productSpecParams.ProductTypeId.HasValue ||
                    x.ProductTypeId == (int)productSpecParams.ProductTypeId.Value))
        {

        }
    }
}