using System.Text.Json.Serialization;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Currency
    {
        [JsonPropertyName("iso639_1")]
        public string Iso639One { get; set; }
        [JsonPropertyName("iso639_2")]
        public string Iso639Two { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        
    }
}