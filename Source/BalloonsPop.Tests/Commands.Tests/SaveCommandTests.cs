namespace BalloonsPop.Tests.Commands.Tests
{
    using Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contexts.Contracts;
    using BalloonsPop.Commands;

    [TestClass]
    public class SaveCommandTests
    {
        private readonly IContext mockContext;
        private readonly StartCommand command;

        public SaveCommandTests()
        {
            this.mockContext = new MockIContext().mockContext.Object;
            this.command = new StartCommand();
        }

        [TestMethod]
        public void Execute_ShouldSave()
        {
            this.command.Execute(this.mockContext);
        }
    }
}
