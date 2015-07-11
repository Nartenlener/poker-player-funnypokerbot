using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Version 2a";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet
			return 0;
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

