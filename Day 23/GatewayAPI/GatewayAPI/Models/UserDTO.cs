using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Models
{
    public class UserDTO
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
