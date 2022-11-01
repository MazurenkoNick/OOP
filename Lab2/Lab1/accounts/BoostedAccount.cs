using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.accounts
{
    public class BoostedAccount : GameAccount
    {
        public BoostedAccount(string userName, int currentRating=100) : base(userName, currentRating)
        {
        }

        private int getWinStreack()
        {
            int totalGames;
            int counter = 0;

            if (games.Count < 20)
            {
                totalGames = games.Count;
            }
            else
            {
                totalGames = 20;
            }

            var last20 = games.TakeLast(20);

            while (counter < totalGames)
            {
                // iterate over all games of the player.
                // if player won every single one of these games, we return true. return false otherwise 
                if (games[totalGames-counter-1].Players[userName] == Status.Win) {
                    counter++;
                    continue;
                }
                break;
            }
            return counter;
        }

        private double GetTotalRating(double rating)
        {
            double totalRating;
            int winStrick = getWinStreack();
            if (winStrick >= 20) {
                // plus 50% of the bet if player has at least 20 wins in a row
                totalRating = rating + (rating * 0.5);
            }
            else if (winStrick >= 15) {
                // plus 30% of the bet if player has at least 15 wins in a row
                totalRating = rating + (rating * 0.3);
            }
            else if (winStrick >= 10) {
                // plus 20% of the bet if player has at least 10 wins in a row
                totalRating = rating + (rating * 0.2);
            }
            else if (winStrick >= 5) {
                // plus 10% of the bet if player has at least 5 wins in a row
                totalRating = rating + (rating * 0.1);
            }
            else { totalRating = rating; }

            return totalRating;
        }

        protected override void AddRating(double rating)
        {
            double newRating = GetTotalRating(rating);
            this.currentRating += newRating;
        }
        protected override void SubtractRating(double rating)
        {
            this.currentRating -= rating;
        }
    }
}
