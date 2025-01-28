using OkeyConsoleApp.Entities;
using OkeyConsoleApp.GameLogic;

var players = new List<Player>
        {
            new Player("Oyuncu 1"),
            new Player("Oyuncu 2"),
            new Player("Oyuncu 3"),
            new Player("Oyuncu 4")
        };

var game = new Game(players);
game.StartGame();