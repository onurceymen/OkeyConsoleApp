namespace OkeyConsoleApp.Model
{
    public class Tile
    {
        public string Color { get; set; }
        public int Number { get; set; }
        public bool IsFakeJoker { get; set; }

        public Tile(string color, int number, bool ısFakeJoker = false)
        {
            Color = color;
            Number = number;
            IsFakeJoker = ısFakeJoker;
        }
        public override string ToString()
        {
            return IsFakeJoker ? "Sahte Okey" : $"{Color} {Number}";
        }
    }
}
