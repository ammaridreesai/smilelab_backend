using SmileLabs_BE.Data.Entities;
using SmileLabs_BE.DTO.Requests;

namespace SmileLabs_BE.Services.ProductService
{
    public interface IProductService
    {
        Task UploadProducts(UploadFileRequest request);
        Task<List<ProductCategory>> GetAllCategories();
        Task<List<Products>> GetProductsWithCategory(string categoryCode = "");
    }
}
