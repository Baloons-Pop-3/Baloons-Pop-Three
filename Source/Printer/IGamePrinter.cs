namespace BalloonsPop.Printer
{
    using Drawer;
    using Models;
    using System.Collections;

    using TopScoreBoard;
    interface IGamePrinter
    {
        IGameBoardDrawingLogic drawingLogic { get; }

        void PrintMessage(string msg);

        void PrintGameBoard(GameField gameBoard);

        void PrintTopScore(IEnumerable topScore);
    }
}
