namespace BalloonsPop.Printer
{
    using System.Collections;

    using TopScoreBoard;
    interface IPrinter
    {
        void PrintMessage(string msg);

        void PrintGameBoard(char[,] gameBoard);

        void PrintTopScore(IEnumerable ts);
    }
}
