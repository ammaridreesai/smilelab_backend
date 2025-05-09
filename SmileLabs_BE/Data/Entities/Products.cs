namespace SmileLabs_BE.Data.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public string CategoryCode { get; set; }
        public double VAT { get; set; }
    }
}
