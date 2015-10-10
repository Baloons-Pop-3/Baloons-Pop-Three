namespace BalloonsPop.Tests
{
    using System;
    using System.Linq;
    using BalloonsPop.Mementos;  
    using BalloonsPop.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void SaveMemento_ShouldReturnNewGameMementoWithRemainingBalloonsEqualToTheGamesRemainingBalloons()
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

        [TestMethod]
        public void RestoreMemento_ShouldSetGamesFieldToMementosField()
        {
            var field = new GameField(3, 3);
            int shootCounter = 5;
            int remainingBalloons = 10;
            var memento = new GameMemento(field, shootCounter, remainingBalloons);

            this.game.RestoreMemento(memento);

            Assert.AreSame(memento.Field, this.game.Field);
        }

        [TestMethod]
        public void RestoreMemento_ShouldSetGamesShootCounterToMementosShootCounter()
        {
            var field = new GameField(3, 3);
            int shootCounter = 5;
            int remainingBalloons = 10;
            var memento = new GameMemento(field, shootCounter, remainingBalloons);

            this.game.RestoreMemento(memento);

            Assert.AreEqual(memento.ShootCounter, this.game.ShootCounter);
        }

        [TestMethod]
        public void RestoreMemento_ShouldSetGamesRemainingBalloonsToMementosRemainingBalloons()
        {
            var field = new GameField(3, 3);
            int shootCounter = 5;
            int remainingBalloons = 10;
            var memento = new GameMemento(field, shootCounter, remainingBalloons);

            this.game.RestoreMemento(memento);

            Assert.AreEqual(memento.RemainingBalloons, this.game.RemainingBalloons);
        }

        [TestMethod]
        public void GetField_ShouldReturnFieldWithSameGameSize()
        {
            var field = new GameField(2, 3);
            Assert.AreEqual(2, field.GetField().GetLength(0));
            Assert.AreEqual(3, field.GetField().GetLength(1));
        }
    }
}
