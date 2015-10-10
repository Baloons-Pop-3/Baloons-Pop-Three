//-----------------------------------------------------------------------
// <copyright file="IGameEngine.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGameEngine interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Engine.Contracts
{
    using Controllers.Contracts;
    using Data.Contracts;
    using LogicProviders.Contracts;
    using Printer.Contracts;
    using Reader.Contracts;

    /// <summary>
    /// Interface that provides an engine for the game and a method for starting the game.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Gets the logic for the game.
        /// </summary>
        /// <value>The logic for the game.</value>
        IGameLogicProvider GameLogic { get; }

        /// <summary>
        /// Gets the printer of the game.
        /// </summary>
        /// <value>The printer of the game.</value>
        IGamePrinter Printer { get; }

        /// <summary>
        /// Gets the reader of the input for the game.
        /// </summary>
        /// <value>The reader of the input for the game.</value>
        IReader Reader { get; }

        /// <summary>
        /// Gets the database of the game.
        /// </summary>
        /// <value>The database of the game.</value>
        IBalloonsData DataBase { get; }

        /// <summary>
        /// Gets the controller of the top scores.
        /// </summary>
        /// <value>The controller of the top scores.</value>
        ITopScoreController TopScoreController { get; }

        /// <summary>
        /// Gets the controller of the game.
        /// </summary>
        /// <value>The controller of the game.</value>
        IGamesController GamesController { get; }

        /// <summary>
        /// Starts the game.
        /// </summary>
        void StartGame();
    }
}