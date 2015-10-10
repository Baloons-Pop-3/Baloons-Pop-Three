namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using Contexts.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    [TestClass]
    public class SaveCommandTests
    {
        private readonly SaveCommand command;
        private IContext context;

        public SaveCommandTests()
        {
            this.context = new MockIContext().MockContext.Object;
            this.command = new SaveCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(this.context);
        }
    }
}
