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
        [Authorize(Roles = "Employee")]
        public IActionResult Index(string? status)
        {
            OrderStatusViewModel orderStatusViewModel = new OrderStatusViewModel()
            {
                Orders = _unitOfWork.Order.GetAll().Result,
                OrderStatuses = new SelectList(_unitOfWork.OrderStatus.GetAll().Result, "Id", "StatusName")
            };
            foreach (var order in orderStatusViewModel.Orders)
            {
                order.Governorate = _unitOfWork.Governorates.GetFirstOrDefault(g => g.Id == order.GovernorateId).Result;
                order.City = _unitOfWork.Cities.GetFirstOrDefault(c => c.Id == order.CityId).Result;
            }
            if(status != "الكل" && status != null)
            {
                orderStatusViewModel.Orders = _unitOfWork.Order.GetAll(o => o.OrderStatus.StatusName == status).Result;
                return View(orderStatusViewModel);
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
                    OrderStatusId = _unitOfWork.OrderStatus.GetFirstOrDefault().Result.Id,
                    OrderDate = DateTime.Now
                },
                Product = new Product(),
                PaymentTypes = new SelectList(_unitOfWork.PaymentTypes.GetAll().Result, "Id", "Type"),
                ShippingTypes = new SelectList(_unitOfWork.ShippingTypes.GetAll().Result, "Id", "Type"),
                OrderTypes = new SelectList(_unitOfWork.OrderTypes.GetAll().Result, "Id", "OrderTypeName"),
                Governorates = new SelectList(_unitOfWork.Governorates.GetAll().Result, "Id", "GovernorateName"),
                Branches = new SelectList(_unitOfWork.Branches.GetAll().Result, "Id", "BranchName"),
                Cities = new SelectList(_unitOfWork.Cities.GetAll().Result, "Id", "CityName")
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
                        OrderStatusId = _unitOfWork.OrderStatus.GetFirstOrDefault().Result.Id,
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
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult EditOrder(int? id)
        {
            OrderProductsViewModel orderViewModel = new()
            {
                Order = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == id).Result,
                Products = _unitOfWork.Product.GetAll(o => o.OrderId == id).Result,
                PaymentTypes = new SelectList(_unitOfWork.PaymentTypes.GetAll().Result, "Id", "Type"),
                ShippingTypes = new SelectList(_unitOfWork.ShippingTypes.GetAll().Result, "Id", "Type"),
                OrderTypes = new SelectList(_unitOfWork.OrderTypes.GetAll().Result, "Id", "OrderTypeName"),
                Governorates = new SelectList(_unitOfWork.Governorates.GetAll().Result, "Id", "GovernorateName"),
                Branches = new SelectList(_unitOfWork.Branches.GetAll().Result, "Id", "BranchName"),
                Cities = new SelectList(_unitOfWork.Cities.GetAll().Result, "Id", "CityName")
            };
            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(OrderProductsViewModel model)
        {
            model.Order.OrderDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _unitOfWork.Order.Update(model.Order);
            foreach(var item in model.Products)
            {
                _unitOfWork.Product.Update(item);
            }
            _unitOfWork.Save();
            TempData["Success"] = "Order Updated Successfully!";
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var order = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == id).Result;
            var currentOrderStatus = _unitOfWork.OrderStatus.GetFirstOrDefault(os => os.Id == order.OrderStatusId).Result;
            currentOrderStatus.CountStatus--;
            _unitOfWork.OrderStatus.Update(currentOrderStatus);
            if(order == null)
            {
                return NotFound();
            }
            _unitOfWork.Order.Remove(order);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public IActionResult SaveOrderStatus(int orderStatusId, int orderId)
        {
            var oldOrder = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == orderId).Result;
            var oldStatus = _unitOfWork.OrderStatus.GetFirstOrDefault(os => os.Id == oldOrder.OrderStatusId).Result;

            oldStatus.CountStatus--;
            _unitOfWork.OrderStatus.Update(oldStatus);
            _unitOfWork.Save();


            var status = _unitOfWork.OrderStatus.GetFirstOrDefault(s => s.Id == orderStatusId).Result;
            var order = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == orderId).Result;
            order.OrderStatusId = status.Id;

            

            _unitOfWork.Order.Update(order);
            _unitOfWork.Save();
            return Ok();

        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public IActionResult OrderReport(int? statusId)
        {
            if(statusId != null && statusId != 0)
            {
                var report = _unitOfWork.Order.GetAll(o => o.OrderStatusId == statusId, "OrderStatus,Governorate,City").Result;
                ViewBag.Status = new SelectList(_unitOfWork.OrderStatus.GetAll().Result, "Id", "StatusName");
                foreach(var rep in report)
                {
                    rep.OrderCost = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == rep.Id).Result.OrderCost;

                    rep.ShippingCost = ((rep.TotalWeight - _unitOfWork.WeightSettings.DefaultWeight()) * _unitOfWork.WeightSettings.ExtraCost()) + _unitOfWork.WeightSettings.DefaultCost();

                    rep.CompanyValue = rep.ShippingCost;

                    rep.RecievedAmount = rep.OrderCost + rep.ShippingCost;

                    if(rep.IsVillage == true)
                    {
                        rep.PaidShippingValue = rep.ShippingCost + _unitOfWork.Cities.GetCityCost(rep.CityId);
                    }
                    else
                    {
                        rep.PaidShippingValue = rep.ShippingCost;
                    }
                }
                return View(report);
            }
            else
            {
                var report = _unitOfWork.Order.GetAll("OrderStatus,Governorate,City").Result;
                ViewBag.Status = new SelectList(_unitOfWork.OrderStatus.GetAll().Result, "Id", "StatusName");

                foreach (var rep in report)
                {
                    rep.OrderCost = _unitOfWork.Order.GetFirstOrDefault(o => o.Id == rep.Id).Result.OrderCost;

                    rep.ShippingCost = ((rep.TotalWeight - _unitOfWork.WeightSettings.DefaultWeight()) * _unitOfWork.WeightSettings.ExtraCost()) + _unitOfWork.WeightSettings.DefaultCost();

                    rep.CompanyValue = rep.ShippingCost;

                    rep.RecievedAmount = rep.OrderCost + rep.ShippingCost;

                    if (rep.IsVillage == true)
                    {
                        rep.PaidShippingValue = rep.ShippingCost + _unitOfWork.Cities.GetCityCost(rep.CityId);
                    }
                    else
                    {
                        rep.PaidShippingValue = rep.ShippingCost;
                    }
                }

                return View(report);
            }
            
        }

        [HttpGet]
        public IActionResult AddProductName()
        {
            var request = HttpContext.Request;
            return Json(new {data = request});
        }
        
    }
}
