namespace BalloonsPop.Printer
{
    using System.Collections;

    using TopScoreBoard;
    interface IGamePrinter
    {
        void PrintMessage(string msg);

        void PrintGameBoard(char[,] gameBoard);

        void PrintTopScore(IEnumerable ts);
    }
}
