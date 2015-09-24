namespace BalloonsPop.Printer
{
    using System;

    using Common;
    using TopScoreBoard;

    class ConsolePrinter : IPrinter
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

        public void PrintTopScore(ITopScore ts)
        {
            throw new NotImplementedException();
        }
    }
}
