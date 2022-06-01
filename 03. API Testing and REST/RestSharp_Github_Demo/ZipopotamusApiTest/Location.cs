using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZipopotamusApiTest
{
    internal class Location
    {
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }

        public class Place
        {
            public string PlaceName { get; set; }
        }
    }
}