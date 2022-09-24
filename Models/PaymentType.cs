using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        [ValidateNever]
        public Order Order { get; set; }
    }
}
