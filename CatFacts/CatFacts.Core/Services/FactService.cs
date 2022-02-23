using CatFacts.Core.Config;
using CatFacts.Core.Interfaces;
using CatFacts.Core.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatFacts.Core.Services
{
    public class FactService : IFactService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;
        private readonly FactOptions _factOptions;

        public FactService(IHttpClientFactory httpClientFactory, IFileService fileService, IOptions<FactOptions> factOptions)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
            _factOptions = factOptions.Value;
        }

        public async Task SaveFact()
        {
            var client = _httpClientFactory.CreateClient();
 
            var response = await client.GetAsync(_factOptions.ApiUrl);
            var content = await response.Content.ReadAsStringAsync();

            var deserializedContent = JsonSerializer.Deserialize<CatFact>(content);

            _fileService.SaveToFile(_factOptions.OutputFileName, deserializedContent.Fact);
        
        }


    }
}
