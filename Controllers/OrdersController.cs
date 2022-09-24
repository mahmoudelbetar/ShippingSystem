using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShippingSystem.Controllers
{
    
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Merchant")]
        public IActionResult CreateOrder()
        {
            return View();
        }
    }
}
