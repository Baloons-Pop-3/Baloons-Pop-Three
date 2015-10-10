//-----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the Coordinates class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models
{
    using Contracts;

    /// <summary>
    /// Class that creates new coordinates instances and provides a method for determining whether a passed input value
    /// can be parsed to a new coordinate.
    /// </summary>
    public class Coordinates : ICoordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        public Coordinates()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="x">The abscissa of the coordinate.</param>
        /// <param name="y">The ordinate of the coordinate.</param>
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the abscissa of the coordinate.
        /// </summary>
        /// <value>The abscissa of the coordinate.</value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the ordinate of the coordinate.
        /// </summary>
        /// <value>The ordinate of the coordinate.</value>
        public int Y { get; set; }

        /// <summary>
        /// Tries to parse the input string to a coordinate.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Boolean value - true if the input can be parsed to a coordinate and otherwise - false.</returns>
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