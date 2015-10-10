//-----------------------------------------------------------------------
// <copyright file="IGameFieldFactory.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGameFieldFactory interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Factories.Contracts
{
    using BalloonsPop.Common.Enums;
    using Models;

    /// <summary>
    /// Interface that provides a method for creating a game.
    /// </summary>
    internal interface IGameFieldFactory
    {
        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="input">The level of difficulty - easy, medium, hard, torture.</param>
        /// <returns>New game with the selected level of difficulty.</returns>
        Game CreateGame(GameDifficulty input);
    }
}
