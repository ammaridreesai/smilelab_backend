using SmileLabs_BE.Data.Entities;

namespace SmileLabs_BE.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        Task AddProductRange(List<Products> products);
        Task<List<ProductCategory>> GetAllCategories();
        Task<List<Products>> GetProductsWithCategory(string categoryCode = "");
    }
}
