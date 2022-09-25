using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "يرجي اختيار نوع الطلب")]
        public int OrderTypeId { get; set; }


        [ForeignKey("OrderTypeId")]
        [ValidateNever]
        public OrderType OrderType { get; set; }

        [Required(ErrorMessage = "يرجي اختيار اسم المدينة")]
        public int CityId { get; set; }


        [ForeignKey("CityId")]
        [ValidateNever]
        public City City { get; set; }

        [Required(ErrorMessage = "يرجي اختيار اسم المحافظة")]
        public int GovernorateId { get; set; }

        [ForeignKey("GovernorateId")]
        [ValidateNever]
        public Governorate Governorate { get; set; }

        [Required(ErrorMessage = "يرجي اختيار اسم الفرع")]
        public int BranchId { get; set; }


        [ForeignKey("BranchId")]
        [ValidateNever]
        public Branch Branch { get; set; }


        [Required(ErrorMessage = "يرجي ادخال اسم العميل")]
        [MaxLength(100)]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "يرجي ادخال رقم المحمول للعميل")]
        [DataType(DataType.PhoneNumber)]
        public string FirstPhone { get; set; }


        public string? SecondPhone { get; set; }



        [EmailAddress]
        public string? Email { get; set; }


        
        [Required(ErrorMessage = "يرجي ادخال اسم الشارع و القرية")]
        public string StreetAndVillage { get; set; }


        public bool IsVillage { get; set; }

        
        [Required(ErrorMessage = "يرجي ادخال تكلفة الطلب")]
        public float OrderCost { get; set; }


        [Required(ErrorMessage = "يرجي ادخال الوزن الكلي(كجم)")]
        public float TotalWeight { get; set; }


        [MaxLength(100)]
        public string? Notes { get; set; }


        [Required(ErrorMessage = "يرجي ادخال رقم المحمول للتاجر")]
        [DataType(DataType.PhoneNumber)]
        public string MerchantPhone { get; set; }


        [Required(ErrorMessage = "يرجي ادخال عنوان التاجر")]
        public string MerchantAddress { get; set; }


        public int OrderStatusId { get; set; }


        [ValidateNever]
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }



        public int ShippingTypeId { get; set; }


        [ForeignKey("ShippingTypeId")]
        [ValidateNever]
        public ShippingType ShippingType { get; set; }


        
        public int PaymentTypeId { get; set; }

        [ForeignKey("PaymentTypeId")]
        [ValidateNever]
        public PaymentType PaymentType { get; set; }


        [ValidateNever]
        public Product Product { get; set; }


        
        
    }
}
