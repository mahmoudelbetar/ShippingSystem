using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingSystem.Models;

namespace ShippingSystem.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ShippingTypes { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> OrderTypes { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Cities { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Branches { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Governorates { get; set; }
    }
}
