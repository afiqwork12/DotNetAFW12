﻿using GatewayAPI.Models;
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
    public class ProductController : ControllerBase
    {
        private readonly IRepo<int, ProductDTO> _repo;

        public ProductController(IRepo<int, ProductDTO> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var products = await _repo.Get(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            var prod = await _repo.Add(product);
            return Ok(prod);
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO product)
        {
            var prod = await _repo.Update(product);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet(int id)
        {
            var prod = await _repo.Delete(id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }
    }
}
