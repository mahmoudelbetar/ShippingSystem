using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Interfaces;

namespace ShippingSystem.Controllers
{
    [Authorize(Roles = "Employee")]
    public class GovernoratesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GovernoratesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var govs = _unitOfWork.Governorates.GetAll().Result;
            
            return View(govs);
        }
    }
}
