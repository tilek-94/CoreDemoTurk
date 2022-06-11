using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4: ViewComponent
    {
         AdminManager adm=new(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            AdminModel values = adm.TGetById(1); 
            return View(values);
        }
    }
}
