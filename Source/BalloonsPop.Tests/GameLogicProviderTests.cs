namespace BalloonsPop.Tests
{
    using Models;
    using LogicProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameLogicProviderTests
    {

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnOneBalloon()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','1','1' },
                { '1','2','1' },
                { '1','1','1' }
            };

            var manualFieldAfter = new char[,] {
                { '1','.','1' },
                { '1','1','1' },
                { '1','1','1' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnTwoBalloonsVertical()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','1','1' },
                { '1','2','1' },
                { '1','2','1' }
            };

            var manualFieldAfter = new char[,] {
                { '1','.','1' },
                { '1','.','1' },
                { '1','1','1' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnTwoBalloonsHorizontal()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','1','1' },
                { '1','2','2' },
                { '1','1','1' }
            };

            var manualFieldAfter = new char[,] {
                { '1','.','.' },
                { '1','1','1' },
                { '1','1','1' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnThreeBalloonsVertical()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','2','1' },
                { '1','2','1' },
                { '1','2','1' }
            };

            var manualFieldAfter = new char[,] {
                { '1','.','1' },
                { '1','.','1' },
                { '1','.','1' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnThreeBalloonsEdge()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','2','1' },
                { '1','2','2' },
                { '1','1','1' }
            };

            var manualFieldAfter = new char[,] {
                { '1','.','.' },
                { '1','.','1' },
                { '1','1','1' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnBalloonsOnX()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,] {
                { '1','2','1' },
                { '2','2','2' },
                { '1','2','2' }
            };

            var manualFieldAfter = new char[,] {
                { '.','.','.' },
                { '1','.','1' },
                { '1','.','2' }
            };

            Coordinates positionToShoot = new Coordinates(1, 1);

            //fill the field with the manual chars
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            //create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            logicProvider.ShootBalloonAtPosition(positionToShoot);


            //Assert
            for (int i = 0; i < fieldAsCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < fieldAsCharArr.GetLength(0); j++)
                {
                    Assert.IsTrue(gameField[i, j] == manualFieldAfter[i, j]);
                }
            }
        }


    }
}
