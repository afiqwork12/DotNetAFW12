using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleMCVTogetherApp.Models;
using SampleMCVTogetherApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepo<string, User> _adding;
        private readonly IRepo<int, Customer> _repo;

        public UserController(IRepo<string, User> adding, IRepo<int, Customer> repo)
        {
            _adding = adding;
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        IEnumerable<SelectListItem> GetUserRoles()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.Add(new SelectListItem() { Text = "Admin", Value = "admin" });
            roles.Add(new SelectListItem() { Text = "Power User", Value = "power" });
            roles.Add(new SelectListItem() { Text = "User", Value = "user" });
            //List<string> roles = new List<string>()
            //{
            //    "Admin",
            //    "Power User",
            //    "User"
            //};
            //SelectList selectListItems = new SelectList(roles);
            return roles;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in _adding.GetAll())
                {
                    if (item.Username == user.Username)
                    {
                        if (item.Password == user.Password)
                        {
                            if (TempData["un"] == null)
                            {
                                TempData.Add("un", user.Username);
                            }
                            else
                            {
                                TempData["un"] = user.Username;
                            }
                            return RedirectToAction("Index", "Customers", new { area = "" });
                        }
                    }
                }
            }
            return View(user);
        }
        public IActionResult Register()
        {
            ViewBag.Roles = GetUserRoles();
            return View(new UserCustomer());
        }
        [HttpPost]
        public IActionResult Register(UserCustomer userCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer customer = new Customer();
                    customer.Name = userCustomer.Name;
                    customer.Age = userCustomer.Age;
                    customer = _repo.Add(customer);
                    if (customer != null)
                    {
                        User user = new User();
                        user.Username = userCustomer.Username;
                        user.Password = userCustomer.Password;
                        user.CustomerId = customer.Id;
                        user.Role = userCustomer.Role;
                        user = _adding.Add(user);
                        TempData.Add("un", user.Username);
                        if (user != null)
                        {
                            return RedirectToAction("Login");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(userCustomer, ex.Message);
                }
            }
            return View(userCustomer);
        }
    }
}
