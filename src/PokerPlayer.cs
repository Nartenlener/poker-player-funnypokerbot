﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Version 1";

		public static int BetRequest(JObject gameState)
		{
			//TODO: Use this method to return the value You want to bet

			return 0;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}

		public static GameState GetGameStateFromJObject(JObject gameState){
			return gameState.ToObject<GameState> ();
		}
	}
}

