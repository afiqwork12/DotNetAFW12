using EmployeeServiceApp.Models;
using EmployeeServiceApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServiceApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepo<int, Employee> _repo;
        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Token") != null)
            {
                string token = HttpContext.Session.GetString("Token");
                _repo.GetToken(token);
                var employees = await _repo.GetAll();
                return View(employees);
            }
            return View();
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employee = await _repo.GetT(id);
            if (employee != null)
            {
                return View(employee);
            }
            return NotFound();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                employee = await _repo.AddAsync(employee);
                if (employee != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var employee = await _repo.GetT(id);
            if (employee != null)
            {
                return View(employee);
            }
            return NotFound();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            try
            {
                employee = await _repo.Update(employee);
                if (employee != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _repo.GetT(id);
            if (employee != null)
            {
                return View(employee);
            }
            return NotFound();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Employee employee)
        {
            try
            {
                employee.Id = id;
                employee = await _repo.Delete(employee.Id);
                if (employee != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
