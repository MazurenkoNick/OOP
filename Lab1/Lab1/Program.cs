using Lab2;

// default for currentRating = 100
GameAccount user1 = new GameAccount("player1");
GameAccount user2 = new GameAccount("player2");

user1.WinGame(user2, 50);
user1.LoseGame(user2, 49);
user2.LoseGame(user1, 25);
user1.WinGame(user2, 73);

user1.GetStats();
user2.GetStats();

Console.ReadLine();