using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IRepo<int, Pizza> _repo;
        public PizzaController(IRepo<int, Pizza> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var pizza = _repo.GetAll();
            return View(pizza);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Pizza());
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            if (_repo.Add(pizza))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Details(int id)
        {
            var pizza = _repo.GetT(id);
            return View(pizza);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = _repo.GetT(id);
            return View(pizza);
        }
        [HttpPost]
        public IActionResult Edit(Pizza pizza)
        {
            if (_repo.Update(pizza))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pizza = _repo.GetT(id);
            return View(pizza);
        }
        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            if (_repo.Delete(pizza.Id))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
