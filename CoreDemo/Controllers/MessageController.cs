using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new(new EfMessage2Repository());
        public IActionResult InBox()
        {    
            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers
                 .Where(x => x.WriterMail == usermail)
                 .Select(y => y.WriterID)
                 .FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);

        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            Message2 value = mm.TGetById(id);
            return View(value);
        }
    }
}
