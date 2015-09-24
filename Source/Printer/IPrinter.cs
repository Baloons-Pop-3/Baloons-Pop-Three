namespace BalloonsPop.Printer
{
    using TopScoreBoard;
    interface IPrinter
    {
        void PrintMessage(string msg);

        void PrintGameBoard(char[,] gameBoard);

        void PrintTopScore(ITopScore ts);
    }
}
