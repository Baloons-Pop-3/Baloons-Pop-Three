namespace BalloonsPop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Engine;
    using Mocks;
    using Models;
    using Moq;
    using Printer;

    [TestClass]
    class GameEngineTests
    {
        private Mock<IGamePrinter> MockedRepo = new Mock<IGamePrinter>();
        //private GameEngine engine = new GameEngine()

        public GameEngineTests()
        {

        }
    }
}
