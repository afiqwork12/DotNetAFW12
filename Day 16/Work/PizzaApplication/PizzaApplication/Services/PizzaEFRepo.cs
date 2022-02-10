using PizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class PizzaEFRepo : IRepo<int, Pizza>
    {
        private readonly PizzaShopContext _context;
        public PizzaEFRepo(PizzaShopContext context)
        {
            _context = context;
        }
        public bool Add(Pizza t)
        {
            _context.Pizzas.Add(t);
            return SaveChanges();
        }

        private bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int k)
        {
            _context.Pizzas.Remove(GetT(k));
            return SaveChanges();
        }

        public ICollection<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetT(int k)
        {
            return _context.Pizzas.SingleOrDefault(p => p.Id == k);
        }

        public bool Update(Pizza t)
        {
            _context.Pizzas.Update(t);
            return SaveChanges();
        }
    }
}
