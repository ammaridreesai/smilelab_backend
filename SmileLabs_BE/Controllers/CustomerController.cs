using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmileLabs_BE.DTO.Requests;
using SmileLabs_BE.Services.CustomerService;

namespace SmileLabs_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("UploadProducts")]
        public async Task<IActionResult> UpdateClaim([FromForm] UploadFileRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file uploaded.");

            await _customerService.UploadCustomers(request);
            return Ok();
        }
        [HttpGet("GetAlCustomers")]
        public async Task<IActionResult> GetAlCustomers()
        {

            var response = await _customerService.GetAllCustomers();
            return Ok(response);
        }
        [HttpGet("GetDoctorWithCustomerCode")]
        public async Task<IActionResult> GetDoctorWithCustomerCode(string customerCode)
        {

            var response = await _customerService.GetDoctorsWithCustomerCode(customerCode);
            return Ok(response);
        }
    }
}
