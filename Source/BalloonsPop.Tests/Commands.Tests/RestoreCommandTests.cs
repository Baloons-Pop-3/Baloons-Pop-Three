namespace BalloonsPop.Tests.Commands.Tests
{
    using BalloonsPop.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    [TestClass]
    public class RestoreCommandTests
    {
        private readonly MockIContext mockingTool;
        private readonly RestoreCommand command;

        public RestoreCommandTests()
        {
            this.mockingTool = new MockIContext();
            this.command = new RestoreCommand();
        }

        [TestMethod]
        public void Execute_WithValidId_ShouldReturnSearchedGame()
        {
            var mockReader = new MockIReader("FakeId");
            var context = this.mockingTool.MockContext.Object;
            this.mockingTool.MockContext.SetupGet(x => x.Reader).Returns(mockReader.MockReader.Object);
            var expectedGame = context.GameLogic.Game;

            this.command.Execute(context);

            var actualGame = context.GameLogic.Game;

            Assert.AreNotEqual(expectedGame, actualGame);
        }

        [TestMethod]
        public void Execute_WithInValidId_ShouldReturnTheSameGame()
        {
            var mockReader = new MockIReader("InvalidId");
            var context = this.mockingTool.MockContext.Object;
            this.mockingTool.MockContext.SetupGet(x => x.Reader).Returns(mockReader.MockReader.Object);
            var expectedGame = context.GameLogic.Game;

            this.command.Execute(context);

            var actualGame = context.GameLogic.Game;

            Assert.AreEqual(expectedGame, actualGame);
        }
    }
}
