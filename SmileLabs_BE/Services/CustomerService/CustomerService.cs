using SmileLabs_BE.Data.Entities;
using SmileLabs_BE.DTO.Requests;
using SmileLabs_BE.Repositories;

namespace SmileLabs_BE.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryAsync<Customer> _customerRepositoryAsync;  
        private readonly IRepositoryAsync<Doctor> _doctorRepositoryAsync;  
        public CustomerService(IRepositoryAsync<Customer> customerRepositoryAsync,IRepositoryAsync<Doctor> doctorRepositoryAsync)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
            _doctorRepositoryAsync = doctorRepositoryAsync;
        }

        public async Task UploadCustomers(UploadFileRequest request)
        {
            var customers = new List<Customer>();

            using (var stream = new MemoryStream())
            {
                await request.File.CopyToAsync(stream);
                using (var workbook = new ClosedXML.Excel.XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header row

                    foreach (var row in rows)
                    {
                        var product = new Customer
                        {
                            CustomerCode = row.Cell(1).GetValue<int>(),
                            CustomerName = row.Cell(2).GetString(),
                            Street = row.Cell(3).GetString(),
                            Street2 = row.Cell(4).GetString(),
                            Town = row.Cell(5).GetString(),
                            State = row.Cell(6).GetString(),
                            PostalCode = row.Cell(7).GetString(),
                            Country = row.Cell(8).GetString(),
                            Email = row.Cell(9).GetString(),
                            Phone = row.Cell(10).GetString(),
                            AlternatePhone = row.Cell(11).GetString(),
                            Mobile = row.Cell(12).GetString(),
                            Fax = row.Cell(13).GetString(),
                            WebPage = row.Cell(14).GetString(),
                            Vat = row.Cell(15).GetString(),
                            BankAccount = row.Cell(16).GetString(),
                            ContactPerson = row.Cell(17).GetString(),
                        };

                        customers.Add(product);
                    }
                }
            }

            await _customerRepositoryAsync.AddRangeAsync(customers);
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepositoryAsync.GetAllAsync();
        }
        public async Task<List<Doctor>> GetDoctorsWithCustomerCode(string customerCode)
        {
            return await _doctorRepositoryAsync.GetByFilterAsync(x => x.CustomerCode == customerCode);
        }
    }
}
