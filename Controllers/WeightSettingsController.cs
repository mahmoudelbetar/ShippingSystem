using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Controllers
{
    [Authorize(Roles = "Employee")]
    public class WeightSettingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeightSettingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var weightSettings = _unitOfWork.WeightSettings.GetFirstOrDefault().Result;
            return View(weightSettings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(WeightSettings weightSettings)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _unitOfWork.WeightSettings.Add(weightSettings);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
