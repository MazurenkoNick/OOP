using Lab1.accounts;
using Lab2;

// default for currentRating = 100
PremiumAccount user1 = new PremiumAccount("player1", 100);
PremiumAccount user2 = new PremiumAccount("player2", 100);

user1.WinGame(user2, new Game(99));
//user1.LoseGame(user2, new Game(49));
//user2.LoseGame(user1, new Game(25));
//user1.WinGame(user2, new Game(73));

user1.GetStats();
user2.GetStats();

Console.ReadLine();