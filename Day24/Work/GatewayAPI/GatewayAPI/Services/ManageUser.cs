using GatewayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public class ManageUser : IManageUser<UserDTO>
    {
        private readonly IGenerateToken<UserDTO> _token;
        private List<User> users;
        public ManageUser(IGenerateToken<UserDTO> token)
        {
            _token = token;
            var user = new UserDTO() { Username = "aaaaa", Password = "bbbbb" };
            users = new List<User>();
            Add(user);
        }
        public async Task<UserDTO> Add(UserDTO user)
        {
            using var hmac = new HMACSHA512();
            var user1 = new User()
            {
                Username = user.Username,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordHash = hmac.Key
            };
            users.Add(user1);
            user.Password = "";
            return new UserDTO() { Username = user.Username, Token = _token.CreateToken(user) };
        }

        public async Task<UserDTO> Login(UserDTO user)
        {
            var myUser = users.SingleOrDefault(u => u.Username == user.Username);
            //var myUser = await _context.Users.FindAsync(user.Username);
            if (myUser == null)
                return null;
            using var hmac = new HMACSHA512(myUser.PasswordHash);
            var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            for (int i = 0; i < userPass.Length; i++)
            {
                if (userPass[i] != myUser.Password[i])
                    return null;
            }
            user.Password = "";
            return new UserDTO() { Username = user.Username, Token = _token.CreateToken(user) };
        }
    }
}
