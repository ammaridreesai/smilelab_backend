using SmileLabs_BE.Data.Entities;
using SmileLabs_BE.DTO.Requests;

namespace SmileLabs_BE.Services.CustomerService
{
    public interface ICustomerService
    {
        Task UploadCustomers(UploadFileRequest request);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Doctor>> GetDoctorsWithCustomerCode(string customerCode);
    }
}
