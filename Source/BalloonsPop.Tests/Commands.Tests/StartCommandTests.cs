namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using Common.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    [TestClass]
    public class StartCommandTests
    {
        private readonly StartCommand command;
        private MockIContext mockingTool;

        public StartCommandTests()
        {
            this.command = new StartCommand();
        }

        [TestMethod]
        public void Execute_WithValidHardLevel_ShouldCreateProperGame()
        {
            var mockReader = new MockIReader("medium");
            this.mockingTool = new MockIContext();
            this.mockingTool.MockContext.SetupGet(x => x.Reader).Returns(mockReader.MockReader.Object);

            this.command.Execute(this.mockingTool.MockContext.Object);

            Assert.AreEqual(GlobalConstants.MediumLevelCols, this.mockingTool.MockContext.Object.GameLogic.Game.Field.FieldCols);
            Assert.AreEqual(GlobalConstants.MediumLevelRows, this.mockingTool.MockContext.Object.GameLogic.Game.Field.FieldRows);
        }

        [TestMethod]
        public void Execute_WithInvalidHardLevel_ShouldCreateDefaultGame()
        {
            var mockReader = new MockIReader("invalid");
            this.mockingTool = new MockIContext();
            this.mockingTool.MockContext.SetupGet(x => x.Reader).Returns(mockReader.MockReader.Object);

            this.command.Execute(this.mockingTool.MockContext.Object);

            Assert.AreEqual(GlobalConstants.DefaultLevelCols, this.mockingTool.MockContext.Object.GameLogic.Game.Field.FieldCols);
            Assert.AreEqual(GlobalConstants.DefaultLevelRows, this.mockingTool.MockContext.Object.GameLogic.Game.Field.FieldRows);
        }
    }
}
