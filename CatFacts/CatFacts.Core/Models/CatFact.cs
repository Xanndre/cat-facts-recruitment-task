using System.Text.Json.Serialization;

namespace CatFacts.Core.Models
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; }
    }
}