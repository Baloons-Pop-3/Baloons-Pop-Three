namespace BalloonsPop.Printer
{
    using Drawer;
    using System.Collections;

    internal interface IGamePrinter
    {
        IGameBoardDrawingLogic drawingLogic { get; }

        void PrintMessage(string msg);

        void PrintGameBoard(GameField gameBoard);

        void PrintTopScore(IEnumerable topScore);

        void CleanDisplay();
    }
}