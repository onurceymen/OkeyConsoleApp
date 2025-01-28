using OkeyConsoleApp.Entities;
using OkeyConsoleApp.Model;

namespace OkeyConsoleApp.GameLogic
{
    public class Game
    {
        private List<Tile> TileBag { get; set; }
        private List<Player> Players { get; set; }
        private int CurrentPlayerIndex { get; set; }

        public Game(List<Player> players)
        {
            Players = players;
            TileBag = CreateTiles();
            ShuffleTiles();
            DistributeTiles();
            CurrentPlayerIndex = 0;
        }

        private List<Tile> CreateTiles()
        {
            var colors = new[] { "Kırmızı", "Mavi", "Sarı", "Siyah" };
            var tiles = new List<Tile>();

            foreach (var color in colors)
            {
                for (int i = 0; i < 13; i++)
                {
                    tiles.Add(new Tile(color, i));
                    tiles.Add(new Tile(color, i));

                }
            }

            tiles.Add(new Tile("Sahte", 0, true));
            tiles.Add(new Tile("Sahte", 0, true));

            return tiles;
        }

        private void ShuffleTiles()
        {
            Random rnd = new Random();
            TileBag = TileBag.OrderBy(x => rnd.Next()).ToList();
        }

        private void DistributeTiles()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Players[i].DrawTile(TileBag.First());
                    TileBag.RemoveAt(0);
                }
            }
        }

        public void StartGame()
        {
            while (true)
            {
                var currentPlayer = Players[CurrentPlayerIndex];
                Console.Clear();
                Console.WriteLine($"Sıra: {currentPlayer.Name}");
                currentPlayer.DisplayHand();

                Console.WriteLine("Bir Taş Seçip Atın");
                int selectedTileIndex = int.Parse(Console.ReadLine());

                var selectedTile = currentPlayer.Hand[selectedTileIndex];
                currentPlayer.DropTile(selectedTile);
                Console.WriteLine($"{selectedTile} taşını attınız!");

                CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
    }
}