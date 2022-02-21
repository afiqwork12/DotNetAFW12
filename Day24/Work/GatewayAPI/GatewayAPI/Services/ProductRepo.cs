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
    public class ProductRepo : IRepo<int, ProductDTO>
    {
        private readonly HttpClient _httpClient;
        public ProductRepo()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ProductDTO> Add(ProductDTO item)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsync("http://localhost:28440/api/product/", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Delete(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:28440/api/product/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:28440/api/product/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:28440/api/product/"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Update(ProductDTO item)
        {
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:28440/api/product/", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }
    }
}
