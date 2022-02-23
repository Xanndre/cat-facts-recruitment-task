using CatFacts.Core.Config;
using CatFacts.Core.Interfaces;
using CatFacts.Core.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFacts.Core.Services
{
    public class FactService : IFactService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FactOptions _factOptions;

        public FactService(IHttpClientFactory httpClientFactory, IOptions<FactOptions> factOptions)
        {
            _httpClientFactory = httpClientFactory;
            _factOptions = factOptions.Value;
        }

        public async Task<CatFact> GetFact()
        {
            var client = _httpClientFactory.CreateClient();
 
            var response = await client.GetAsync(_factOptions.ApiUrl);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var deserializedContent = JsonSerializer.Deserialize<CatFact>(content, options);

            using (var stream = File.AppendText(_factOptions.OutputFileName))
            {
                stream.WriteLine(deserializedContent.Fact);
            }

            return deserializedContent;
        }


    }
}
