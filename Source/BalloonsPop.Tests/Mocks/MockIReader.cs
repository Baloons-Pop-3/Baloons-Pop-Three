namespace BalloonsPop.Tests.Mocks
{
    using Moq;
    using Reader.Contracts;

    public class MockIReader
    {
        public MockIReader(string msgToReturn)
        {
            this.MockReader = new Mock<IReader>();
            this.MockReader.Setup(p => p.ReadInput()).Returns(msgToReturn);
        }

        public Mock<IReader> MockReader { get; set; }

        public IReader GetSpecialReader(string msgToReturn)
        {
            this.MockReader = new Mock<IReader>();
            var callsCounter = 10;
            this.MockReader.Setup(x => x.ReadInput())
                .Callback(() =>
                {
                    if (callsCounter == 0)
                    {
                        msgToReturn = "finish";
                    }
                    else
                    {
                        callsCounter--;
                    }
                })
                .Returns(() => msgToReturn);

            return this.MockReader.Object;
        }
    }
}
