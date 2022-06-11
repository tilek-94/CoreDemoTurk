using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
       private readonly BlogManager bm = new(new EfBlogRepository());
        public IActionResult Index()
        {
            using (Context c = new())
            {
                var username = User.Identity.Name;
                var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
                var writerID = c.Writers
                     .Where(x => x.WriterMail == usermail)
                     .Select(y => y.WriterID)
                     .FirstOrDefault();
                ViewBag.v1 = c.Blogs.Count().ToString();
                ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerID).Count().ToString();
                ViewBag.v3 = c.Categorys.Count();
            }
            return View();
        }
    }
}
