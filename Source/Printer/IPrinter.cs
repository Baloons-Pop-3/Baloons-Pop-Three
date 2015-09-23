namespace BalloonsPop.Printer
{
    interface IPrinter
    {
        void PrintMessage(string msg);

        void PrintGameBoard(char[,] gameBoard);

        void PrintTopScore();
    }
}
