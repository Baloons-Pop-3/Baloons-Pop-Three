using BalloonsPop.Commands;
using BalloonsPop.Contexts.Contracts;
using BalloonsPop.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalloonsPop.Tests.Commands.Tests
{
    [TestClass]
   public  class UndoCommandTests
    {
        private IContext context;
        private readonly UndoCommand command;

        public UndoCommandTests()
        {
            this.context = new MockIContext().mockContext.Object;
            this.command = new UndoCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(context);
        }
    }
}
