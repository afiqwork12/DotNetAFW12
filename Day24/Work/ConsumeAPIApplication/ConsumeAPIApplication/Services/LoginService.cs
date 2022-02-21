using ConsumeAPIApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPIApplication.Services
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
                using (var response = await _httpClient.PostAsync("http://localhost:5586/api/user/register", content))
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
                using (var response = await _httpClient.PostAsync("http://localhost:5586/api/user/login", content))
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
