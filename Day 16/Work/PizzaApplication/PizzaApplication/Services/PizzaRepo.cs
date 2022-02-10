using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class PizzaRepo : IRepo<int, Pizza>
    {
        static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name ="ABC",
                IsVeg = true,
                Price = 12.4,
                Pic = "/images/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-8f256746d649404baa36a44d271329bc.jpg",
                Details = "Pepe"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/53110049.gif",
                Details = "pizzzzzzzzzza"
            }
        };
        public bool Add(Pizza t)
        {
            Pizzas.Add(t);
            return true;
        }

        public bool Delete(int k)
        {
            try
            {
                var pizzaIndex = Pizzas.IndexOf(Pizzas.SingleOrDefault(p => p.Id == k));
                Pizzas.RemoveAt(pizzaIndex);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public Pizza GetT(int k)
        {
            var pizza = Pizzas.SingleOrDefault(p => p.Id == k);
            return pizza;
        }

        public ICollection<Pizza> GetAll()
        {
            return Pizzas;
        }

        public bool Update(int k, Pizza t)
        {
            var pizzaIndex = Pizzas.IndexOf(Pizzas.SingleOrDefault(p => p.Id == k));
            Pizzas[pizzaIndex] = t;
            return true;
        }
    }
}
