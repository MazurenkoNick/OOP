using Lab1.accounts;
using Lab1.games;
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

        public int GamesCount { get { return games.Count; } }

        public List<Game> Games { get { return games; } }

        protected abstract void AddRating(double rating);

        protected abstract void SubtractRating(double rating);

        private void addGameToList(Game game)
        {
            games.Add(game);
        }

        public void WinGame(Game game, GameAccount? opponent=null)
        {
            double rating = game.Rating;

            // handle possible edge cases
            if (opponent is null) {
                // opponent is allowed to be null only if it's game that has type of "GameWithBot".
                // In this case, opponent will be set to the bot
                if (game.GetType() == typeof(GameWithBot)) 
                {
                    opponent = GameWithBot.Bot;
                }
                else throw new ArgumentNullException("Opponent Cannot Be Null");
            }
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
            this.AddRating(rating);
            this.addGameToList(game);

            // do the same thing for the opponent, except subtract bet from opponent's current rating
            opponent.SubtractRating(rating);
            opponent.addGameToList(game);
        }

        public void LoseGame(Game game, GameAccount? opponent=null)
        {
            // opponent is allowed to be null only if it's game that has type of "GameWithBot".
            // In this case, opponent will be set to the bot
            if (game.GetType() == typeof(GameWithBot))
            {
                opponent = GameWithBot.Bot;
            }
            else throw new ArgumentNullException("Opponent Cannot Be Null");

            opponent.WinGame(game, this);
        }

        public void GetStats()
        {
            Console.WriteLine(userName + " stats:");
            Console.WriteLine("gamesCount: " + GamesCount + ", current rating: " + currentRating);
            foreach (Game game in games)
            {
                Console.WriteLine(game);
            }
        }
    }  
}
