namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerShouldThrowArgumentExceptionWhenNameIsNull()
        {
            var player = new Player { Name = null, Score = 5, Id = "1" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerShouldThrowArgumentExceptionWhenNameIsEmptyString()
        {
            var player = new Player { Name = "", Score = 5, Id = "1" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerShouldThrowArgumentExceptionWhenNameIsWhiteSpace()
        {
            var player = new Player { Name = "   ", Score = 5, Id = "1" };
        }

        [TestMethod]
        public void PlayerShouldCreateAPlayerWithValidName()
        {
            var player = new Player { Name = "Pesho", Score = 5, Id = "1" };

            Assert.AreEqual("Pesho", player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerShouldThrowArgumentExceptionWhenScoreIsNegative()
        {
            var player = new Player { Name = "", Score = -5, Id = "1" };
        }

        [TestMethod]
        public void PlayerShouldCreateAPlayerWithValidScore()
        {
            var player = new Player { Name = "Pesho", Score = 5, Id = "1" };

            Assert.AreEqual(5, player.Score);
        }
    }
}
