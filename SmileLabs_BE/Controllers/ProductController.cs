using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmileLabs_BE.DTO.Requests;
using SmileLabs_BE.Services.ProductService;

namespace SmileLabs_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("UploadProducts")]
        public async Task<IActionResult> UpdateClaim([FromForm] UploadFileRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file uploaded.");

            await _productService.UploadProducts(request);
            return Ok();
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {

            var response = await _productService.GetAllCategories();
            return Ok(response);
        }
        [HttpGet("GetProductWithCategories")]
        public async Task<IActionResult> GetProductWithCategories(string categoryCode)
        {

            var response = await _productService.GetProductsWithCategory(categoryCode);
            return Ok(response);
        }


    }
}
