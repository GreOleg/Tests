﻿using System.Text.Json.Serialization;

namespace HomeWork3.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}