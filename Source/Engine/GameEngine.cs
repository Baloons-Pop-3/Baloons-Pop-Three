namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Contexts;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Factories;
    using BalloonsPop.Factories.Contracts;
    using BalloonsPop.Models;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;

    internal class GameEngine : IGameEngine
    {
        public GameEngine(GameLogic gameLogic, IGamePrinter printer, IReader reader, IBalloonsData db, ITopScore topScore)
        {
            this.GameLogic = gameLogic;
            this.Printer = printer;
            this.Reader = reader;
            this.DataBase = db;
            this.TopScore = topScore;

            this.Context = new Context(this.DataBase, this.GameLogic, this.Printer, this.Reader, this.TopScore);
            this.Factory = new CommandFactory(this.Context);
        }

        public IBalloonsData DataBase { get; private set; }

        public GameLogic GameLogic { get; private set; }

        public IGamePrinter Printer { get; private set; }

        public IReader Reader { get; private set; }

        public ITopScore TopScore { get; private set; }

        public IContext Context { get; private set; }

        public ICommandFactory Factory { get; private set; }

        public void StartGame()
        {
            this.Printer.PrintMessage(GlobalMessages.GreetingMsg);

            while (this.GameLogic.Game.RemainingBalloons > 0)
            {
                var input = this.Reader.ReadInput();

                this.Printer.CleanDisplay();
                this.Printer.PrintMessage(GlobalMessages.GreetingMsg);

                this.ProcessInput(input);
            }

            ICommand command = this.Factory.CreateCommand(CommandType.Finish);
            command.Execute();
        }

        private void SaveLastStateOfGame()
        {
            this.Context.Memory.GameMemento = this.GameLogic.Game.SaveMemento();
        }

        private void ProcessInput(string input)
        {
            //this.Printer.CleanDisplay();
            var commandsValidator = new CommandValidator<CommandType>();
            Coordinates coordinates = new Coordinates();

            if (commandsValidator.IsValidCommand(input))
            {
                ICommand command = this.Factory.CreateCommand(commandsValidator.GetType(input));
                command.Execute();
            }
            else if (coordinates.TryParse(input))
            {
                string msg = GlobalMessages.RowColMsg;

                try
                {
                    this.SaveLastStateOfGame();

                    this.GameLogic.ShootBalloonAtPosition(coordinates);
                }
                catch (ArgumentException ex)
                {
                    msg = ex.Message;
                }

                this.Printer.PrintGameBoard(this.GameLogic.Game.Field);
                this.Printer.PrintMessage(msg);
            }
            else
            {
                this.Printer.PrintGameBoard(this.GameLogic.Game.Field);
                this.Printer.PrintMessage(GlobalMessages.InvalidCommandMsg);
            }
        }
    }
}