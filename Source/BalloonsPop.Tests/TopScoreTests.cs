namespace BalloonsPop.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Data.Contracts;
    using Moq;
    using System.Linq;
    using Models;
    using TopScoreBoard;
    using System.Collections.Generic;
    using Mocks;
    using System;

    [TestClass]
    public class TopScoreTests
    {
        private readonly IEnumerable<Player> fakePlayers;
        private readonly Mock<IGenericRepository<Player>> mockedPlayersRepo;
        private readonly IBalloonsData db;
        private  TopScore scoreBoard;

        public TopScoreTests()
        {
            this.fakePlayers = this.GenerateFakeCollectionOfPlayers();
            this.mockedPlayersRepo =new Mock<IGenericRepository<Player>>();
            this.ArrangeMockedPlayersRepository();
            this.db = new TestBalloonsData(this.mockedPlayersRepo.Object,null);
            this.scoreBoard = new TopScore(this.db);
        }

        [TestMethod]
        public void GetTopCount_WithCetainNumberOfRecordsIfTheyArePresented_ShouldReturnTheRequestedNumber()
        {
            var requestedNumber = 3;
            var numberOfRecords = this.scoreBoard.GetTop(requestedNumber).Count();

            Assert.AreEqual(requestedNumber, numberOfRecords);
        }

        [TestMethod]
        public void GetTopCount_WithCetainNumberOfRecordsIfTheyAreNotPresented_ShouldReturnAllHighScoreRecordsNumber()
        {
            var requestedNumber = 5;
            var numberOfRecords = this.scoreBoard.GetTop(requestedNumber).Count();
            var allRecords = this.scoreBoard.HighScores.All().Count();

            Assert.AreEqual(allRecords, numberOfRecords);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetTop_ShouldThrow_IfCountIsNegative()
        {
            var requestedNumber = -1;
            var numberOfRecords = this.scoreBoard.GetTop(requestedNumber);
        }

        private void ArrangeMockedPlayersRepository()
        {
            this.mockedPlayersRepo.Setup(r => r.Add(It.IsAny<Player>())).Verifiable();
            this.mockedPlayersRepo.Setup(r => r.All()).Returns(this.fakePlayers);
            this.mockedPlayersRepo.Setup(r => r.Find(It.IsAny<string>())).Verifiable();
        }

        private IEnumerable<Player> GenerateFakeCollectionOfPlayers()
        {
            var players = new List<Player>();
            players.Add(new Player() { Name = "Player0", Score =10, Id= "0" });
            players.Add(new Player() { Name = "Player1", Score = 20 , Id ="1"});
            players.Add(new Player() { Name = "Player2", Score = 30 , Id="2"});

            return players;
        }
    }
}
