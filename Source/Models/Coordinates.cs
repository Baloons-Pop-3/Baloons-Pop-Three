namespace BalloonsPop
{
    internal class Coordinates
    {
        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool TryParse(string input)
        {
            char[] separators = { ' ', ',' };

            string[] subStrings = input.Split(separators);

            System.Console.WriteLine(subStrings.Length);

            if (subStrings.Length != 2)
            {
                System.Console.WriteLine("false");
                return false;
            }

            string coordinateX = subStrings[0].Trim();
            string coordinateY = subStrings[1].Trim();
            int x;
            int y;

            if (int.TryParse(coordinateX, out x) && int.TryParse(coordinateY, out y))
            {
                this.X = x;
                this.Y = y;

                return true;
            }

            return false;
        }
    }
}
