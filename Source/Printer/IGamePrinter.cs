namespace BalloonsPop.Printer
{
    using System.Collections;
    using Drawer;

    internal interface IGamePrinter
    {
        IGameBoardDrawingLogic DrawingLogic { get; }

        void PrintMessage(string msg);

        void PrintGameBoard(GameField gameBoard);

        void PrintTopScore(IEnumerable topScore);

        void CleanDisplay();
    }
}