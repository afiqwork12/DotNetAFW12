using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Chai", 
                Price = 18.00,
                SupplierId = 1,
                Quantity = 39,
                Remarks = "Finest Chai"
            },
            new Product()
            {
                Id = 2,
                Name = "Chang",
                Price = 19.00,
                SupplierId = 1,
                Quantity = 17,
                Remarks = "Great Beer"
            }
        };
        public IActionResult Index()
        {
            var products = Products;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Products.Add(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Product product)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var productIndex = Products.IndexOf(Products.SingleOrDefault(p => p.Id == id));
                Products[productIndex] = product;
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Products.SingleOrDefault(p => p.Id == id);
            Products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
