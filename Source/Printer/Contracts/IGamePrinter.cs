//-----------------------------------------------------------------------
// <copyright file="IGamePrinter.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IGamePrinter interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Printer.Contracts
{
    using System.Collections;
    using BalloonsPop.Drawer.Contracts;
    using BalloonsPop.Models;

    /// <summary>
    /// Interface that provides methods for printing a message, game board and top scores and cleaning the display.
    /// </summary>
    public interface IGamePrinter
    {
        /// <summary>
        /// Gets the drawing logic.
        /// </summary>
        /// <value>The drawing logic.</value>
        IGameBoardDrawingLogic DrawingLogic { get; }

        /// <summary>
        /// Prints the message.
        /// </summary>
        /// <param name="msg">The string message to be printed.</param>
        void PrintMessage(string msg);

        /// <summary>
        /// Prints the game board.
        /// </summary>
        /// <param name="gameBoard">The game board to be printed.</param>
        void PrintGameBoard(GameField gameBoard);

        /// <summary>
        /// Prints the top scores.
        /// </summary>
        /// <param name="topScore">Collection of top scores to be printed.</param>
        void PrintTopScore(IEnumerable topScore);

        /// <summary>
        /// Cleans the display.
        /// </summary>
        void CleanDisplay();
    }
}