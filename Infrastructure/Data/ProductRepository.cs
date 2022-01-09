using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        StoreContext _context;
        public ProductRepository(StoreContext context) {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductsById(int id)
        {
            return await _context.Products.FindAsync(id );
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
