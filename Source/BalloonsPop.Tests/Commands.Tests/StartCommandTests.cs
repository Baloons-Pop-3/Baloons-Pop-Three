namespace BalloonsPop.Tests.Commands.Tests
{
    using Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Commands;
    using System.Diagnostics;
    using Common.Constants;

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
        public void Execute_WithValidHardLevel_ShouldCreateProperGame()
        {
            var mockReader = new MockIReader("medium");
            this.mockingTool = new MockIContext();           
            this.mockingTool.mockContext.SetupGet(x => x.Reader).Returns(mockReader.mockReader.Object);
          
            this.command.Execute(mockingTool.mockContext.Object);

            Assert.AreEqual(GlobalConstants.MediumLevelCols, this.mockingTool.mockContext.Object.GameLogic.Game.Field.FieldCols);
            Assert.AreEqual(GlobalConstants.MediumLevelRows,this.mockingTool.mockContext.Object.GameLogic.Game.Field.FieldRows);
        }

        [TestMethod]
        public void Execute_WithInvalidHardLevel_ShouldCreateDefaultGame()
        {
            var mockReader = new MockIReader("invalid");
            this.mockingTool = new MockIContext();
            this.mockingTool.mockContext.SetupGet(x => x.Reader).Returns(mockReader.mockReader.Object);

            this.command.Execute(mockingTool.mockContext.Object);

            Assert.AreEqual(GlobalConstants.DefaultLevelCols, this.mockingTool.mockContext.Object.GameLogic.Game.Field.FieldCols);
            Assert.AreEqual(GlobalConstants.DefaultLevelRows, this.mockingTool.mockContext.Object.GameLogic.Game.Field.FieldRows);
        }
    }
}
