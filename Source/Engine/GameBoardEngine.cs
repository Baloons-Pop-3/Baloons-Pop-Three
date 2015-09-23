using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPop.Drawer;
using BalloonsPop.Printer;
using BalloonsPop.Reader;

namespace BalloonsPop.Engine
{
    class GameBoardEngine : IGameBoardEngine
    {
        public GameBoardEngine(GameBoard gameBoard, IGameBoardDrawer drawer, IPrinter printer,IReader reader)
        {
            this.GameBoard = gameBoard;
            this.Drawer = drawer;
            this.Printer = printer;
            this.Reader = reader;
        }

        public GameBoard GameBoard{ get; set; }

        public IGameBoardDrawer Drawer { get; set; }

        public IPrinter Printer { get; set; }

        public IReader Reader { get; set; }

        public void Run()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            this.StartGame();
        }

        private void StartGame()
        {
            char[,] drawedGameBoard = Drawer.DrawGameBoard(this.GameBoard);

            this.Printer.PrintGameBoard(drawedGameBoard);
            TopScore ts = new TopScore();

            ts.OpenTopScoreList();

            bool isCoordinates;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();

            while (this.GameBoard.RemainingBaloons > 0)
            {
                var input = Reader.ReadInput();

                isCoordinates = coordinates.TryParse(input,ref coordinates);

                if (isCoordinates)
                {
                    this.GameBoard.Shoot(coordinates);
                    this.Printer.PrintGameBoard(this.GameBoard.Field);
                }

                //}


                //if (this.GameBoard.ReadInput(out isCoordinates, ref coordinates, ref command))
                //{
                //    if (isCoordinates)
                //    {
                //        this.GameBoard.Shoot(coordinates);
                //        this.Printer.PrintGameBoard(this.GameBoard.Field);
                //    }
                //    else
                //    {
                //        switch (command.Type)
                //        {
                //            case CommandType.Top:
                //                {
                //                    ts.PrintScoreList();
                //                }
                //                break;
                //            case CommandType.Restart:
                //                {
                //                    this.GameBoard.GenerateBalloons();
                //                    this.Printer.PrintGameBoard(this.GameBoard.Field);
                //                }
                //                break;
                //            case CommandType.Exit:
                //                {
                //                    return;
                //                }
                //        }
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Wrong Input!");
                //}
            }

            Player player = new Player();
            player.Score = this.GameBoard.ShootCounter;

            if (ts.IsTopScore(player))
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                player.Name = Console.ReadLine();
                ts.AddToTopScoreList(player);
            }
            ts.SaveTopScoreList();

        }
    }
}
