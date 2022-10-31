using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.games
{
    public enum GameType
    {
        DEFAULT, WITH_BOT, TRAINING
    }

    public class GameFactory
    {
        public static Game GetGame(GameType type, double rating) 
        {
            Game game;
            
            if (type == GameType.WITH_BOT) game = new GameWithBot(rating);
            else if (type == GameType.TRAINING) game = new TrainingGame();
            else game = new DefaultGame(rating);

            return game;
        }
    }
}
