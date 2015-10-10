namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Tests.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TopScoreCommandTests
    {
        private readonly TopScoreCommand command;
        private IContext context;

        public TopScoreCommandTests()
        {
            this.context = new MockIContext().MockContext.Object;
            this.command = new TopScoreCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(this.context);
        }
    }
}
