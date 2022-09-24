using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingSystem.Models;

namespace ShippingSystem.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ShippingTypes { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
    }
}
