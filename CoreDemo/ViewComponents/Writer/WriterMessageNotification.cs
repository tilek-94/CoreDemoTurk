using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mm = new(new EfMessage2Repository());
        public IViewComponentResult Invoke()
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

    }
}
