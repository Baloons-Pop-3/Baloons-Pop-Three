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

        //public bool TryParse(string input, ref Coordinates result)
        //{
        //    char[] separators = { ' ', ',' };

        //    string[] subStrings = input.Split(separators);

        //    if (subStrings.Count<string>() != 2)
        //    {
        //        return false;
        //    }

        //    string coordinateX = subStrings[1].Trim();
        //    int x;
        //    if (int.TryParse(coordinateX, out x))
        //    {
        //        if (x >= 0 && x <= gameBoardCols - 1)
        //        {
        //            result.X = x;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Wrong x coordinates");
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid move or command!");
        //        return false;
        //    }

        //    coordinateX = subStrings[0].Trim();
        //    int y;
        //    if (int.TryParse(coordinateX, out y))
        //    {
        //        if (y >= 0 && y <= gameBoardRows - 1)
        //        {
        //            result.Y = y;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Wrong y coordinates");
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid move or command!");
        //        return false;
        //    }

        //    return true;
        //}
    }
}
