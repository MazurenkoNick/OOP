using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class GameAccount
    {
        private string userName;
        private int currentRating;
        private int gamesCount;
        private List<Game> games;

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

        public int CurrentRating
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

        private void addGameToList(Game game)
        {
            games.Add(game);
        }

        public void WinGame(GameAccount opponent, int rating)
        {
            // handle possible edge cases
            if (opponent == null || opponent == this)
                throw new ArgumentNullException("Opponent Cannot Be Null | You Cannot Play With Yourself");
            if (rating < 0)
                throw new ArgumentOutOfRangeException("Rating Cannot Be Less Than 0");
            if (this.CurrentRating <= rating || opponent.CurrentRating <= rating)
                throw new ArgumentOutOfRangeException("All Players Must Have More Than " + rating + " Rating");

            // increment player's total amount of games played
            // & add bet to the player's rating & add game for the current player 
            gamesCount++;
            CurrentRating += rating;
            Game game = new Game(Status.Win, rating, opponent.UserName);
            addGameToList(game);

            // do the same thing for the opponent, except subtract bet from opponent's current rating
            opponent.gamesCount++;
            opponent.CurrentRating -= rating;
            Game theSameGame = new Game(game.GameId, Status.Lose, rating, UserName);
            opponent.addGameToList(theSameGame);
        }

        public void LoseGame(GameAccount opponent, int rating)
        {
            opponent.WinGame(this, rating);
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
