using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APITests
{
    public class Tasks
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("keyword")]
        public string keyword { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("boardName")]
        public string boardName { get; set; }

    }
}
