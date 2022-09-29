using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }

        public int GovernorateId { get; set; }

        [ValidateNever]
        [ForeignKey("GovernorateId")]
        public Governorate Governorate { get; set; }

        public decimal NormalCostShipping { get; set; }
        public decimal PickUpCostShipping { get; set; }
    }
}
