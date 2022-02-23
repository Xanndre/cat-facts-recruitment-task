using CatFacts.Core.Interfaces;
using CatFacts.Core.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFacts.Core.Services
{
    public class FactService : IFactService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FactService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CatFact> GetFact()
        {
            var client = _httpClientFactory.CreateClient();
 
            var response = await client.GetAsync("https://catfact.ninja/fact");
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var deserializedContent = JsonSerializer.Deserialize<CatFact>(content, options);

            using (var stream = File.AppendText("catfacts.txt"))
            {
                stream.WriteLine(deserializedContent.Fact);
            }

            return deserializedContent;
        }


    }
}
