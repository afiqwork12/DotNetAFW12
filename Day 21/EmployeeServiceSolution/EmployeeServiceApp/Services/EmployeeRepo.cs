using EmployeeServiceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceApp.Services
{
    public class EmployeeRepo : IRepo<int, Employee>
    {
        private readonly HttpClient _httpClient;
        private string _token;
        public EmployeeRepo()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("http://localhost:38713/api/Employee");
        }
        public void GetToken(string token)
        {
            _token = token; 
        }
        public async Task<Employee> AddAsync(Employee t)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using(var response = await _httpClient.PostAsync("http://localhost:21252/api/Employee", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> Delete(int k)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:21252/api/Employee?id=" + k))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:21252/api/Employee"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> GetT(int k)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:21252/api/Employee/SingleEmployee?id=" + k))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> Update(Employee t)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:21252/api/Employee?id=" + t.Id, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }
    }
}
