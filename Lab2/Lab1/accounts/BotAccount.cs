using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.accounts
{
    public class BotAccount : GameAccount
    {
        public BotAccount(string userName, int currentRating = 9999999) : base(userName, currentRating)
        {
        }
        protected override void AddRating(double rating) {}

        protected override void SubtractRating(double rating) {}
    }
}
