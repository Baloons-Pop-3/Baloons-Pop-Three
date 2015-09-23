namespace BalloonsPop
{
    using System;
    using System.Linq;

    using Common;

    internal class Coordinates
    {
        private int gameBoardRows = GlobalConstants.BALLOONS_BOARD_ROWS;
        private int gameBoardCols = GlobalConstants.BALLOONS_BOARD_COLS;

        private int x;
        private int y;

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value >= 0 && value <= gameBoardCols - 1)
                {
                    this.x = value;
                }
                else
                {
                    //throw new ArgumentOutOfRangeException("X coordinates");
                }
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value >= 0 && value <= gameBoardRows - 1)
                {
                    this.y = value;
                }
                else
                {
                    //throw new ArgumentOutOfRangeException("Y coordinates");
                }
            }
        }

        public bool TryParse(string input, ref Coordinates result)
        {
            char[] separators = { ' ', ',' };

            string[] subStrings = input.Split(separators);

            if (subStrings.Count<string>() != 2)
            {
                return false;
            }

            string coordinateX = subStrings[1].Trim();
            int x;
            if (int.TryParse(coordinateX, out x))
            {
                if (x >= 0 && x <= gameBoardCols - 1)
                {
                    result.X = x;
                }
                else
                {
                    Console.WriteLine("Wrong x coordinates");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            coordinateX = subStrings[0].Trim();
            int y;
            if (int.TryParse(coordinateX, out y))
            {
                if (y >= 0 && y <= gameBoardRows - 1)
                {
                    result.Y = y;
                }
                else
                {
                    Console.WriteLine("Wrong y coordinates");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            return true;
        }
    }
}
