using System.Linq;

namespace Nancy.Simple
{
    public static class FlushChecker
    {
        public static bool IsItStillFlushPossible(Card[] cards)
        {
            if (cards.Count() == 0) return false;
            if (cards.Count() == 1) return true;
            var suit = cards[0].suit;
            foreach (var card in cards.Skip(1))
            {
                if (card.suit != suit)
                    return false;
            }
            return true;
        }
    }
}