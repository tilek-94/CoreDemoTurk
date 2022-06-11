using BusinessLayer.Concrete;
using BusinessLayer.ValudationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new(new EfWriterRepository()); 
       private readonly Context c=new();
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            ViewBag.v= username;
            var writerName=c.Writers.Where(x=>x.WriterMail== usermail).Select(y=>y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriteNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
           
            return PartialView();

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers
                 .Where(x => x.WriterMail == usermail)
                 .Select(y => y.WriterID)
                 .FirstOrDefault();
            Writer writerValue=writerManager.TGetById(writerID);
            return View(writerValue);

        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            
                writerManager.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            
           }

        [HttpGet]
        public IActionResult WriterAdd()
        {
           
            return View();

        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer w = new();
            if (addProfileImage != null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Image/" ,newimagename);
                var stream=new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = addProfileImage.WriterMail;
            w.WriterName = addProfileImage.WriterName;
            w.WriterPassword = addProfileImage.WriterPassword;
            w.WriterStatus = addProfileImage.WriterStatus;
            w.WriterAbout = addProfileImage.WriterAbout;
            writerManager.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        }
    }
}
