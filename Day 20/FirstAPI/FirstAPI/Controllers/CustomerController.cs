using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]//attribute based routing
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Name = "Tim",
                Age = 23
            },
            new Customer()
            {
                Id = 2,
                Name = "Jim",
                Age = 33
            },
            new Customer()
            {
                Id = 3,
                Name = "Lim",
                Age = 29
            }
        };
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }
        [HttpPost]
        public Customer Post(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }
        //[HttpPost]
        //public IEnumerable<Customer> PostMultiple(IEnumerable<Customer> customers)
        //{
        //    foreach (var customer in customers)
        //    {
        //        _customers.Add(customer);
        //    }
        //    return customers;
        //}
    }
}
