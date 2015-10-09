namespace BalloonsPop.Printer
{
    using System.Collections;
    using BalloonsPop.Drawer.Contracts;
    using BalloonsPop.Models;

    internal interface IGamePrinter
    {
        IGameBoardDrawingLogic DrawingLogic { get; }

        void PrintMessage(string msg);

        void PrintGameBoard(GameField gameBoard);

        void PrintTopScore(IEnumerable topScore);

        void CleanDisplay();
    }
}