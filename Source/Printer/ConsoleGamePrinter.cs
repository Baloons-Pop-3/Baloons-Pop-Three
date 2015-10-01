namespace BalloonsPop.Printer
{
    using Drawer;
    using Models;
    using System;
    using System.Collections;

    internal class ConsoleGamePrinter : IGamePrinter
    {
        public IGameBoardDrawingLogic drawingLogic { private set; get; }

        public void CleanDisplay()
        {
            Console.Clear();
        }

        public void PrintGameBoard(GameField field)
        {
            this.drawingLogic = new GameBoardDrawingLogic(field);

            var board = drawingLogic.Board;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
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
    }
}