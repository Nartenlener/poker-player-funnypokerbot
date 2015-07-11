using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public enum StaringHandsRank { Strong, Mid, Late, Fold }
    public class StartingHands
    {

        public StaringHandsRank RankHand(Tuple<Card,Card> inCard)
        {
            if(inCard.Item1.rank == inCard.Item2.rank)
                return StaringHandsRank.Strong;
            return StaringHandsRank.Fold;
        }
    }
}
