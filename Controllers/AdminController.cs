using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebProject.Areas.Identity.Data;




namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserDBContext _db;
        public AdminController(UserDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<WPUser> users = _db.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(string? Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return NotFound();
            }
            var obj =  _db.Users.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WPUser obj)
        {   
            if (ModelState.IsValid)
            {
                //_db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;  
                //_db.Configuration.AutoDetectChangesEnabled = false;
                //_db.Configuration.ValidateOnSaveEnabled = false;
                _db.Users.Update(obj);
                await _db.SaveChangesAsync();
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

    }
}
