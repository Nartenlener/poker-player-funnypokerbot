using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
	public enum StaringHandsRank { Strong, Mid, Late, Fold }
	public class StartingHands
	{

		public String[] strongPair = new String[] {"AA", "KK", "QQ", "JJ", "1010", "99", "88", "77", "AK", "AQ", "AJ", "A10", "KQ", "KJ", "K10", "QJ", "Q10", "J10", "J9", "109"};
		public String[] midPair = new String[] {"66", "55", "A9", "A8", "A7", "A6", "K9", "Q9", "Q8", "J8", "108", "98"};
		public String[] latePair = new String[] {"44", "33", "22", "A5", "A4", "A3", "A2", "K8", "K7", "K6", "K5", "K4", "K3", "K2", "J7", "107", "97", "96", "87", "86", "76", "75", "65", "54"};

		public StaringHandsRank RankHand(Tuple<Card,Card> inCard)
		{
			if (inCard.Item2.GreaterThan (inCard.Item1))
				inCard = new Tuple<Card, Card> (inCard.Item2, inCard.Item1);
			
			if(inCard.Item1.rank == inCard.Item2.rank)
				return StaringHandsRank.Strong;
			return HandRank (inCard);
		}

		public StaringHandsRank HandRank(Tuple<Card,Card> inCard)
		{
			string conf = inCard.Item1.rank + inCard.Item2.rank;

			if (strongPair.Contains (conf))
				return StaringHandsRank.Strong;
			if (midPair.Contains (conf))
				return StaringHandsRank.Mid;
			if (latePair.Contains (conf))
				return StaringHandsRank.Late;
			else
				return StaringHandsRank.Fold;
		}
	}
}
