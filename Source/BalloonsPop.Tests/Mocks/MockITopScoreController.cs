namespace BalloonsPop.Tests.Mocks
{
    using System.Collections.Generic;

    using Controllers.Contracts;
    using Models;
    using Models.Contracts;
    using Moq;

    public class MockITopScoreController
    {
        public readonly Mock<ITopScoreController> MockTopScoreController;

        public MockITopScoreController()
        {
            this.MockTopScoreController = new Mock<ITopScoreController>();
            this.MockTopScoreController.Setup(x => x.All()).Returns(new List<IPlayer>());
            this.MockTopScoreController.Setup(x => x.AddPlayer(It.IsAny<IPlayer>())).Verifiable();
            this.MockTopScoreController.Setup(x => x.GetTop(It.IsAny<int>())).Returns(new List<Player>());
        }
    }
}
