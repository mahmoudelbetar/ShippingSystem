using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ShippingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            if(!await _roleManager.RoleExistsAsync("Merchant") || !await _roleManager.RoleExistsAsync("Employee"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Merchant"));
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
                return View();
            }
            else
            {
                return View();
            }
            
        }
    }
}
