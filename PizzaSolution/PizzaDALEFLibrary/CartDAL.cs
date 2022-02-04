using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDALEFLibrary
{
    public class CartDAL
    {
        readonly PizzaContext _PizzaContext;
        public CartDAL()
        {
            _PizzaContext = new PizzaContext();
        }
        public void GetCart(int customerNumber)
        {
            var cartDetails = _PizzaContext.Carts.Where(c => c.CustomerNumber == customerNumber)
                .Select
                (c =>
                    new
                    {
                        CartNumber = c.CartNumber,
                        CustomerName = c.Customer.Name,
                        Pizzas = c.Pizzas
                    }
                )
                .ToList();
            //Console.WriteLine("Customers - " + _PizzaContext.Customers.ToList().Count);
            //Console.WriteLine("Pizzas - " + _PizzaContext.Pizzas.ToList().Count);
            //Console.WriteLine("Carts - " + _PizzaContext.Carts.ToList().Count);
            //Console.WriteLine("CartPizzas - " + _PizzaContext.CartPizzas.ToList().Count);
            foreach (var item in cartDetails)
            {
                Console.WriteLine("The cart number is " + item.CartNumber);
                Console.WriteLine("Hi " + item.CustomerName);
                Console.WriteLine("You ordered:");
                foreach (var piz in _PizzaContext.CartPizzas.Where(cp => cp.CartNumber == item.CartNumber).Select(cp => cp.Pizza))
                {
                    Console.WriteLine("             " + piz.Name);
                    Console.WriteLine("             " + piz.Price);
                    Console.WriteLine("             " + (piz.IsVeg ? "Vegetarian" : "Non Vegetarian"));
                }
            }
        }
    }
}
