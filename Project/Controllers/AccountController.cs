using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(ApplicationUser applicationUser)
        {
            applicationUser.Password = applicationUser.FirstName.ToUpper() + applicationUser.LastName + "@123";
            applicationUser.UserName = applicationUser.FirstName + applicationUser.LastName;
            var user = new ApplicationUser
            {
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                RoleId = applicationUser.RoleId,
                Password = applicationUser.FirstName + applicationUser.LastName,
            };
            var result = await _userManager.CreateAsync(user, applicationUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("UserInsertionCompleted", "PropertyManager", applicationUser);
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        public async Task<IActionResult> ChangeProfileSalesAsync()
        {
            ApplicationUser currentUser= await _userManager.GetUserAsync(User);
            ViewBag.userName = currentUser.UserName;
            return View();
        }
        public async Task<IActionResult> ChangeProfilePropertyManagerAsync()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            ViewBag.userName = currentUser.UserName;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeProfile(ChangeProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.UserName = model.userName;
                var result = await _userManager.ChangePasswordAsync(user,model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    if (user.RoleId == 1)
                    {
                        return RedirectToAction("index", "PropertyManager");
                    }
                    else
                        return RedirectToAction("index", "Sales");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel {ReturnUrl = returnUrl};
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.userName, model.password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        var user = await _userManager.FindByNameAsync(model.userName);
                        if (user.RoleId == 1)
                        {
                            return RedirectToAction("index", "PropertyManager");
                        }
                        else
                            return RedirectToAction("index", "Sales");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Login Attempt");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Account", "Login");
        }

    }
}
