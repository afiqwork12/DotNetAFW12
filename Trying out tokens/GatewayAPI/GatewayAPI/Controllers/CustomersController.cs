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
    public class CustomersController : ControllerBase
    {
        private readonly IRepo<int, Customer> _repo;
        public CustomersController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _repo.GetAll();
            if (customers != null)
            {
                return Ok(customers.ToList());
            }
            return BadRequest("No Customers Found");
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _repo.Get(id);
            if (customer == null)
                return BadRequest("No such Customer");
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            var cust = await _repo.Add(customer);
            if (cust == null)
                return NotFound();
            return Created("CUstomer created", customer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer customer)
        {
            var cust = await _repo.Update(customer);
            if (cust == null)
                return NotFound();
            return Ok(customer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var cust = await _repo.Delete(id);
            if (cust == null)
                return NotFound();
            return Ok(cust);
        }
    }
}
