//-----------------------------------------------------------------------
// <copyright file="IReader.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IReader interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Reader.Contracts
{
    /// <summary>
    /// Interface that provides a method to read the input.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Method that reads the input.
        /// </summary>
        /// <returns>String with the input value.</returns>
        string ReadInput();
    }
}