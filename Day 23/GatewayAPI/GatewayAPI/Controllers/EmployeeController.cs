using GatewayAPI.Models;
using GatewayAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _repo;
        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _repo.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            return NotFound();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employee = await _repo.GetT(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post(Employee employee)
        {
            try
            {
                employee = await _repo.Add(employee);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return BadRequest("Cannot add Employee");
            }
            catch
            {
                return BadRequest("Cannot add Employee");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Employee employee)
        {
            try
            {
                employee = await _repo.Update(employee);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return BadRequest("Cannot update Employee");
            }
            catch
            {
                return BadRequest("Cannot update Employee");
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var employee = await _repo.Delete(id);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return BadRequest("Cannot delete Employee");
            }
            catch
            {
                return BadRequest("Cannot delete Employee");
            }
        }
    }
}
