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
    public class CustomerRepo : IRepo<int, Customer>
    {
        private readonly HttpClient _httpClient;

        public CustomerRepo()
        {
            _httpClient = new HttpClient();

        }
        public async Task<Customer> Add(Customer item)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:53134/api/customers", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }
            }
            return null;
        }

        public async Task<Customer> Delete(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:53134/api/customers/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }
            }
            return null;
        }

        public async Task<Customer> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:53134/api/customers/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:53134/api/customers"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<Customer>>(responseText);
                        return customers.ToList();
                    }
                }
            }
            return null;
        }

        public async Task<Customer> Update(Customer item)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:53134/api/customers/" + item.Id, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(responseText);
                        return customer;
                    }
                }
            }
            return null;
        }


    }
}
