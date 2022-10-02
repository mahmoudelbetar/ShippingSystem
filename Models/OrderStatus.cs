using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShippingSystem.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string? StatusName { get; set; }
        
        public int? CountStatus { get; set; }
    }
}
