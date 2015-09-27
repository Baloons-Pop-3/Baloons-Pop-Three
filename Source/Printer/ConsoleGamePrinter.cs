namespace BalloonsPop.Printer
{
    using System;

    using Common;
    using TopScoreBoard;
    using System.Collections;

    class ConsoleGamePrinter : IGamePrinter
    {
        public void PrintGameBoard(char[,] gameBoard)
        {
            for (int i = 0; i < GlobalConstants.GAME_BOARD_ROWS; i++)
            {
                for (int j = 0; j < GlobalConstants.GAME_BOARD_COLS; j++)
                {
                    Console.Write(gameBoard[j, i]);
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
