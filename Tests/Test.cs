using NUnit.Framework;
using System;
using Nancy.Simple;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			Assert.AreEqual (PokerPlayer.BetRequest (new JObject ()), 0);
		}
	}
}

