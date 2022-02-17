using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class EmployeeEFRepo : IRepo<int, Employee>
    {
        private readonly APIContext _context;
        public EmployeeEFRepo(APIContext context)
        {
            _context = context;
        }

        public Employee Add(Employee t)
        {
            _context.Employees.Add(t);
            if (SaveChanges())
            {
                return t;
            }
            return null;
        }

        public Employee Delete(int k)
        {
            var employee = GetT(k);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                if (SaveChanges())
                {
                    return employee;
                }
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetT(int k)
        {
            return _context.Employees.SingleOrDefault(e => e.Id == k);
        }

        public Employee Update(Employee t)
        {
            _context.Employees.Update(t);
            if (SaveChanges())
            {
                return t;
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
