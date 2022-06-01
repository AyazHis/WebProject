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
        public IActionResult Edit(int? Id)
        {
            var obj =_db.Users.Find(Id);
            return View(obj);
        } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WPUser obj)
        {   
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.Update();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


    }
}
