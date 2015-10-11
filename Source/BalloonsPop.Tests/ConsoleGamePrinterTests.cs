using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BalloonsPop.Printer;
using BalloonsPop.Models;
using System.Collections.Generic;

namespace BalloonsPop.Tests
{
    [TestClass]
    public class ConsoleGamePrinterTests
    {
        private readonly ConsoleGamePrinter printer = ConsoleGamePrinter.Instance;

        [TestMethod]
        public void PrintMessage_ShouldPrintCorrectMessageOnConsoleWhenTheInputIsCorrect()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                this.printer.PrintMessage("TestTest");

                string expected = string.Format("TestTest{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintGameBoard_ShouldPrintCorrectGameBoardOnConsoleWhenTheInputIsCorrect()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var field = new GameField(3, 3);
                this.printer.PrintGameBoard(field);
                var expectedField = "     0  1  2\r\n -  -  -  - \r\n 0 | 0  0  0 |\r\n 1 | 0  0  0 |\r\n 2 | 0  0  0 |\r\n -  -  -  - \r\n";
                string expected = string.Format("{0}{1}",  expectedField, Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintTopScore_ShouldPrintCorrectTopScoreWhenCorrectInput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var players = new List<Player>();
                players.Add(new Player() { Name = "PlayerTest", Score = 100, Id = "0" });
                players.Add(new Player() { Name = "PlayerTest2", Score = 200, Id = "1" });

                this.printer.PrintTopScore(players);
                var expectedOutput = "1. PlayerTest - 100 shoots\r\n2. PlayerTest2 - 200 shoots";
                string expected = string.Format("{0}{1}", expectedOutput, Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
