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
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;
        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var products = await _repo.GetAll();
                return View(products);
            }
            return RedirectToAction("Login", "User");
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var product = await _repo.Get(id);
                return View(product);
            }
            return RedirectToAction("Login", "User");
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    product = await _repo.Add(product);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Login", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var product = await _repo.Get(id);
                return View(product);
            }
            return RedirectToAction("Login", "User");
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    product = await _repo.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Login", "User");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                string token = HttpContext.Session.GetString("token");
                _repo.GetToken(token);
                var product = await _repo.Get(id);
                return View(product);
            }
            return RedirectToAction("Login", "User");
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product product)
        {
            try
            {
                if (HttpContext.Session.GetString("token") != null)
                {
                    string token = HttpContext.Session.GetString("token");
                    _repo.GetToken(token);
                    product = await _repo.Delete(id);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Login", "User");
                
            }
            catch
            {
                return View();
            }
        }
    }
}
