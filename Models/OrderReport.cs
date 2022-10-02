namespace ShippingSystem.Models
{
    public class OrderReport
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        
    }
}
