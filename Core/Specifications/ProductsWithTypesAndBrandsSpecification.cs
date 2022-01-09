using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
