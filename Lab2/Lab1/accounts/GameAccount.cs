using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2

{
    public abstract class GameAccount
    {
        protected string userName;
        protected double currentRating;
        protected int gamesCount;
        protected List<Game> games;

        public GameAccount(string userName, int currentRating=100) 
        {
            this.userName = userName;
            this.currentRating = currentRating;
            this.games = new List<Game>();
        }

        public string UserName
        {
            get { return userName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullReferenceException("Name Cannot Be Null Or Empty");
                userName = value;
                    
            }
        }

        public double CurrentRating
        {
            get { return currentRating; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Rating Cannot Be Less Than 0");
                currentRating = value; 
            }
        }

        public int GamesCount { get { return gamesCount; } }

        public List<Game> Games { get { return games; } }

        protected abstract void AddRating(double rating);

        protected abstract void SubtractRating(double rating);

        private void addGameToList(Game game)
        {
            games.Add(game);
        }

        public void WinGame(GameAccount opponent, Game game)
        {
            int rating = game.Rating;

            // handle possible edge cases
            if (opponent == null)
                throw new ArgumentNullException("Opponent Cannot Be Null");
            else if (opponent == this)
                throw new ArgumentException("You Cannot Play With Yourself");
            if (rating < 0)
                throw new ArgumentOutOfRangeException("Rating Cannot Be Less Than 0");
            else if (this.currentRating <= rating || opponent.currentRating <= rating)
                throw new ArgumentOutOfRangeException("All Players Must Have More Than " + rating + " Rating");

            // register users (add them to the game)
            game.RegisterPlayers(this, opponent);

            // increment player's total amount of games played
            // & add bet to the player's rating & add game for the current player 
            this.gamesCount++;
            this.AddRating(rating);
            this.addGameToList(game);

            // do the same thing for the opponent, except subtract bet from opponent's current rating
            opponent.gamesCount++;
            opponent.SubtractRating(rating);
            opponent.addGameToList(game);
        }

        public void LoseGame(GameAccount opponent, Game game)
        {
            opponent.WinGame(this, game);
        }

        public void GetStats()
        {
            Console.WriteLine(userName + " stats:");
            Console.WriteLine("gamesCount: " + gamesCount + ", current rating: " + currentRating);
            foreach (Game game in games)
            {
                Console.WriteLine(game);
            }
        }
    }  
}
