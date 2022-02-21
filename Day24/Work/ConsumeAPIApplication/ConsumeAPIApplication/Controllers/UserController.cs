using ConsumeAPIApplication.Models;
using ConsumeAPIApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeAPIApplication.Controllers
{
    public class UserController : Controller
    {
        private LoginService _loginService;
        public UserController(LoginService loginService)
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
                    return RedirectToAction("Index", "Product");
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
                    return RedirectToAction("Index", "Product");
                }
                return View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
    }
}
