using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string? StatusName { get; set; }
        [ValidateNever]
        public Order Order { get; set; }
    }
}
