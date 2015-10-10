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
        public void GameBoardDrawingLogic_ShouldDrowCorectBoard3x3()
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

        [TestMethod]
        public void GameBoardDrawingLogic_ShouldDrowCorectBoard12x12()
        {
            var manualFieldBefor = new char[,] {
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
                { '1','3','3','1','3','3','1','3','3','1','3','3' },
            };

            var manualFieldAfter = "     0  1  2  3  4  5  6  7  8  9 10 11\r\n -  -  -  -  -  -  -  -  -  -  -  -  - \r\n 0 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 1 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 2 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 3 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 4 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 5 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 6 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 7 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 8 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n 9 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n10 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n11 | 1  3  3  1  3  3  1  3  3  1  3  3 |\r\n -  -  -  -  -  -  -  -  -  -  -  -  - \r\n";

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
