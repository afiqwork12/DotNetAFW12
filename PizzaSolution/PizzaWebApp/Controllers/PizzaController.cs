using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDALEFLibrary;
using PizzaWebApp.Models;

namespace PizzaWebApp.Controllers
{
    public class PizzaController : Controller
    {
        List<FEPizza> fEPizzas = new List<FEPizza>();
        
        public IActionResult Index()
        {
            fEPizzas.Add(new FEPizza() { Id = 1, Name = "Pepe", IsVeg = false, Price = 33.3 });
            fEPizzas.Add(new FEPizza() { Id = 2, Name = "Pepe", IsVeg = false, Price = 33.3 });
            fEPizzas.Add(new FEPizza() { Id = 3, Name = "Pepe", IsVeg = false, Price = 33.3 });
            //var pizzas = new PizzaDAL().GetAllPizza();
            return View(fEPizzas);
        }
    }
}
