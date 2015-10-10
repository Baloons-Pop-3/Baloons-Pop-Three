using BalloonsPop.Commands;
using BalloonsPop.Contexts.Contracts;
using BalloonsPop.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalloonsPop.Tests.Commands.Tests
{
    [TestClass]
    public class TopScoreCommandTests
    {
        private IContext context;
        private readonly TopScoreCommand command;

        public TopScoreCommandTests()
        {
            this.context = new MockIContext().mockContext.Object;
            this.command = new TopScoreCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(this.context);
        }
    }
}
