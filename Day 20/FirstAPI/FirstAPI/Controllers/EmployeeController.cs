using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _repo;
        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("SingleEmployee")]
        public Employee Get(int id)
        {
            return _repo.GetT(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post(Employee employee)
        {
            var myemployee = _repo.Add(employee);
            if (myemployee != null)
            {
                return employee;
            }
            return null;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public Employee Put(int id, Employee employee)
        {
            if (_repo.Update(employee))
            {
                return employee;
            }
            return null;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
