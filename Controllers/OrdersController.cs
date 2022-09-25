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
            var orders = _unitOfWork.Order.GetAll().Result;
            if(orders == null)
            {
                Order order = new Order();
                return View(order);
            }
            return View(orders);
        }

        [Authorize(Roles = "Merchant")]
        
        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Order = new Order()
                {
                    OrderStatusId = 1,
                    OrderDate = DateTime.Now
                },
                Product = new Product(),
                PaymentTypes = new SelectList(_unitOfWork.PaymentTypes.GetAll().Result, "Id", "Type"),
                ShippingTypes = new SelectList(_unitOfWork.ShippingTypes.GetAll().Result, "Id", "Type"),
                OrderTypes = new SelectList(_unitOfWork.OrderTypes.GetAll().Result, "Id", "OrderTypeName"),
                Governorates = new SelectList(_unitOfWork.Governorates.GetAll().Result, "Id", "GovernorateName"),
                Branches = new SelectList(_unitOfWork.Branches.GetAll().Result, "Id", "BranchName"),
                Cities = new SelectList(_unitOfWork.Cities.GetAll().Result, "Id", "CityName"),
            };
            return View(orderViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                OrderViewModel orderViewModel = new OrderViewModel()
                {
                    Order = new Order()
                    {
                        OrderStatusId = 1,
                        OrderDate = DateTime.Now
                    },
                    Product = new Product(),
                    PaymentTypes = new SelectList(_unitOfWork.PaymentTypes.GetAll().Result, "Id", "Type"),
                    ShippingTypes = new SelectList(_unitOfWork.ShippingTypes.GetAll().Result, "Id", "Type")
                };
                return View(orderViewModel);
            }

            model.Order.OrderDate = DateTime.Now;
            _unitOfWork.Order.Add(model.Order);
            _unitOfWork.Save();

            var orderFromDb = _unitOfWork.Order.GetLastOrder();

            model.Product.OrderId = orderFromDb.Id;
            _unitOfWork.Product.Add(model.Product);
            _unitOfWork.Save();
            TempData["Success"] = "Order Created Successfully!";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _unitOfWork.Order.GetAll("OrderStatus,Governorate,Branch,City").Result;
            return Json(new { data = orders });
        }
    }
}
