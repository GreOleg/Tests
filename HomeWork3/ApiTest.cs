using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using HomeWork3.Models;
using NUnit.Framework;
using RestSharp;

namespace HomeWork3
{   
    public class ApiTest
    {
        const string BaseUrl = "https://petstore.swagger.io/v2/pet/";
        private RestClient _restClient;

        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient(BaseUrl);
        }
        [Test]
        [TestCase (Status.Available)]
        [TestCase (Status.Pending)]
        [TestCase (Status.Sold)]
        public void GetPets_ValidStatusGiven_PetsReturned(Status status)
        {   
            //Arrange
            var petStatus = status.ToString().ToLower();            
            var restRequest = new RestRequest($"findByStatus?status={petStatus}", Method.GET);
            restRequest.AddHeader("Accept", "application/json");

            //Act
            var restResponse = _restClient.Get(restRequest);
            var petsList = JsonSerializer.Deserialize<List<Pet>>(restResponse.Content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Assert.IsNotEmpty(petsList);
        }
    }
}