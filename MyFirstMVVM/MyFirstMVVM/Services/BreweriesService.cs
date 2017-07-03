using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MyFirstMVVM.Models;
using Newtonsoft.Json;

namespace MyFirstMVVM.Services
{
    public class BreweriesService : IBreweriesService
    {
        private string _baseUri;
        private const string _key = "70b9ca7e2d64b77ba8df276db9d26a39";

        public BreweriesService()
        {
            _baseUri = $"https://api.brewerydb.com/v2/breweries?key={_key}";
        }

        public async Task<Result<BreweryDTO>> GetBreweriesAsync(int established = 2017, int page = 1)
        {
            var endpoint = $"{_baseUri}&established={established}&p={page}&format=json";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(endpoint);
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{ex.Message}");
                }

                var content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<Result<BreweryDTO>>(content));
            }
        }
    }
}