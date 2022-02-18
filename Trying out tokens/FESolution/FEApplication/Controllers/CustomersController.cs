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
    public class CustomersController : Controller
    {
        private readonly IRepo<int, Customer> _repo;

        public CustomersController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }
        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var customers = await _repo.GetAll();
                return View(customers.ToList());
            }
            return View();
        }

        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var customer = await _repo.Get(id);
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    customer = await _repo.Add(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token); 
                var customer = await _repo.Get(id);
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Customer customer)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    await _repo.Update(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var customer = await _repo.Get(id);
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Customer customer)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    customer = await _repo.Delete(customer.Id);
                    if (customer != null)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }
    }
}
