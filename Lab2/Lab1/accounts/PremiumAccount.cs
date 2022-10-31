using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.accounts
{
    public class PremiumAccount : GameAccount
    {
        public PremiumAccount(string userName, int currentRating = 150) : base(userName, currentRating)
        {
        }

        protected override void AddRating(double rating)
        {
            // premium account receives additional 15% from the bet
            this.currentRating += (rating + (0.15 * rating));
        }

        protected override void SubtractRating(double rating)
        {
            // premium account loses only 85% of the bet
            this.currentRating -= (rating - (0.15 * rating));
        }
    }
}
