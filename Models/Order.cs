using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public long? SerialNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        [Required]
        public OrderType OrderTypes { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string FirstPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string SecondPhone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Governorate Governorates { get; set; }
        [Required]
        public City Cities { get; set; }
        [Required]
        public string StreetAndVillage { get; set; }
        public bool IsVillage { get; set; } = false;
        [Required]
        public Branch Branches { get; set; }
        [Required]
        public float OrderCost { get; set; }
        [Required]
        public float TotalWeight { get; set; }
        [MaxLength(100)]
        public string? Notes { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MerchantPhone { get; set; }
        [Required]
        public string MerchantAddress { get; set; }

        public int OrderStatusId { get; set; }
        [ValidateNever]
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }

        public int ShippingTypeId { get; set; }

        [ForeignKey("ShippingTypeId")]
        public ShippingType ShippingType { get; set; }
        
        public int PaymentTypeId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }
        [ValidateNever]
        public Product Product { get; set; }


        public enum OrderType
        {
            Type1,
            Type2,
            Type3
        }

        public enum Governorate
        {
            ElMinoufya,
            Cairo,
            Alexandria,
            ElMansoura
        }

        public enum City
        {
            City1,
            City2,
            City3
        }

        public enum Branch
        {
            B1,
            B2,
            B3,
            B4
        }
        
    }
}
