using CoreDemo.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin,Moderator")]
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public AdminRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var role = _roleManager.Roles.ToList();
            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssingViewModel> modle = new List<RoleAssingViewModel>();
            foreach (var item in role)
            {
                RoleAssingViewModel m = new RoleAssingViewModel();
                m.RoleId = item.Id;
                m.Name = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                modle.Add(m);
            }
            return View(modle);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssingViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user=_userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach(var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user,item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}