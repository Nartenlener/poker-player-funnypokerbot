using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class GameState
    {
        public string tournament_id { get; set; }
        public string game_id { get; set; }
        public int round { get; set; }
        public int bet_index { get; set; }
        public int small_blind { get; set; }
        public int current_buy_in { get; set; }
        public int pot { get; set; }
        public int minimum_raise { get; set; }
        public int dealer { get; set; }
        public int orbits { get; set; }
        public int in_action { get; set; }
        public Player[] players { get; set; }
        public Card[] community_cards { get; set; }
    }

    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string version { get; set; }
        public int stack { get; set; }
        public int bet { get; set; }
        public Card[] hole_cards { get; set; }
    }

    public class Card
    {
        public string rank { get; set; }
        public string suit { get; set; }

        public int Rank
        {
            get
            {
                if (char.IsDigit(rank[0])) return int.Parse(rank);
                else
                {
                    if (rank == "J") return 11;
                    else if (rank == "Q") return 12;
                    else if (rank == "K") return 13;
                    else if (rank == "A") return 14;
                }
                return 0;
            }
        }

        public bool GreaterThan(Card a)
        {
            return this.Rank > a.Rank;
        }

        public bool EqualTo(Card a)
        {
            return this.Rank == a.Rank;
        }
    }
}




