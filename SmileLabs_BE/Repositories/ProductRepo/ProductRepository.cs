using Microsoft.EntityFrameworkCore;
using SmileLabs_BE.Data;
using SmileLabs_BE.Data.Entities;

namespace SmileLabs_BE.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductRange(List<Products> products)
        {
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProductCategory>> GetAllCategories()
        {
            return await _context.ProductCategory.ToListAsync();
        }
        public async Task<List<Products>> GetProductsWithCategory(string categoryCode="")
        {
            return await _context.Products.Where(x=>x.CategoryCode == categoryCode).ToListAsync();
        }
    }
}
