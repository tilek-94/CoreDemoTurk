using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
               
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new();
            var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
              x.WriterPassword == writer.WriterPassword);
            if (datavalue != null)
            {
                var clims = new List<Claim> { 
                new Claim(ClaimTypes.Name,writer.WriterMail)
                };
                ClaimsIdentity useridentity = new(clims, "a");
                ClaimsPrincipal princial = new(useridentity);
                await HttpContext.SignInAsync(princial);
                return RedirectToAction("Index", "Dashboard");
            }
            else { return View(); }

        }
*/
       

    }
}
