using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntese.DAL.ApiServices
{
    internal class HypixelApiService
    {
        private readonly HttpClient _httpClient;
        public HypixelApiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetSkyblockProfile(string apiKey, string uuid)
        {
            string apiUrl = $"https://api.hypixel.net/skyblock/profiles?key={apiKey}&uuid={uuid}";

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
