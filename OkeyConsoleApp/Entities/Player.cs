using OkeyConsoleApp.Model;

namespace OkeyConsoleApp.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public List<Tile> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Tile>();
        }

        public void DrawTile(Tile tile)
        {
            Hand.Add(tile);
        }

        public void DropTile(Tile tile)
        {
            Hand.Remove(tile);
        }

        public void DisplayHand()
        {
            Console.WriteLine($"{Name}'in Taşları:");
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Hand[i]}");
            }
        }
    }
}
