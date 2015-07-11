using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Version 2";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet
		    GameState gs = GetGameStateFromJObject(gameState);
			StartingHands sh = new StartingHands();
		    Card[] cards = gs.players[gs.in_action].hole_cards.Take(2).ToArray();
            Tuple<Card,Card> firstHand = new Tuple<Card, Card>(cards[0],cards[1]);

		    if (sh.RankHand(firstHand) == StaringHandsRank.Strong) return GetCallAmount(gs);
             
			return 0;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}

		public static GameState GetGameStateFromJObject(JObject gameState){
			return gameState.ToObject<GameState> ();
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

