using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleMCVTogetherApp.Models;
using SampleMCVTogetherApp.Services;

namespace SampleMCVTogetherApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepo<int, Customer> _repo;

        public CustomersController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            var customer = _repo.GetT(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Age")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Add(customer) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _repo.GetT(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (_repo.Update(customer))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _repo.GetT(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_repo.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private bool CustomerExists(int id)
        {
            return _repo.GetAll().Any(e => e.Id == id);
        }
    }
}
