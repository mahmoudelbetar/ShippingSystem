using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class WeightSettings
    {
        [Key]
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public decimal Cost { get; set; }
        public decimal ExtraWeightCost { get; set; }
    }
}
