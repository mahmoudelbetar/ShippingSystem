using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingSystem.Models;

namespace ShippingSystem.ViewModels
{
    public class OrderStatusViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> OrderStatuses { get; set; }
    }
}
