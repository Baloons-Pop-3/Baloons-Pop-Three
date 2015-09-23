namespace BalloonsPop
{
    using System;
    using System.Linq;

    using Common;

    internal class Coordinates
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool TryParse(string input)
        {
            char[] separators = { ' ', ',' };

            string[] subStrings = input.Split(separators);

            if (subStrings.Length != 2)
            {
                return false;
            }

            string coordinateX = subStrings[1].Trim();
            string coordinateY = subStrings[0].Trim();
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
