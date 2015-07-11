using System;
using System.Collections.Generic;
using System.Linq;

namespace Nancy.Simple
{
    public static class FlushChecker
    {
        public static bool IsItStillFlushPossible(Card[] cards)
        {
            if (cards.Count() == 0) return false;
            if (cards.Count() == 1) return true;
            if (cards.Count() < 5)
                return cards.Select(x => x.suit).Distinct().Count() == 1;
            var suitsCount = cards.GroupBy(x => x.suit).Select(x => new { x.Key, count = x.Count() });
            if (suitsCount.Any(x => x.count > 4))
                return true;
            return true;
        }
    }
}