//-----------------------------------------------------------------------
// <copyright file="ConsoleGamePrinter.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ConsoleGamePrinter class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Printer
{
    using System;
    using System.Collections;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Drawer;
    using BalloonsPop.Drawer.Contracts;
    using BalloonsPop.Models;
    using BalloonsPop.Printer.Contracts;

    /// <summary>
    /// A single-instance class that provides methods for printing to the console and cleaning the display.
    /// </summary>
    internal sealed class ConsoleGamePrinter : IGamePrinter
    {
        /// <summary>
        ///  The instance of the <see cref="ConsoleGamePrinter"/> class.
        /// </summary>
        private static ConsoleGamePrinter instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="ConsoleGamePrinter"/> class from being created.
        /// </summary>
        private ConsoleGamePrinter()
        {
        }

        /// <summary>
        /// Gets the instance from the <see cref="ConsoleGamePrinter"/> class.
        /// </summary>
        public static ConsoleGamePrinter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleGamePrinter();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the drawing logic.
        /// </summary>
        /// <value>The drawing logic.</value>
        public IGameBoardDrawingLogic DrawingLogic { get; private set; }

        /// <summary>
        /// Cleans the console.
        /// </summary>
        public void CleanDisplay()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints the game board on the console.
        /// </summary>
        /// <param name="field">The game board to be printed on the console.</param>
        public void PrintGameBoard(GameField field)
        {
            this.DrawingLogic = new GameBoardDrawingLogic(field);

            var board = this.DrawingLogic.Board;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i != 0 && j != 0)
                    {
                        switch (board[i, j])
                        {
                            case " 1 ":
                                ColoringBalloons(ConsoleColor.Red);
                                break;
                            case " 2 ":
                                ColoringBalloons(ConsoleColor.Yellow);
                                break;
                            case " 3 ":
                                ColoringBalloons(ConsoleColor.Green);
                                break;
                            case " 4 ":
                                ColoringBalloons(ConsoleColor.Cyan);
                                break;
                            case " 5 ":
                                ColoringBalloons(ConsoleColor.Magenta);
                                break;
                            default: Console.Write(board[i, j]);
                                break;
                        }
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints the message on the console.
        /// </summary>
        /// <param name="msg">The string message to be printed on the console.</param>
        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Prints the top scores on the console.
        /// </summary>
        /// <param name="topScorePlayers">Collection of top scores players to be printed on the console.</param>
        public void PrintTopScore(IEnumerable topScorePlayers)
        {
            var playerPosition = 1;
            foreach (var item in topScorePlayers)
            {
                var player = item as Player;

                Console.WriteLine("{0}. {1} - {2} {3}", playerPosition, player.Name, player.Score, player.Score == 1 ? "shoot" : "shoots");

                playerPosition++;
            }
        }

        /// <summary>
        /// Colors the balloons.
        /// </summary>
        /// <param name="color">The color of the balloons.</param>
        private static void ColoringBalloons(ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(" " + GlobalConstants.BalloonsSymbol + " ");
            Console.ForegroundColor = originalColor;
        }
    }
}