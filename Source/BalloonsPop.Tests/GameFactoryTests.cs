namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Factories;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Models;
    using BalloonsPop.Common.Constants;

    [TestClass]
    public class GameFactoryTests
    {
        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsEasy()
        {
            var gameFactory = new GameFactory();
            var expectedResult = new Game(new GameField(GlobalConstants.EasyLevelRows, GlobalConstants.EasyLevelCols));
            var result = gameFactory.CreateGame(GameDifficulty.Easy);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsMedium()
        {
            var gameFactory = new GameFactory();
            var expectedResult = new Game(new GameField(GlobalConstants.MediumLevelRows, GlobalConstants.MediumLevelCols));
            var result = gameFactory.CreateGame(GameDifficulty.Medium);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsHard()
        {
            var gameFactory = new GameFactory();
            var expectedResult = new Game(new GameField(GlobalConstants.HardLevelRows, GlobalConstants.HardLevelCols));
            var result = gameFactory.CreateGame(GameDifficulty.Hard);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }

        [TestMethod]
        public void CreateGame_ShouldReturnCorrectResultWhenDifficultyIsTorture()
        {
            var gameFactory = new GameFactory();
            var expectedResult = new Game(new GameField(GlobalConstants.TortureLevelRows, GlobalConstants.TortureLevelCols));
            var result = gameFactory.CreateGame(GameDifficulty.Torture);

            Assert.AreEqual(expectedResult.Field.FieldRows, result.Field.FieldRows);
            Assert.AreEqual(expectedResult.Field.FieldCols, result.Field.FieldCols);
            Assert.AreEqual(expectedResult.RemainingBalloons, result.RemainingBalloons);
            Assert.AreEqual(0, result.ShootCounter);
        }
    }
}
