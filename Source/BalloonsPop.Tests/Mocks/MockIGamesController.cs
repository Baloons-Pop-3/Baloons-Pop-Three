using BalloonsPop.Controllers.Contracts;
using BalloonsPop.Models;
using BalloonsPop.Models.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Tests.Mocks
{
    class MockIGamesController
    {
        public readonly Mock<IGamesController> mockGamesController;

        public MockIGamesController()
        {
            this.mockGamesController = new Mock<IGamesController>();
            this.mockGamesController.Setup(x => x.All()).Returns(GenerateFakeCollectionOfGames());
            this.mockGamesController.Setup(x => x.AddGame(It.IsAny<IGame>())).Verifiable();
            this.mockGamesController.Setup(x => x.SearchById(It.IsAny<string>())).Returns((string id) => this.GenerateFakeCollectionOfGames().FirstOrDefault(c => c.Id == id));
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
