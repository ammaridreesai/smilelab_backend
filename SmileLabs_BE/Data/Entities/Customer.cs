namespace SmileLabs_BE.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Street { get; set; }
        public string? Street2 { get; set; }
        public string Town { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? WebPage { get;set; }
        public string? Vat { get; set; }
        public string? BankAccount { get; set; }
        public string? ContactPerson { get; set; } 

    }
}
