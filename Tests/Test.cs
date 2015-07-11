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

        [Test()]
        public void TestCardRank10()
        {
            Card c = new Card() { rank = "10", suit = "spades" };
            Assert.AreEqual(c.Rank,10);
        }

        [Test()]
        public void TestCardRankJ()
        {
            Card c = new Card() { rank = "J", suit = "spades" };
            Assert.AreEqual(c.Rank, 11);
        }

        [Test()]
        public void TestCardRank2()
        {
            Card c = new Card() { rank = "2", suit = "spades" };
            Assert.AreEqual(c.Rank, 2);
        }
	}
}

