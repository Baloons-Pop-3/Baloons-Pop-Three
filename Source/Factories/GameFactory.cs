//-----------------------------------------------------------------------
// <copyright file="GameFactory.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameFactory class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Factories
{
    using System;
    using Common.Constants;
    using Common.Enums;
    using Contracts;
    using Models;

    /// <summary>
    /// Class that provides a method for creating a game.
    /// </summary>
    internal class GameFactory : IGameFieldFactory
    {
        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="input">The level of difficulty - easy, medium, hard, torture.</param>
        /// <returns>New game with the selected level of difficulty.</returns>
        public Game CreateGame(GameDifficulty input)
        {
            switch (input)
            {
                case GameDifficulty.Easy:
                    return new Game(new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols));
                case GameDifficulty.Medium:
                    return new Game(new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols));
                case GameDifficulty.Hard:
                    return new Game(new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols));
                case GameDifficulty.Torture:
                    return new Game(new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelCols));
                default:
                    return null;
            }
        }
    }
}
