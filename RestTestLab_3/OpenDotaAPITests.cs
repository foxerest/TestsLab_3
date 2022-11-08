using RestSharp;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using RestSharp.Authenticators;

namespace RestTestLab_3
{
    public class TestOpenDotaAPITests
    {
        RestClient client;
        string steamID = "360217981";
        string matchId = "6851860411";

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.opendota.com/api/");
        }

        [Test]
        public void CheckSeccessfullResponse_WhenGetRequestWithMatchId()
        {
            // arrange
            RestRequest request = new RestRequest("players/" + steamID + "/counts", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CheckSeccessfullResponse_WhenExecutePlayerRefreshPostRequest()
        {
            // arrange
            RestRequest request = new RestRequest("request/" + matchId, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

    }
}