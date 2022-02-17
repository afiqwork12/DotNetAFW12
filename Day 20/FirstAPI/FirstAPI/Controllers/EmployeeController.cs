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
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = _repo.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            return BadRequest("No employees found");
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("SingleEmployee")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _repo.GetT(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var myemployee = _repo.Add(employee);
            if (myemployee != null)
            {
                return Created("Created", employee);
            }
            return BadRequest("Unable to create");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public ActionResult<Employee> Put(int id, Employee employee)
        {
            employee = _repo.Update(employee);
            if (employee != null)
            {
                return Created("Updated", employee);
            }
            return NotFound();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        public ActionResult<Employee> Delete(int id)
        {
            var employee = _repo.Delete(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }
    }
}
