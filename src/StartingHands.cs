using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
	public enum StaringHandsRank { Strong, Mid, Late, Fold }
	public class StartingHands
	{

		public String[] strongPair = new String[] {"AA", "KK", "QQ", "JJ", "1010", "99", "88", "77", "AK", "AQ", "AJ", "A10", "KQ", "KJ", "K10", "J10", "J9", "109"};

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
			else
				return StaringHandsRank.Fold;
		}
	}
}
