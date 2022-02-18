using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomersAPI.Models;

namespace CustomersAPI.Services
{
    public class CustomerEFRepo : IRepo<int, Customer>
    {
        private readonly CustomerContext _context;
        public CustomerEFRepo(CustomerContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            if (SaveChanges())
            {
                return item;
            }
            return null;
        }

        public Customer Delete(int key)
        {
            var customer = GetT(key);
            if (customer != null)
            {
                _context.Customers.Add(GetT(key));
                if (SaveChanges())
                {
                    return customer;
                }
            }
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetT(int key)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == key);
        }

        public Customer Update(Customer item)
        {
            _context.Customers.Update(item);
            if (SaveChanges())
            {
                return item;
            }
            return null;
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
