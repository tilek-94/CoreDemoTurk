using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager cm = new(new EfCategoryRepository());
        public IActionResult Index()
        {
            List<Category> values = cm.GetList();
            return View(values);
        }
    }
}
