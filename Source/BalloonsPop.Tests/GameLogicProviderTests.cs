namespace BalloonsPop.Tests
{
    using Models;
    using LogicProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameLogicProviderTests
    {

        [TestMethod]
        public void ShootBalloonAtPosition_SHouldPopRightBallonsOnOneBalloon()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualField = new char[,] {
                { '1','1','1' },
                { '1','2','1' },
                { '1','1','1' }
            };

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualField[i, j];
                    System.Console.Write(fieldAsCharArr[i,j]);
                }
                System.Console.WriteLine();
            }
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider();
            ShootBalloonAtPosition()
        }

        //[TestMethod]


    }
}
