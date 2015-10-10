using BalloonsPop.Reader;
using BalloonsPop.Reader.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Tests.Mocks
{
    class MockIReader
    {
        public readonly Mock<IReader> mockReader;

        public MockIReader(string msgToReturn)
        {
            this.mockReader = new Mock<IReader>();
            this.mockReader.Setup(p => p.ReadInput()).Returns(msgToReturn);
        }
    }
}
