using System;

using BalloonsPop.Drawer;
using BalloonsPop.Printer;
using BalloonsPop.Reader;
using BalloonsPop.TopScoreBoard;

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

        public void Init()
        {
            char[,] drawedGameBoard = Drawer.DrawGameBoard(this.GameBoard);

            this.Printer.PrintMessage("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            this.Printer.PrintGameBoard(drawedGameBoard);

            this.StartGame();
        }

        private void StartGame()
        {
            TopScore ts = new TopScore();
            Coordinates coordinates = new Coordinates();
            Command command = new Command();

            ts.OpenTopScoreList();

            while (this.GameBoard.RemainingBaloons > 0)
            {
                Printer.PrintMessage("Enter a row and column: ");
                var input = Reader.ReadInput();

                if (Command.IsValidCommand(input))
                {
                    command.Type = Command.GetType(input);

                    switch (command.Type)
                    {
                        case CommandType.Top:
                            {
                                ts.PrintScoreList();
                            }
                            break;
                        case CommandType.Restart:
                            {
                                this.Init();
                                this.Printer.PrintGameBoard(this.GameBoard.Field);
                            }
                            break;
                        case CommandType.Exit:
                            {
                                return;
                            }
                    }
                }
                else if (coordinates.TryParse(input))
                {
                    try
                    {
                        this.GameBoard.Shoot(coordinates);
                    }
                    catch (ArgumentException ex)
                    {
                        Printer.PrintMessage(ex.Message);
                    }

                    this.Printer.PrintGameBoard(this.GameBoard.Field);
                }
                else
                {
                   Printer.PrintMessage("Invalid move or command!");
                }
            }

            // TODO: Refactor the logic about topScore
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
