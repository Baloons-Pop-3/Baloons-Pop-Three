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
    public class StartCommandTests
    {
        private  MockIContext mockingTool;
        private readonly StartCommand command;

        public StartCommandTests()
        {
            this.command = new StartCommand();
        }

        [TestMethod]
        public void Execute_ShouldStart()
        {
            var mockReader = new MockIReader("easy");
            this.mockingTool = new MockIContext();           
            this.mockingTool.mockContext.SetupGet(x => x.Reader).Returns(mockReader.mockReader.Object);
          
            this.command.Execute(mockingTool.mockContext.Object);
        }
    }
}
