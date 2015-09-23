using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    using Engine;
    using Printer;
    using Drawer;
    using Reader;
    // veche pisha na c#, uraaaaaaaaaaaaaaa, mnogo e yako tova be!
    class Balloons
    {

        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            IReader reader = new ConsoleReader();
            IPrinter printer = new ConsolePrinter();
            IGameBoardDrawer drawer = new ConsoleGameBoardDrawer();

            IGameBoardEngine engine = new GameBoardEngine(gameBoard, drawer, printer, reader);

            engine.Run();       
        }
    }
}
