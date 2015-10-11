namespace BalloonsPop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Printer;

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
        public void PrintGameBoard_ShouldPrintCorrectGameBoardOnConsoleWhenTheInputIsCorrectAndMoreThan20Rows()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var field = new GameField(23, 3);
                this.printer.PrintGameBoard(field);
                var expectedField = "     0  1  2\r\n -  -  -  - \r\n 0 | 0  0  0 |\r\n 1 | 0  0  0 |\r\n 2 | 0  0  0 |\r\n 3 | 0  0  0 |\r\n 4 | 0  0  0 |\r\n 5 | 0  0  0 |\r\n 6 | 0  0  0 |\r\n 7 | 0  0  0 |\r\n 8 | 0  0  0 |\r\n 9 | 0  0  0 |\r\n10 | 0  0  0 |\r\n11 | 0  0  0 |\r\n12 | 0  0  0 |\r\n13 | 0  0  0 |\r\n14 | 0  0  0 |\r\n15 | 0  0  0 |\r\n16 | 0  0  0 |\r\n17 | 0  0  0 |\r\n18 | 0  0  0 |\r\n19 | 0  0  0 |\r\n20 | 0  0  0 |\r\n21 | 0  0  0 |\r\n22 | 0  0  0 |\r\n -  -  -  - \r\n";
                string expected = string.Format("{0}{1}", expectedField, Environment.NewLine);
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
