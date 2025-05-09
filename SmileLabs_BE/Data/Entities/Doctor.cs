namespace SmileLabs_BE.Data.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CustomerCode { get; set; }
        public string? Surname { get;set; }
        public string? Address { get; set; }
        public string? LicenseNumber { get;set; }
        public string? Street { get; set; }
        public string? Street2 { get; set; }
        public string? Town { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; } 
        public string? Webpage { get; set; }
    }
}
