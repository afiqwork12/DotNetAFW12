using FEApplication.Models;
using FEApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEApplication.Controllers
{
    public class UsersController : Controller
    {
        private LoginService _loginService;
        public UsersController(LoginService loginService)
        {
            _loginService = loginService;
        }
        public ActionResult Register()
        {
            return View();
        }
        // POST: UsersController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                user = await _loginService.Register(user);
                if (user != null)
                {
                    HttpContext.Session.SetString("token", user.Token);
                    return RedirectToAction("Index", "Customers");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        // POST: UsersController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                user = await _loginService.Login(user);
                if (user != null)
                {
                    HttpContext.Session.SetString("token", user.Token);
                    return RedirectToAction("Index", "Customers");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
