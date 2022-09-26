using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            OrderStatusViewModel orderStatusViewModel = new OrderStatusViewModel()
            {
                Orders = _unitOfWork.Order.GetAll().Result,
                OrderStatuses = new SelectList(_unitOfWork.OrderStatus.GetAll().Result, "Id", "StatusName")
            };
            //var orders = _unitOfWork.Order.GetAll().Result;
            if(orderStatusViewModel.Orders == null)
            {
                OrderStatusViewModel ordervm = new OrderStatusViewModel()
                {
                    Orders = new List<Order>(),
                    OrderStatuses = new SelectList(_unitOfWork.OrderStatus.GetAll().Result, "Id", "StatusName")
                };
                
                return View(ordervm);
            }
            foreach(var order in orderStatusViewModel.Orders)
            {
                order.Governorate = _unitOfWork.Governorates.GetFirstOrDefault(g => g.Id == order.GovernorateId).Result;
                order.City = _unitOfWork.Cities.GetFirstOrDefault(c => c.Id == order.CityId).Result;
            }
            
            return View(orderStatusViewModel);
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
            var status = _unitOfWork.OrderStatus.GetAll().Result;
            

            return Json(new { data = orders });
        }
    }
}
