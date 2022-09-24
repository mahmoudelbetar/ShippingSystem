using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;
using ShippingSystem.ViewModels;

namespace ShippingSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Merchant")]
        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Order = new Order(),
                Product = new Product(),
                PaymentTypes = new SelectList(_unitOfWork.PaymentTypes.GetAll().Result, "Id", "Type"),
                ShippingTypes = new SelectList(_unitOfWork.ShippingTypes.GetAll().Result, "Id", "Type")
            };
            return View(orderViewModel);
        }
    }
}
