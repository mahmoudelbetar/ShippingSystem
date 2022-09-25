using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class Governorate
    {
        [Key]
        public int Id { get; set; }
        public string GovernorateName { get; set; }
        public bool IsActive { get; set; }
        
    }
}
