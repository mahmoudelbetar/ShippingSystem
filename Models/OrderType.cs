using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class OrderType
    {
        [Key]
        public int Id { get; set; }
        public string OrderTypeName { get; set; }
    }
}
