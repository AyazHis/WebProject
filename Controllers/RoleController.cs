using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManger;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManger = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManger.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await _roleManger.CreateAsync(role);
            return View();
        }
    }
}
