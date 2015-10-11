namespace BalloonsPop.Tests
{
    using System;

    using Common.Constants;
    using Common.Enums;
    using Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class GameFactoryTests
    {
        private readonly GameFactory gameFactory = new GameFactory();
        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsEasy()
        {
            var expectedResult = new Game(new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols));
            var result = this.gameFactory.CreateGame(GameDifficulty.Easy);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsMedium()
        {
            var expectedResult = new Game(new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols));
            var result = this.gameFactory.CreateGame(GameDifficulty.Medium);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsHard()
        {
            var expectedResult = new Game(new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols));
            var result = this.gameFactory.CreateGame(GameDifficulty.Hard);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsTorture()
        {
            var expectedResult = new Game(new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelCols));
            var result = this.gameFactory.CreateGame(GameDifficulty.Torture);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }
    }
}
