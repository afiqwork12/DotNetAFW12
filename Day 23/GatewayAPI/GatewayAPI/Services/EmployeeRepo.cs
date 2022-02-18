using GatewayAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public class EmployeeRepo : IRepo<int, Employee>
    {
        private readonly HttpClient _httpClient;
        public EmployeeRepo()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Employee> Add(Employee t)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:38713/api/Employee", content))
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
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:38713/api/Employee?id=" + k))
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
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:38713/api/Employee"))
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
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:38713/api/Employee/SingleEmployee?id=" + k))
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
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:38713/api/Employee?id=" + t.Id, content))
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
