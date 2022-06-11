using BusinessLayer.Concrete;
using BusinessLayer.ValudationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager bm = new(new EfBlogRepository());
        private readonly CategoryManager cm = new(new EfCategoryRepository());
        Context c = new();
        public IActionResult Index()
        {
            List<Blog> values =bm.GetBlogListWhitCategory();
            return View(values);
        }
        public IActionResult DeleteBlog(int id)
        {
            Blog blogValue = bm.TGetById(id);
            bm.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");

        }
        public IActionResult BlogReadAll(int id)    
        {
            ViewBag.id = id;
            Blog values =bm.TGetById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter(int id)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers
                 .Where(x => x.WriterMail == usermail)
                 .Select(y => y.WriterID)
                 .FirstOrDefault();
            List<Blog> values = bm.GetListWithCategoryByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm=new(new EfCategoryRepository());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv=categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            string username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers
                 .Where(x => x.WriterMail == usermail)
                 .Select(y => y.WriterID)
                 .FirstOrDefault();
            BlogValidatior bv = new();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new(new EfCategoryRepository());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blogValue=bm.TGetById(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers
                 .Where(x => x.WriterMail == usermail)
                 .Select(y => y.WriterID)
                 .FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate= DateTime.Parse(DateTime.Now.ToString());
            p.BlogStatus= true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
