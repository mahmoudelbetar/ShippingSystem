using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float ProductWeight { get; set; }
        public int OrderId { get; set; }
        [ValidateNever]
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
