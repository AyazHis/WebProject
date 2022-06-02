using Microsoft.AspNetCore.Mvc;
using WebProject.Areas.Identity.Data;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        private UserDBContext _db;
        public AdminController (UserDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<WPUser> users = _db.Users;
            return View(users);
        }
        public IActionResult Edit(string? Id)
        {
           if (String.IsNullOrEmpty(Id))
            {
                return NotFound();
            }
            var obj =_db.Users.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WPUser obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
       
    }
}
