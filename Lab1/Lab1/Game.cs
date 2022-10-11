using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum Status
    {
        Lose, Win
    }

    public class Game
    {
        private int gameId;
        private Status status;
        private int rating;
        private string opponentName;
        public static int gamesCount;

        public Game(Status status, int rating, string opponentName)
        {
            this.gameId = gamesCount;
            this.status = status;
            this.rating = rating;   
            this.opponentName = opponentName;
            gamesCount = gameId++;
        }

        public Game(int gameId, Status status, int rating, string opponentName)
        {
            this.gameId = gameId;
            this.status = status;
            this.rating = rating;
            this.opponentName = opponentName;
            gamesCount = gameId++;
        }

        public int GameId { get { return gameId; } }

        public Status Status { get { return status; } }

        public string OpponentName { get { return opponentName; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Game("); 
            sb.Append("id: ").Append(gameId.ToString()).Append(", ");
            sb.Append("status: ").Append(status.ToString()).Append(", ");
            sb.Append("rating: ").Append(rating.ToString()).Append(", ");
            sb.Append("opponent name: ").Append(opponentName.ToString()).Append(")");
            
            return sb.ToString();
        }
    }
}
