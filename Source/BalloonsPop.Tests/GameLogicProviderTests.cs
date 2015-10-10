namespace BalloonsPop.Tests
{
    using System;

    using LogicProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class GameLogicProviderTests
    {
        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnOneBalloon()
        {
            var manualFieldBefor = new char[,]
            {
                { '1', '1', '1' },
                { '1', '2', '1' },
                { '1', '1', '1' }
            };

            var manualFieldAfter = new char[,]
            {
                { '1', '.', '1' },
                { '1', '1', '1' },
                { '1', '1', '1' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnTwoBalloonsVertical()
        {
            var manualFieldBefor = new char[,]
            {
                { '1', '1', '1' },
                { '1', '2', '1' },
                { '1', '2', '1' }
            };

            var manualFieldAfter = new char[,]
            {
                { '1', '.', '1' },
                { '1', '.', '1' },
                { '1', '1', '1' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnTwoBalloonsHorizontal()
        {
            var manualFieldBefor = new char[,]
            {
                { '1', '1', '1' },
                { '1', '2', '2' },
                { '1', '1', '1' }
            };

            var manualFieldAfter = new char[,]
            {
                { '1', '.', '.' },
                { '1', '1', '1' },
                { '1', '1', '1' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnThreeBalloonsVertical()
        {
            var manualFieldBefor = new char[,]
            {
                { '1', '2', '1' },
                { '1', '2', '1' },
                { '1', '2', '1' }
            };

            var manualFieldAfter = new char[,]
            {
                { '1', '.', '1' },
                { '1', '.', '1' },
                { '1', '.', '1' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnThreeBalloonsEdge()
        {
            var manualFieldBefor = new char[,]
            {
                { '1', '2', '1' },
                { '1', '2', '2' },
                { '1', '1', '1' }
            };

            var manualFieldAfter = new char[,]
            {
                { '1', '.', '.' },
                { '1', '.', '1' },
                { '1', '1', '1' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [TestMethod]
        public void ShootBalloonAtPosition_ShouldPopRightBallonsOnBalloonsOnX()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,]
            {
                { '1', '2', '1' },
                { '2', '2', '2' },
                { '1', '2', '2' }
            };

            var manualFieldAfter = new char[,]
            {
                { '.', '.', '.' },
                { '1', '.', '1' },
                { '1', '.', '2' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);

            Assert.IsTrue(this.EqualCharArrays(manualFieldAfter, gameFieldAfterShoot));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShootBalloonAtPosition_ShouldThrowOnPopedPlace()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,]
            {
                { '1', '.', '1' },
                { '2', '.', '2' },
                { '1', '2', '2' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShootBalloonAtPosition_ShouldThrowOnInvalidBalloonCoordinats()
        {
            GameField gameField = new GameField(3, 3);
            var fieldAsCharArr = gameField.GetField();

            var manualFieldBefor = new char[,]
            {
                { '1', '.', '1' },
                { '2', 'e', '2' },
                { '1', '2', '2' }
            };

            var gameFieldAfterShoot = this.ShootAt1x1(manualFieldBefor);
        }

        private char[,] ShootAt1x1(char[,] manualFieldBefor)
        {
            var gameFieldXLen = manualFieldBefor.GetLength(0);
            var gameFieldYLen = manualFieldBefor.GetLength(1);
            GameField gameField = new GameField(gameFieldXLen, gameFieldYLen);

            // fill the field with the manual chars
            for (int i = 0; i < gameFieldXLen; i++)
            {
                for (int j = 0; j < gameFieldYLen; j++)
                {
                    gameField[i, j] = manualFieldBefor[i, j];
                }
            }

            // Create game with custom field
            Game game = new Game(gameField);
            var logicProvider = new GameLogicProvider(game);

            // shoot 1x1
            Coordinates positionToShoot = new Coordinates(1, 1);
            logicProvider.ShootBalloonAtPosition(positionToShoot);

            return gameField.GetField();
        }

        private bool EqualCharArrays(char[,] firstCharArray, char[,] secondCharArray)
        {
            var firstCharArrayXLen = firstCharArray.GetLength(0);
            var firstCharArrayYLen = firstCharArray.GetLength(1);
            var secondCharArrayArrayXLen = secondCharArray.GetLength(0);
            var secondCharArrayArrayYLen = secondCharArray.GetLength(1);

            if (firstCharArrayXLen != secondCharArrayArrayXLen || firstCharArrayYLen != secondCharArrayArrayYLen)
            {
                return false;
            }

            for (int i = 0; i < firstCharArrayXLen; i++)
            {
                for (int j = 0; j < firstCharArrayYLen; j++)
                {
                    if (firstCharArray[i, j] != secondCharArray[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
