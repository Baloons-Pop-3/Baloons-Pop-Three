namespace BalloonsPop.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Models;
    using Drawer;
    using System.Text;

    [TestClass]
    public class GameBoardDrawingLogicTests
    {
        [TestMethod]
        public void GameBoardDrawingLogic_ShouldDrowCorectBoard()
        {
            var manualFieldBefor = new char[,] {
                { '1','3','3' },
                { '1','2','4' },
                { '1','4','2' }
            };

            var manualFieldAfter = "     0  1  2\r\n -  -  -  - \r\n 0 | 1  3  3 |\r\n 1 | 1  2  4 |\r\n 2 | 1  4  2 |\r\n -  -  -  - \r\n";

            var gameFieldXLen = manualFieldBefor.GetLength(0);
            var gameFieldYLen = manualFieldBefor.GetLength(1);
            GameField gameField = new GameField(gameFieldXLen, gameFieldYLen);

            //fill the field with the manual chars
            for (int i = 0; i < gameFieldXLen; i++)
            {
                for (int j = 0; j < gameFieldYLen; j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            var board = new GameBoardDrawingLogic(gameField);

            var boardAsString = new StringBuilder();
            for (int i = 0; i < board.Board.GetLength(0); i++)
            {
                for (int j = 0; j < board.Board.GetLength(1); j++)
                {
                    boardAsString.Append(board.Board[i, j]);
                }
                boardAsString.AppendLine();
            }
            Assert.IsTrue(manualFieldAfter.Equals(boardAsString.ToString()));
        }
    }
}
