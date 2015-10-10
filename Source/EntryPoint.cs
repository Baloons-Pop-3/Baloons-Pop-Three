//-----------------------------------------------------------------------
// <copyright file="EntryPoint.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the EntryPoint class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop
{
    /// <summary>
    /// Class that provides an entry point for the game.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        private static void Main()
        {         
            GameFacade game = new GameFacade();

            game.Start();
        }
    }
}