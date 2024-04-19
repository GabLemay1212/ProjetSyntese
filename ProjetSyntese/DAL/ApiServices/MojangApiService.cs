using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntese.DAL.ApiServices
{
    internal class MojangApiService
    {
        private readonly HttpClient _httpClient;
        public MojangApiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetUUIDFromName(string Name)
        {
            string apiUrl = $"https://api.mojang.com/users/profiles/minecraft/{Name}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
    }
}
