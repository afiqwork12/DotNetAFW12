using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeeServiceApp.Models;
using Newtonsoft.Json;

namespace EmployeeServiceApp.Services
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
                using (var response = await _httpClient.PostAsync("http://localhost:21252/api/user/register", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var myuser = JsonConvert.DeserializeObject<User>(responseText);
                        return myuser;
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
                using (var response = await _httpClient.PostAsync("http://localhost:21252/api/user/login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var myuser = JsonConvert.DeserializeObject<User>(responseText);
                        return myuser;
                    }
                }
            }
            return null;
        }
    }
}
