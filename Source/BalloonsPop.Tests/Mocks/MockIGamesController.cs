namespace BalloonsPop.Tests.Mocks
{
    using System.Collections.Generic;
    using System.Linq;

    using Controllers.Contracts;
    using Models;
    using Models.Contracts;
    using Moq;

    public class MockIGamesController
    {
        public readonly Mock<IGamesController> MockGamesController;

        public MockIGamesController()
        {
            this.MockGamesController = new Mock<IGamesController>();
            this.MockGamesController.Setup(x => x.All()).Returns(this.GenerateFakeCollectionOfGames());
            this.MockGamesController.Setup(x => x.AddGame(It.IsAny<IGame>())).Verifiable();
            this.MockGamesController.Setup(x => x.SearchById(It.IsAny<string>())).Returns((string id) => this.GenerateFakeCollectionOfGames().FirstOrDefault(c => c.Id == id));
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
