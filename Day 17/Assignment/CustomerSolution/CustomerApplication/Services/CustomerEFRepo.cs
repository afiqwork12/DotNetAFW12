using CustomerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Services
{
    public class CustomerEFRepo : IRepo<int, Customer>
    {
        private readonly CustomerApplicationContext _context;
        public CustomerEFRepo(CustomerApplicationContext context)
        {
            _context = context;
        }
        public bool Add(Customer t)
        {
            _context.Customers.Add(t);
            return SaveChanges();
        }

        public bool Delete(int k)
        {
            _context.Customers.Remove(GetT(k));
            return SaveChanges();
        }

        public ICollection<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetT(int k)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == k);
        }

        public bool Update(Customer t)
        {
            _context.Customers.Update(t);
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
    }
}
