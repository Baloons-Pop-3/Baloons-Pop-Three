namespace BalloonsPop.Printer
{
    using System;
    using System.Collections;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Drawer;
    using BalloonsPop.Drawer.Contracts;
    using BalloonsPop.Models;

    internal sealed class ConsoleGamePrinter : IGamePrinter
    {
        private static ConsoleGamePrinter instance;

        private ConsoleGamePrinter()
        {
        }

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

        public IGameBoardDrawingLogic DrawingLogic { get; private set; }

        public void CleanDisplay()
        {
            Console.Clear();
        }

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

        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

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

        private static void ColoringBalloons(ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(" " + GlobalConstants.BalloonsSymbol + " ");
            Console.ForegroundColor = originalColor;
        }
    }
}