namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using Contexts.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    [TestClass]
    public class RestartCommandTests
    {
        private readonly RestartCommand command;
        private IContext context;

        public RestartCommandTests()
        {
            this.context = new MockIContext().MockContext.Object;
            this.command = new RestartCommand();
        }

        [TestMethod]
        public void Execute_ShouldCreateNewGame()
        {
            var expextedNumberOfBalloons = this.context.GameLogic.Game.RemainingBalloons;

            // Simulating that the game has been played and balloons are less than in the beginning
            this.context.GameLogic.Game.RemainingBalloons = 10;

            this.command.Execute(this.context);
            var acturalNumberOfBalloons = this.context.GameLogic.Game.RemainingBalloons;

            Assert.AreEqual(expextedNumberOfBalloons, acturalNumberOfBalloons);
        }
    }
}
