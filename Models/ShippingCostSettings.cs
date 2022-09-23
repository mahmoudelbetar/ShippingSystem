using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.Models
{
    public class ShippingCostSettings
    {
        [Key]
        public int Id { get; set; }
        public float DefaultShippingCost { get; set; }
        public float Cost { get; set; }
        public float Weight { get; set; }
        public float ExtraWeightCost { get; set; }
    }
}
