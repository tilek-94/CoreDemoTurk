using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new(new EfBlogRepository());
        Context c = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=blogManager.GetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3=c.Comments.Count();
            string api = "d22fbd7deb4b9fa8295ac6c484bcd114";
            string connection = "https://api.openweathermap.org/data/2.5/weather?" +
                "q=Bishkek&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.api = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
