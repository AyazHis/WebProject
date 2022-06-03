using Microsoft.AspNetCore.Mvc;
using WebProject.Blogging;
using WebProject.Blogging.Models;

namespace WebProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDBContext _db;
        public BlogController(BlogDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Blog> objBlogList = _db.Blogs;
            return View(objBlogList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POst
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog obj)
        {
            _db.Blogs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
