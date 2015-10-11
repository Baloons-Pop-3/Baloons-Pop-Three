namespace BalloonsPop.Tests
{
    using System.Collections.Generic;

    using Common.Constants;
    using Controllers.Contracts;
    using Data;
    using Data.Contracts;
    using Engine;
    using LogicProviders;
    using LogicProviders.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using Printer.Contracts;
    using Reader.Contracts;

    [TestClass]
    public class GameEngineTests
    {
        private GameField field;
        private Game game;
        private IGamePrinter mockPrinter;
        private IReader mockReader;
        private IGameLogicProvider gameLogic;
        private ITopScoreController topScoreController;
        private IGamesController gamesController;
        private MockIGenericRepository<Game> gamesRepo;
        private MockIGenericRepository<Player> playersRepo;
        private IBalloonsData db;

        public GameEngineTests()
        {
            this.field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);
            this.game = new Game(this.field);
            this.gameLogic = new GameLogicProvider(this.game);
            this.mockPrinter = new MockIPrinter().MockPrinter.Object;
            this.topScoreController = new MockITopScoreController().MockTopScoreController.Object;
            this.gamesController = new MockIGamesController().MockGamesController.Object;
            this.gamesRepo = new MockIGenericRepository<Game>(this.GenerateFakeCollectionOfGames());
            this.playersRepo = new MockIGenericRepository<Player>(this.GenerateFakeCollectionOfPlayers());
            this.db = new BalloonsData(this.playersRepo.MockedRepo.Object, this.gamesRepo.MockedRepo.Object);           
        }

        [TestMethod]
        public void StartGame_WithExitInput_ShouldEndGame()
        {
            this.mockReader = new MockIReader("exit").MockReader.Object;
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);

            engine.StartGame();
        }

        [TestMethod]
        public void StartGame_WithFinishInput_ShouldEndGame()
        {
            this.mockReader = new MockIReader("finish").MockReader.Object;
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);

            engine.StartGame();
        }

        [TestMethod]
        public void StartGame_WithSaveInput_ShouldSaveGame()
        {
            this.mockReader = new MockIReader("save").GetSpecialReader("save");
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);

            engine.StartGame();

            Assert.IsNotNull(engine.GamesController.SearchById("save"));
        }

        [TestMethod]
        public void StartGame_WithValidCoordinates_ShouldPopBalloon()
        {
            this.mockReader = new MockIReader("3 8").GetSpecialReader("3 8");
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);
            var balloonsBefore = engine.GameLogic.Game.RemainingBalloons;

            engine.StartGame();

            var balloonsAfter = engine.GameLogic.Game.RemainingBalloons;

            Assert.AreNotEqual(balloonsBefore, balloonsAfter);
        }

        public void StartGame_WithInValidCoordinates_ShouldNotPopBalloon()
        {
            this.mockReader = new MockIReader("-1 8").GetSpecialReader("-1 8");
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);
            var balloonsBefore = engine.GameLogic.Game.RemainingBalloons;

            engine.StartGame();

            var balloonsAfter = engine.GameLogic.Game.RemainingBalloons;

            Assert.AreEqual(balloonsBefore, balloonsAfter);
        }

        [TestMethod]
        public void StartGame_WithInInvalidCommand_ShouldNotThrow()
        {
            this.mockReader = new MockIReader("invalid").GetSpecialReader("invalid");
            var engine = new GameEngine(this.gameLogic, this.mockPrinter, this.mockReader, this.db, this.topScoreController, this.gamesController);

            engine.StartGame();
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
    }
}
