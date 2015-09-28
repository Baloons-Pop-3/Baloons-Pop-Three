using System;
using BalloonsPop.Data;
using BalloonsPop.Printer;
using BalloonsPop.Reader;
using BalloonsPop.TopScoreBoard;
using BalloonsPop.Common;
using BalloonsPop.Contexts;
using BalloonsPop.Commands;
using BalloonsPop.Factories;

namespace BalloonsPop.Engine
{
    class GameEngine : IGameEngine
    {
        public GameEngine(GameLogic gameLogic, IGamePrinter printer, IReader reader, IBalloonsData db, ITopScore topScore)
        {
            this.GameLogic = gameLogic;
            this.Printer = printer;
            this.Reader = reader;
            this.DataBase = db;
            this.TopScore = topScore;

            this.Context = new CommandContext(this.DataBase, this.GameLogic, this.Printer, this.Reader, this.TopScore);
            this.Factory = new CommandFactory(this.Context);
        }

        public IBalloonsData DataBase { get; private set; }

        public GameLogic GameLogic { get; private set; }

        public IGamePrinter Printer { get; private set; }

        public IReader Reader { get; private set; }

        public ITopScore TopScore { get; private set; }

        public ICommandContext Context { get; private set; }

        public ICommandFactory Factory { get; private set; }

        public void Init()
        {
            this.Printer.PrintMessage(GlobalMessages.GREETING_MESSAGE);
            this.Printer.PrintGameBoard(this.GameLogic.Game.Field);

            this.StartGame();
        }

        private void StartGame()
        {
            Coordinates coordinates = new Coordinates();
            CommandValidator validator = new CommandValidator();

            while (this.GameLogic.Game.RemainingBaloons > 0)
            {
                Printer.PrintMessage("Enter a row and column: ");
                var input = Reader.ReadInput();
                //Printer.CleanDisplay();

                if (CommandValidator.IsValidCommand(input))
                {
                    validator.Type = CommandValidator.GetType(input);

                    ICommand command = this.Factory.CreateCommand(validator.Type);
                    command.Execute();
                }
                else if (coordinates.TryParse(input))
                {
                    try
                    {
                        this.GameLogic.ShootBalloonAtPosition(coordinates);
                    }
                    catch (ArgumentException ex)
                    {
                        Printer.PrintMessage(ex.Message);
                    }

                    this.Printer.PrintGameBoard(this.GameLogic.Game.Field);
                }
                else
                {
                    Printer.PrintMessage("Invalid move or command!");
                }

            }

            Player player = new Player();
            player.Score = this.GameLogic.Game.ShootCounter;

            Printer.PrintMessage("Please enter your name for the top scoreboard: ");
            player.Name = Reader.ReadInput();

            TopScore.AddPlayer(player);
        }

    }
}
