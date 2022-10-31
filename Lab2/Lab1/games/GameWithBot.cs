using Lab1.accounts;
using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.games
{
    public class GameWithBot : Game
    {
        private static GameAccount bot;

        public GameWithBot(double rating) : base(rating)
        {
            bot = new BotAccount("bot");
        }

        public static GameAccount Bot { get { return bot; } }
    }
}
