using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.accounts
{
    public class DefaultAccount : GameAccount
    {
        public DefaultAccount(string userName, int currentRating = 100) : base(userName, currentRating)
        {
        }

        protected override void AddRating(double rating)
        {
            this.currentRating += rating;
        }

        protected override void SubtractRating(double rating)
        {
            this.currentRating -= rating;
        }
    }
}
