namespace BalloonsPop.Tests.Mocks
{
    using System.Collections;

    using Models;
    using Moq;
    using Printer.Contracts;

    public class MockIPrinter
    {
        public readonly Mock<IGamePrinter> MockPrinter;

        public MockIPrinter()
        {
            this.MockPrinter = new Mock<IGamePrinter>();
            this.MockPrinter.Setup(p => p.PrintMessage(It.IsAny<string>())).Verifiable();
            this.MockPrinter.Setup(p => p.PrintTopScore(It.IsAny<IEnumerable>())).Verifiable();
            this.MockPrinter.Setup(p => p.PrintGameBoard(It.IsAny<GameField>())).Verifiable();
        }
    }
}
