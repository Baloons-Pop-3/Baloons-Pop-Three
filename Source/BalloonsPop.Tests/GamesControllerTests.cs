namespace BalloonsPop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;

    [TestClass]
    public class GamesControllerTests
    {

        private readonly IEnumerable<Game> fakeGames;
        private readonly MockGenericRepository<Game> gamesRepo;
        private GamesController gamesController;

        public GamesControllerTests()
        {
            this.fakeGames = this.GenerateFakeCollectionOfGames();
            this.gamesRepo = new MockGenericRepository<Game>(this.fakeGames);
            this.gamesController = new GamesController(this.gamesRepo.MockedRepo.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddGame_ShouldThrow_IfGameIsNull()
        {
            this.gamesController.AddGame(null);
        }

        [TestMethod]
        public void AddGame_ShouldNotThrowAnException()
        {
            var gameField = new GameField(5, 5);
            this.gamesController.AddGame(new Game(gameField));
        }

        [TestMethod]
        public void AllGames_ShouldReturnFakeCollectionGames()
        {
            var allGames=this.gamesController.All();

            Assert.AreEqual(allGames.Count(), allGames.Count());
        }

        [TestMethod]
        public void SearchById_WhenExists_ShouldReturnResult()
        {
            var actualGameId = this.gamesController.SearchById("FakeId").Id;
            var expectedGameId = this.fakeGames.First().Id;

            Assert.AreEqual(expectedGameId, actualGameId);
        }

        [TestMethod]
        public void SearchById_WhenDoesNotExists_ShouldReturnNull()
        {
            var actualGame = this.gamesController.SearchById("NotPresentedId");
            Game expectedGame = null;

            Assert.AreEqual(actualGame, expectedGame);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchById_WhenEmptyStringProvided_ShouldThrow()
        {
             this.gamesController.SearchById("");
        }

        private IEnumerable<Game> GenerateFakeCollectionOfGames()
        {
            var games = new List<Game>();
            var fakeGame = new Game(new GameField(5, 5));
            fakeGame.Id = "FakeId";

            games.Add(fakeGame);
            games.Add(new Game(new GameField(10, 10)));
            games.Add(new Game(new GameField(15, 15)));

           return games;
        }
    }
}
