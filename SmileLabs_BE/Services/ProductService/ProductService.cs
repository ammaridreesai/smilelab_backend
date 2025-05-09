using SmileLabs_BE.Data.Entities;
using SmileLabs_BE.DTO.Requests;
using SmileLabs_BE.Repositories.ProductRepo;

namespace SmileLabs_BE.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task UploadProducts(UploadFileRequest request)
        {
            var products = new List<Products>();

            using (var stream = new MemoryStream())
            {
                await request.File.CopyToAsync(stream);
                using (var workbook = new ClosedXML.Excel.XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header row

                    foreach (var row in rows)
                    {
                        var product = new Products
                        {
                            ProductCode = row.Cell(1).GetString(),
                            ProductName = row.Cell(2).GetString(),
                            BasePrice = row.Cell(3).GetDouble(),
                            CategoryCode = row.Cell(4).GetString(),
                            VAT = row.Cell(6).GetDouble()
                        };

                        products.Add(product);
                    }
                }
            }

            await _repository.AddProductRange(products);
        }

        public async Task<List<ProductCategory>> GetAllCategories()
        {
            try
            {
                return await _repository.GetAllCategories();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Products>> GetProductsWithCategory(string categoryCode = "")
        {
            try
            {
                return await _repository.GetProductsWithCategory(categoryCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
