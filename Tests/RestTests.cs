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
			var client = new RestClient("http://localhost:8080");
			// client.Authenticator = new HttpBasicAuthenticator(username, password);

			var request = new RestRequest("/", Method.GET);

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string
			Assert.AreEqual(content,"OK");
		}
	}
}

