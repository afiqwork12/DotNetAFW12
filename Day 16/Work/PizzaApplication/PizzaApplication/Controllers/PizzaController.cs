using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name ="ABC",
                IsVeg = true,
                Price = 12.4
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7
            }
        };
        public IActionResult Index()
        {
            var pizza = Pizzas;
            return View(pizza);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Pizza());
        }
        [HttpPost]
        //public IActionResult Create(IFormCollection keyValues)
        //{
        //    Pizza pizza = new Pizza();
        //    pizza.Id = Convert.ToInt32(keyValues["numID"].ToString());
        //    pizza.Name = keyValues["txtName"].ToString();
        //    pizza.Price = Convert.ToDouble(keyValues["numPrice"].ToString());
        //    pizza.IsVeg = false;
        //    Pizzas.Add(pizza);
        //    //pizza.IsVeg = keyValues["chkIsVeg"].checked;
        //    //return pizza.Id + " " + pizza.Name + " " + pizza.Price;
        //    return RedirectToAction("Index");
        //}
        public IActionResult Create(Pizza pizza)
        {
            Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }
    }
}
