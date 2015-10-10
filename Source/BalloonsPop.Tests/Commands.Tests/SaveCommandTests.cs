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

    [TestClass]
    public class SaveCommandTests
    {
        private IContext context;
        private readonly SaveCommand command;

        public SaveCommandTests()
        {
            this.context = new MockIContext().mockContext.Object;
            this.command = new SaveCommand();
        }

        [TestMethod]
        public void Execute_ShouldNotThrow()
        {
            this.command.Execute(this.context);
        }
    }
}
