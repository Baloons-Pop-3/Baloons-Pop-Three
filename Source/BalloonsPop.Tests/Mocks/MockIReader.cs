namespace BalloonsPop.Tests.Mocks
{
    using Moq;
    using Reader.Contracts;

    public class MockIReader
    {
        public readonly Mock<IReader> MockReader;

        public MockIReader(string msgToReturn)
        {
            this.MockReader = new Mock<IReader>();
            this.MockReader.Setup(p => p.ReadInput()).Returns(msgToReturn);
        }
    }
}
