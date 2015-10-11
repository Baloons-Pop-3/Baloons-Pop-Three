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
        private readonly IList<IGame> fakeGameCollection;

        public MockIGamesController()
        {
            this.fakeGameCollection = this.GenerateFakeCollectionOfGames().ToList();
            this.MockGamesController = new Mock<IGamesController>();    
            this.MockGamesController.Setup(x => x.All()).Returns(this.fakeGameCollection);
            this.MockGamesController.Setup(x => x.AddGame(It.IsAny<IGame>())).Callback<IGame>(x => this.fakeGameCollection.Add(x));
            this.MockGamesController.Setup(x => x.SearchById(It.IsAny<string>())).Returns((string id) => this.fakeGameCollection.FirstOrDefault(c => c.Id == id));
        }

        private IEnumerable<IGame> GenerateFakeCollectionOfGames()
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
