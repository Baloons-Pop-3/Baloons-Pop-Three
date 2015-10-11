namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Tests.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UndoCommandTests
    {
        private readonly UndoCommand command;
        private IContext context;

        public UndoCommandTests()
        {
            this.context = new MockIContext().MockContext.Object;
            this.command = new UndoCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(this.context);
        }
    }
}
