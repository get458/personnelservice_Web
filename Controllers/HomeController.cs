using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Personnel_Service.Models;

namespace Personnel_Service.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AccountUser> _userManager;
        private SignInManager<AccountUser> _signInManager;
        private RoleManager<AccountRole> _roleManager;

        public HomeController(UserManager<AccountUser> userManager,
            SignInManager<AccountUser> signInManager,
            RoleManager<AccountRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string firstname, string lastname, string middlename)
        {
            var user = new AccountUser()
            {
                UserName = username,
                LastName = lastname,
                FirstName = firstname
            };

            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Register");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
