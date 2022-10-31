using Lab1.accounts;
using Lab1.games;
using Lab2;

// default for currentRating = 100
GameAccount user1 = new BoostedAccount("player1", 1001);
GameAccount user2 = new BoostedAccount("player2", 1001);

user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);
user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);
user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);
user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);
user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);
// additional 10% of the bet will be added to user1's currentRating
user1.WinGame(GameFactory.getGame(GameType.DEFAULT, 100), user2);

user1.LoseGame(GameFactory.getGame(GameType.WITH_BOT, 100));
user1.WinGame(GameFactory.getGame(GameType.WITH_BOT, 100));


// user2.LoseGame(user1, new Game(25));
// user1.WinGame(user2, new Game(73));

user1.GetStats();
user2.GetStats();

Console.ReadLine();