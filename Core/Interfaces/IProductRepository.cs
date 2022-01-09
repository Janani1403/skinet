using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductsById(int id);
        Task<IReadOnlyList<Product>> GetProducts();
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}
