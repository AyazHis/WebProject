using Microsoft.AspNetCore.Mvc;
using WebProject.Areas.Identity.Data;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserDBContext _db;
        public AdminController (UserDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<WPUser> users = _db.Users;
            return View(users);
        }
        public IActionResult Edit()
        {
            IEnumerable<WPUser> users = _db.Users;
            return View(users);
        }


    }
}
