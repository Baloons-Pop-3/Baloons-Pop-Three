namespace BalloonsPop.Engine
{
    using System;
    using Commands.Contracts;
    using Common.Constants;
    using Common.Enums;
    using Common.Validators;
    using Contexts;
    using Contexts.Contracts;
    using Contracts;
    using Controllers.Contracts;
    using Data.Contracts;
    using Factories;
    using Factories.Contracts;
    using LogicProviders.Contracts;
    using Models;
    using Models.Contracts;
    using Printer;
    using Reader;

    internal class GameEngine : IGameEngine
    {
        public GameEngine(IGameLogicProvider gameLogic, IGamePrinter printer, IReader reader, IBalloonsData db, ITopScoreController topScoreController, IGamesController gamesController)
        {
            this.GameLogic = gameLogic;
            this.Printer = printer;
            this.Reader = reader;
            this.DataBase = db;
            this.TopScoreController = topScoreController;
            this.GamesController = gamesController;

            this.Context = new Context(this.DataBase, this.GameLogic, this.Printer, this.Reader, this.TopScoreController, this.GamesController);
            this.Factory = new CommandFactory(this.Context);
            this.CommandValidator = new CommandValidator<CommandType>();
        }

        public IBalloonsData DataBase { get; private set; }

        public IGameLogicProvider GameLogic { get; private set; }

        public IGamePrinter Printer { get; private set; }

        public IReader Reader { get; private set; }

        public ITopScoreController TopScoreController { get; private set; }

        public IGamesController GamesController { get; private set; }

        public IContext Context { get; private set; }

        public ICommandFactory Factory { get; private set; }
         
        public CommandValidator<CommandType> CommandValidator { get; private set; }

        public void StartGame()
        {
            this.Printer.PrintMessage(GlobalMessages.GreetingMsg);

            while (this.GameLogic.Game.RemainingBalloons > 0)
            {
                var input = this.Reader.ReadInput();
                this.Printer.CleanDisplay();
                this.Printer.PrintMessage(GlobalMessages.GreetingMsg);

                this.ProcessInput(input);
                Console.WriteLine(this.GameLogic.Game.RemainingBalloons);
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
            ICoordinates coordinates = new Coordinates();

            if (this.CommandValidator.IsValidCommand(input))
            {
                ICommand command = this.Factory.CreateCommand(this.CommandValidator.GetType(input));
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