using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum Status
    {
        Lose, Win
    }

    public abstract class Game
    {
        protected int gameId;
        protected Dictionary<String, Status> players;
        protected double rating;
        protected static int gamesCount;

        public Game(double rating)
        {
            if (rating < 0) throw new ArgumentOutOfRangeException();
            this.players = new Dictionary<String, Status>();
            this.gameId = gamesCount;
            this.rating = rating;   
            gamesCount++;
        }

        public int GameId { get { return gameId; } }

        public double Rating { get { return rating; } }

        public Dictionary<String, Status> Players
        {
            get { return players; }

        }

        internal void RegisterPlayers(GameAccount winner, GameAccount loser)
        {
            players.Add(winner.UserName, Status.Win);
            players.Add(loser.UserName, Status.Lose);
        }

        private String PlayersToString()
        {
            String output = "";
            foreach(KeyValuePair<String, Status> pair in players)
            {
                output += String.Format("name: {0}, game status: {1}; ", pair.Key, pair.Value);
            }
            return output;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Game("); 
            sb.Append("id: ").Append(gameId.ToString()).Append(", ");
            sb.Append("rating (bet): ").Append(rating.ToString()).Append(", ");
            sb.Append("players: [").Append(PlayersToString()).Append("]");
            
            return sb.ToString();
        }
    }
}