using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var city = new City();
            ViewBag.Govs = new SelectList(_unitOfWork.Governorates.GetAll().Result, "Id", "GovernorateName");
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(City city)
        {
            var cty = new City()
            {
                CityName = city.CityName,
                GovernorateId = city.GovernorateId,
                PickUpCostShipping = city.PickUpCostShipping,
                NormalCostShipping = city.NormalCostShipping
            };
            _unitOfWork.Cities.Add(cty);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}
