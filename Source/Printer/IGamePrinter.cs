namespace BalloonsPop.Printer
{
    using Models;
    using System.Collections;

    using TopScoreBoard;
    interface IGamePrinter
    {
        void PrintMessage(string msg);

        void PrintGameBoard(GameField gameBoard);

        void PrintTopScore(IEnumerable ts);
    }
}
