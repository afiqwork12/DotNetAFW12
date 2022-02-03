using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDALEFLibrary
{
    public class PizzaDAL
    {
        readonly PizzaContext _PizzaContext;
        public PizzaDAL()
        {
            _PizzaContext = new PizzaContext();
        }
        /// <summary>
        /// Gets all the records from the table in the Pizza Database
        /// </summary>
        /// <returns>
        /// ICollection&lt;Pizza&lt;
        /// </returns>
        public ICollection<Pizza> GetAllPizza()
        {
            List<Pizza> pizzas = _PizzaContext.Pizzas.ToList();
            if (pizzas.Count == 0)
            {
                throw new NoPizzaException();
            }
            return pizzas;
        }
        public bool InsertNewPizza(Pizza pizza)
        {
            _PizzaContext.Pizzas.Add(pizza);
            _PizzaContext.SaveChanges();
            return true;
        }
        public bool UpdatePizzaPrice(int id, double price)
        {
            Pizza pizza = _PizzaContext.Pizzas.SingleOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return false;
            }
            else
            {
                pizza.Price = price;
                _PizzaContext.SaveChanges();
                return true;
            }
        }
        public bool RemovePizza(int id)
        {
            Pizza pizza = _PizzaContext.Pizzas.SingleOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return false;
            }
            else
            {
                _PizzaContext.Pizzas.Remove(pizza);
                _PizzaContext.SaveChanges();
                return true;
            }
        }

    }
}
