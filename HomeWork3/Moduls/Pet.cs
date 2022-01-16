using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeWork3.Models
{
    public class Pet
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("photoUrls")]
        public List<string> photoUrls  { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag> Tag { get; set; }
    }
}