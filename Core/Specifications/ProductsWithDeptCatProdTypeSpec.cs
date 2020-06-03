using Core.Constants;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithDeptCatProdTypeSpec : BaseSpecification<Product>
    {
        public ProductsWithDeptCatProdTypeSpec(ProductSpecParams productSpecParams)
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
            AddInclude(x => x.Department);
            AddInclude(x => x.Category);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name); //default sort
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case AppConstants.deptAsc:
                        AddOrderBy(d => d.Department.Name);
                        break;
                    case AppConstants.deptDesc:
                        AddOrderByDescending(d => d.Department.Name);
                        break;
                    case AppConstants.categoryAsc:
                        AddOrderBy(c => c.Category.Name);
                        break;
                    case AppConstants.categoryDesc:
                        AddOrderByDescending(c => c.Category.Name);
                        break;
                    case AppConstants.prodTypeAsc:
                        AddOrderBy(p => p.ProductType.Name);
                        break;
                    case AppConstants.prodTypeDesc:
                        AddOrderByDescending(p => p.ProductType.Name);
                        break;
                    case AppConstants.priceAsc:
                        AddOrderBy(p => p.Price);
                        break;
                    case AppConstants.priceDesc:
                        AddOrderByDescending(p => p.Price);
                        break;
                    case AppConstants.nameAsc:
                        AddOrderBy(n => n.Name);
                        break;
                    case AppConstants.nameDesc:
                        AddOrderByDescending(n => n.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithDeptCatProdTypeSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Department);
            AddInclude(x => x.Category);
            AddInclude(x => x.ProductType);
        }
    }
}