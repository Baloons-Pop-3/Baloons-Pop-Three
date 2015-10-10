namespace BalloonsPop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Engine;
    using Mocks;
    using Models;
    using Moq;
    using Printer;
    using Reader;
    using Engine.Contracts;
    using LogicProviders.Contracts;
    using Controllers.Contracts;
    using Data.Contracts;
    using Data;
    using BalloonsPop.Printer.Contracts;
    using BalloonsPop.Reader.Contracts;

    [TestClass]
    public class GameEngineTests
    {
        private readonly GameField field;
        private readonly Game game;
        private readonly IGamePrinter mockPrinter;
        private readonly IReader mockReader;
        private readonly IGameLogicProvider gameLogic;
        private readonly ITopScoreController topScoreController;
        private readonly IGamesController gamesController;
        private readonly IGameEngine engine;
        private readonly MockIGenericRepository<Game> gamesRepo;
        private readonly MockIGenericRepository<Player> playersRepo;
        private readonly IBalloonsData db;



        public GameEngineTests()
        {
            this.field = new GameField(5, 5);
            this.game = new Game(this.field);
            this.gameLogic = new GameLogicProvider(this.game);
            this.mockPrinter = new MockIPrinter().mockPrinter.Object;
            this.mockReader = new MockIReader().mockReader.Object;
            this.topScoreController = new MockITopScoreController().mockTopScoreController.Object;
            this.gamesController = new MockIGamesController().mockGamesController.Object;
            this.gamesRepo = new MockIGenericRepository<Game>(this.GenerateFakeCollectionOfGames());
            this.playersRepo = new MockIGenericRepository<Player>(this.GenerateFakeCollectionOfPlayers());
            this.db = new BalloonsData(this.playersRepo.MockedRepo.Object, this.gamesRepo.MockedRepo.Object);

            this.engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);
        }

        private IEnumerable<Player> GenerateFakeCollectionOfPlayers()
        {
            var players = new List<Player>();
            players.Add(new Player() { Name = "Player0", Score = 10, Id = "0" });
            players.Add(new Player() { Name = "Player1", Score = 20, Id = "1" });
            players.Add(new Player() { Name = "Player2", Score = 30, Id = "2" });

            return players;
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

        //[TestMethod]
        //public void Sa()
        //{
        //    this.engine.
        //}


    }
}
