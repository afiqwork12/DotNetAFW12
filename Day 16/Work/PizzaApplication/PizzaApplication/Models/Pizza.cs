using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaApplication.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVeg { get; set; }
        public double Price { get; set; }

        public string Pic { get; set; }
        public string Details { get; set; }
    }
}
