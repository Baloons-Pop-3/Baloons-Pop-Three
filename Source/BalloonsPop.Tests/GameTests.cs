namespace BalloonsPop.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class GameTests
    {
        private readonly GameField gameField = new GameField(5, 5);
        private readonly Game game;

        public GameTests()
        {
            this.game = new Game(this.gameField);
        }

        [TestMethod]
        public void SaveMemento_ShouldReturnNewGameMementoWithNewField()
        {
            var actual = this.game.SaveMemento();

            Assert.AreNotSame(actual.Field, this.game.Field);
        }

        [TestMethod]
        public void SaveMemento_ShouldReturnNewGameMementoWithShootCounterEqualToTheGamesShootCounter()
        {
            var actual = this.game.SaveMemento();

            Assert.AreEqual(actual.ShootCounter, this.game.ShootCounter);
        }

        [TestMethod]
        public void SaveMemento_ShouldReturnNewGameMementoWithRemainingBalloonsEqualToTheGamesRemainingBallons()
        {
            var actual = this.game.SaveMemento();

            Assert.AreEqual(actual.RemainingBalloons, this.game.RemainingBalloons);
        }

        [TestMethod]
        public void Clone_ShouldReturnNewGameWithFieldHavingTheSameReferenceToTheClonedField()
        {
            var actual = this.game.Clone();

            Assert.AreSame(actual.Field, this.game.Field);
        }

        [TestMethod]
        public void Clone_ShouldReturnNewGameWithRemainingBalloonsEqualToTheClonedGameRemainingBalloons()
        {
            var actual = this.game.Clone();

            Assert.AreEqual(actual.RemainingBalloons, this.game.RemainingBalloons);
        }

        [TestMethod]
        public void Clone_ShouldReturnNewGameWithShootCounterEqualToTheClonedGameShootCounter()
        {
            var actual = this.game.Clone();

            Assert.AreEqual(actual.ShootCounter, this.game.ShootCounter);
        }
    }
}
