namespace BalloonsPop.Tests.Mocks
{
    using System.Collections.Generic;

    using Common.Constants;
    using Contexts.Contracts;
    using Controllers.Contracts;
    using Data;
    using Data.Contracts;
    using LogicProviders;
    using LogicProviders.Contracts;
    using Mementos;
    using Models;
    using Moq;
    using Printer.Contracts;
    using Reader.Contracts;

    public class MockIContext
    {
        public readonly Mock<IContext> MockContext;
        private readonly GameField field;
        private readonly Game game;
        private readonly IGamePrinter mockPrinter;
        private readonly IReader mockReader;
        private readonly IGameLogicProvider gameLogic;
        private readonly ITopScoreController topScoreController;
        private readonly IGamesController gamesController;
        private readonly MockIGenericRepository<Game> gamesRepo;
        private readonly MockIGenericRepository<Player> playersRepo;
        private readonly IBalloonsData db;

        public MockIContext()
        {
            this.field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);
            this.game = new Game(this.field);
            this.gameLogic = new GameLogicProvider(this.game);
            this.mockPrinter = new MockIPrinter().MockPrinter.Object;
            this.mockReader = new MockIReader("default").MockReader.Object;
            this.topScoreController = new MockITopScoreController().MockTopScoreController.Object;
            this.gamesController = new MockIGamesController().MockGamesController.Object;
            this.gamesRepo = new MockIGenericRepository<Game>(this.GenerateFakeCollectionOfGames());
            this.playersRepo = new MockIGenericRepository<Player>(this.GenerateFakeCollectionOfPlayers());
            this.db = new BalloonsData(this.playersRepo.MockedRepo.Object, this.gamesRepo.MockedRepo.Object);

            this.MockContext = new Mock<IContext>();
            this.MockContext.SetupGet(x => x.DataBase).Returns(this.db);
            this.MockContext.SetupGet(x => x.GameLogic).Returns(this.gameLogic);
            this.MockContext.SetupGet(x => x.GamesController).Returns(this.gamesController);
            this.MockContext.SetupGet(x => x.TopScoreController).Returns(this.topScoreController);
            this.MockContext.SetupGet(x => x.Memory).Returns(new GameStateMemory());
            this.MockContext.SetupGet(x => x.Printer).Returns(this.mockPrinter);
            this.MockContext.SetupGet(x => x.Reader).Returns(this.mockReader);
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
