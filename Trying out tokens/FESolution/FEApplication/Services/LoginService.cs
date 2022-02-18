using FEApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FEApplication.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<User> Register(User user)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:35638/api/users/register", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var user1 = JsonConvert.DeserializeObject<User>(responseText);
                        return user1;
                    }
                }
            }
            return null;
        }
        public async Task<User> Login(User user)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:35638/api/users/login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var user1 = JsonConvert.DeserializeObject<User>(responseText);
                        return user1;
                    }
                }
            }
            return null;
        }
    }
}
