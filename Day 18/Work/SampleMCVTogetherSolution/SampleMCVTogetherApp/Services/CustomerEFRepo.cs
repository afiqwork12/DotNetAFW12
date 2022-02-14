using SampleMCVTogetherApp.Exceptions;
using SampleMCVTogetherApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Services
{
    public class CustomerEFRepo : IRepo<int, Customer>
    {
        private readonly ShopContext _context;
        public CustomerEFRepo(ShopContext context)
        {
            _context = context;
        }
        public Customer Add(Customer t)
        {
            try
            {
                _context.Customers.Add(t);
                if (SaveChanges())
                {
                    return t;
                }
                return null;
            }
            catch (Exception e)
            {
                if ((e.InnerException as SqlException).Number == 2601)
                {
                    throw new UsernameDuplicateException();
                }
                return null;
            }
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
