using NUnit.Framework;
using System;
using Nancy.Simple;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace Tests
{
	[TestFixture ()]
	public class RestTests
	{		
		[Test ()]
		public void ShouldBeAlive() {
			var client = new RestClient(App.STAGINGHOST);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);

			var request = new RestRequest("/", Method.GET);

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string
			Assert.AreEqual(content,"OK");
		}

        [Test()]
        public void ShouldReturnVersion()
        {
			var client = new RestClient(App.STAGINGHOST);
            
            var request = new RestRequest("/", Method.POST);
			request.AddParameter("action", "version");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
			Assert.AreEqual(content, PokerPlayer.VERSION);
        }

		[Test()]
		public void ShouldReturnResponseToCheck()
		{
			var client = new RestClient(App.STAGINGHOST);

			var request = new RestRequest("/", Method.POST);
			request.AddParameter("action", "check");

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string
			Assert.AreEqual(content, "OK");
		}

        [Test()]
        public void ShouldReturnResponseToBetRequest()
        {
            var client = new RestClient(App.STAGINGHOST);

            var request = new RestRequest("/", Method.POST);
            request.AddParameter("action", "bet_request");
            request.AddParameter("game_state", @"{
  'players':[
    {
      'name':'Player 1',
      'stack':1000,
      'status':'active',
      'bet':0,
      'hole_cards':[],
      'version':'Version name 1',
      'id':0
    },
    {
      'name':'Player 2',
      'stack':1000,
      'status':'active',
      'bet':0,
      'hole_cards':[],
      'version':'Version name 2',
      'id':1
    }
  ],
  'small_blind':10,
  'orbits':0,
  'dealer':0,
  'community_cards':[],
  'current_buy_in':0,
  'pot':0
}");
            

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
            int val;
            Assert.IsTrue(int.TryParse(content, out val));
        }

		[Test()]
		public void ShouldReturnResponseToShowDown()
		{
			var client = new RestClient(App.STAGINGHOST);

			var request = new RestRequest("/", Method.POST);
            request.AddParameter("action", "showdown");
			request.AddParameter("game_state", @"{
  'players':[
    {
      'name':'Player 1',
      'stack':1000,
      'status':'active',
      'bet':0,
      'hole_cards':[],
      'version':'Version name 1',
      'id':0
    },
    {
      'name':'Player 2',
      'stack':1000,
      'status':'active',
      'bet':0,
      'hole_cards':[],
      'version':'Version name 2',
      'id':1
    }
  ],
  'small_blind':10,
  'orbits':0,
  'dealer':0,
  'community_cards':[],
  'current_buy_in':0,
  'pot':0
}");


			// execute the request
			IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
		}
	}
}

