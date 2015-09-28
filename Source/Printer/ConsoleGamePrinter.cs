namespace BalloonsPop.Printer
{
    using System;

    using Common;
    using TopScoreBoard;
    using System.Collections;
    using Models;

    class ConsoleGamePrinter : IGamePrinter
    {
        public void PrintGameBoard(GameField field)
        {
          GameBoard board = new GameBoard(field);

            for (int i = 0; i < board.BoardRows; i++)
            {
                for (int j = 0; j < board.BoardCols; j++)
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
