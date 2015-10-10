using BalloonsPop.Models;
using BalloonsPop.Printer;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Tests.Mocks
{
    class MockPrinter
    {
        public readonly Mock<IGamePrinter> mockedPrinter;

        public MockPrinter()
        {
            this.mockedPrinter = new Mock<IGamePrinter>();
            this.mockedPrinter.Setup(p => p.PrintMessage(It.IsAny<string>())).Verifiable();
            this.mockedPrinter.Setup(p => p.PrintTopScore(It.IsAny<IEnumerable>())).Verifiable();
            this.mockedPrinter.Setup(p => p.PrintGameBoard(It.IsAny<GameField>())).Verifiable();
            //this.mockedPrinter.Setup(p=>p.)

        }
    }
}
