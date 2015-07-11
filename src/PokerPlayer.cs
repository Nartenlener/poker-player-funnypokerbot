using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "$$$$$MONEY_AND_SWEETS$$$";

        public static int BetRequest(JObject gameState)
        {
            try
            {
                //TODO: Use this method to return the value You want to bet
                GameState gs = GetGameStateFromJObject(gameState);
                StartingHands sh = new StartingHands();
                Card[] cards = gs.players[gs.in_action].hole_cards.ToArray();
                Tuple<Card, Card> firstHand = new Tuple<Card, Card>(cards[0], cards[1]);

                if (gs.community_cards.Length == 0)
                {
                    switch (sh.HandRank2Cards(firstHand))
                    {
                        case HandsRank.Call:
                            return GetCallAmount(gs);
                        case HandsRank.Fold:
                            return 0;
                        case HandsRank.Raise:
                            return GetRaiseAmount(gs);
                        case HandsRank.AllIn:
                            return GetAllInAmount(gs);
                    }
                }
                else
                {
                    List<Card> allCards = new List<Card>();
                    allCards.AddRange(gs.players[gs.in_action].hole_cards);
                    allCards.AddRange(gs.community_cards);

                    switch (sh.HandRankMoreCards(allCards))
                    {
                        case HandsRank.Call:
                            return GetCallAmount(gs);

                        case HandsRank.AllIn:
                            return GetAllInAmount(gs);

                        case HandsRank.Raise:
                            return GetRaiseAmount(gs);
                        case HandsRank.Fold:
                            return 0;

                    }
                }

            }
            catch (Exception e)
            {
               
            }
            return 0;
        }

        private static int GetRaiseAmount(GameState gameState)
        {
            return gameState.current_buy_in - gameState.players[gameState.in_action].bet + gameState.minimum_raise;
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }

        public static GameState GetGameStateFromJObject(JObject gameState)
        {
            return gameState.ToObject<GameState>();
        }

        public static int GetCallAmount(GameState gameState)
        {
            return gameState.current_buy_in - gameState.players[gameState.in_action].bet;
        }

        public static int GetAllInAmount(GameState gameState)
        {
            return gameState.players[gameState.in_action].stack;
        }

    }
}

