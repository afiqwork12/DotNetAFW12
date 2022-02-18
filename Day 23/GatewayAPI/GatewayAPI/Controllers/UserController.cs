using GatewayAPI.Models;
using GatewayAPI.Services;
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
    public class UserController : ControllerBase
    {
        private readonly IManageUser<UserDTO> _ManageUser;
        public UserController(IManageUser<UserDTO> ManageUser)
        {
            _ManageUser = ManageUser;
        }
        // GET: api/<UserController>
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            var myUser = await _ManageUser.Add(userDTO);
            if (myUser != null)
            {
                return Ok(myUser);
            }
            return BadRequest("Could not register user");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(UserDTO userDTO)
        {
            var myUser = await _ManageUser.Login(userDTO);
            if (myUser != null)
            {
                return Ok(userDTO);
            }
            return BadRequest("invalid user details");
        }
    }
}
