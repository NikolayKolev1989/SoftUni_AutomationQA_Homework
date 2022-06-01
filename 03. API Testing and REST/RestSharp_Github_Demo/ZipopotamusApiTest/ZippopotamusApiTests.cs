using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZipopotamusApiTest
{
    public class ZippopotamusApiTests
    {

        [Test]
        [TestCase("BG", "1000", "Sofija")]
        [TestCase("BG", "8600", "Jambol")]
        [TestCase("CA", "M5S", "Toronto")]
        [TestCase("GB", "B1", "Birmingham")]
        [TestCase("DE", "01067", "Dresden")]
        public async Task TestZippopotamus(
            string countryCode, string zipCode, string expectedPlace)
        {
            // Arrange
            var client = new RestClient("https://api.zippopotam.us");
            var request = new RestRequest(countryCode + "/" + zipCode);

            // Act
            var response = await client.ExecuteAsync(request, Method.Get);
            //var location = JsonSerializer.Deserialize<Location>(response);
            var location = new SystemTextJsonSerializer().Deserialize<Location>(response);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(countryCode, location.CountryAbbreviation);
            Assert.AreEqual(zipCode, location.PostCode);
            StringAssert.Contains(expectedPlace, location.Places[0].PlaceName);
            
        }
    }
}