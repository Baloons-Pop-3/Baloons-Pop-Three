namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using Mocks;
    using Contexts.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    [TestClass]
    public class RestartCommandTests
    {
        private IContext context;
        private readonly RestartCommand command;

        public RestartCommandTests()
        {
            this.context = new MockIContext().mockContext.Object;
            this.command = new RestartCommand();
        }

        [TestMethod]
        public void Execute_ShouldCreateNewGame()
        {
            var expextedNumberOfBalloons = this.context.GameLogic.Game.RemainingBalloons;

            // Simulating that the game has been played and balloons are less than in the beginning
            this.context.GameLogic.Game.RemainingBalloons = 10;

            this.command.Execute(context);
            var acturalNumberOfBalloons = this.context.GameLogic.Game.RemainingBalloons;

            Assert.AreEqual(expextedNumberOfBalloons, acturalNumberOfBalloons);
        }
    }
}
