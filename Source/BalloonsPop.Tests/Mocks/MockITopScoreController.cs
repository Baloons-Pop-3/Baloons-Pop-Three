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
    public class MockITopScoreController
    {
        public readonly Mock<ITopScoreController> mockTopScoreController;

        public MockITopScoreController()
        {
            this.mockTopScoreController = new Mock<ITopScoreController>();
            this.mockTopScoreController.Setup(x => x.All()).Returns(new List<IPlayer>());
            this.mockTopScoreController.Setup(x => x.AddPlayer(It.IsAny<IPlayer>())).Verifiable();
            this.mockTopScoreController.Setup(x => x.GetTop(It.IsAny<int>())).Returns(new List<Player>());
        }
    }
}
