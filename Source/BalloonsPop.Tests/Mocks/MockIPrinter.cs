using BalloonsPop.Models;
using BalloonsPop.Printer;
using BalloonsPop.Printer.Contracts;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Tests.Mocks
{
    class MockIPrinter
    {
        public readonly Mock<IGamePrinter> mockPrinter;

        public MockIPrinter()
        {
            this.mockPrinter = new Mock<IGamePrinter>();
            this.mockPrinter.Setup(p => p.PrintMessage(It.IsAny<string>())).Verifiable();
            this.mockPrinter.Setup(p => p.PrintTopScore(It.IsAny<IEnumerable>())).Verifiable();
            this.mockPrinter.Setup(p => p.PrintGameBoard(It.IsAny<GameField>())).Verifiable();
        }
    }
}
