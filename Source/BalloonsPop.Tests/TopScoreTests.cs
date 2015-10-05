namespace BalloonsPop.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Collections.Generic;

    using Data.Contracts;
    using Models;
    using TopScoreBoard;
    using Mocks;

    [TestClass]
    public class TopScoreTests
    {
        private readonly IEnumerable<Player> fakePlayers;
        private readonly MockGenericRepository<Player> playersRepo;
        private TopScoreController topScoreController;

        public TopScoreTests()
        {
            this.fakePlayers = this.GenerateFakeCollectionOfPlayers();
            this.playersRepo = new MockGenericRepository<Player>(this.fakePlayers);
            this.topScoreController = new TopScoreController(this.playersRepo.mockedRepo.Object);
        }

        [TestMethod]
        public void GetTopCount_WithCetainNumberOfRecordsIfTheyArePresented_ShouldReturnTheRequestedNumber()
        {
            var expectedNumberOfRecords = 3;
            var actualNumberOfRecords = this.topScoreController.GetTop(expectedNumberOfRecords).Count();

            Assert.AreEqual(expectedNumberOfRecords, actualNumberOfRecords);
        }

        [TestMethod]
        public void GetTopCount_WithCetainNumberOfRecordsIfTheyAreNotPresented_ShouldReturnAllHighScoreRecordsNumber()
        {
            var requestedNumber = 5;
            var actualNumberOfRecords = this.topScoreController.GetTop(requestedNumber).Count();
            var expectedNumberOfRecords = this.topScoreController.All().Count();

            Assert.AreEqual(expectedNumberOfRecords, actualNumberOfRecords);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetTop_ShouldThrow_IfCountIsNegative()
        {
            var requestedNumber = -1;
            var numberOfRecords = this.topScoreController.GetTop(requestedNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPlayer_ShouldThrow_IfPlayerIsNull()
        {
            this.topScoreController.AddPlayer(null);
        }

        [TestMethod]
        public void AddPlayer_ShouldNotThrowAnException()
        {
            this.topScoreController.AddPlayer(new Player());
        }

        private IEnumerable<Player> GenerateFakeCollectionOfPlayers()
        {
            var players = new List<Player>();
            players.Add(new Player() { Name = "Player0", Score = 10, Id = "0" });
            players.Add(new Player() { Name = "Player1", Score = 20, Id = "1" });
            players.Add(new Player() { Name = "Player2", Score = 30, Id = "2" });

            return players;
        }
    }
}
