using NUnit.Framework;
using System;
using Nancy.Simple;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

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
	}
}

