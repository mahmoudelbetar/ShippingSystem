using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Interfaces;

namespace ShippingSystem.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var branches = _unitOfWork.Branches.GetAll().Result;
            foreach(var branch in branches)
            {
                branch.AddingDate = DateTime.Now;
            }
            return View(branches);
        }
    }
}
