//-----------------------------------------------------------------------
// <copyright file="ICoordinates.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ICoordinates interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models.Contracts
{
    /// <summary>
    /// Interface that provides properties for getting and setting the abscissa and ordinate of a coordinate and a method
    /// that tries to parse an input string to a coordinate.
    /// </summary>
    public interface ICoordinates
    {
        /// <summary>
        /// Gets or sets the abscissa of the coordinate.
        /// </summary>
        /// <value>The abscissa of the coordinate.</value>
         int X { get; set; }

        /// <summary>
        /// Gets or sets the ordinate of the coordinate.
        /// </summary>
        /// <value>The ordinate of the coordinate.</value>
         int Y { get; set; }

        /// <summary>
        /// Tries to parse the input string to a coordinate.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Boolean value - true if the input can be parsed to a coordinate and otherwise - false.</returns>
        bool TryParse(string input);
    }
}
