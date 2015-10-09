namespace BalloonsPop.Models
{
    using Contracts;

    public class Coordinates:ICoordinates
    {
        public Coordinates()
        {
        }

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

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            string[] subStrings = input.Split(separators);

            if (subStrings.Length != 2)
            {
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