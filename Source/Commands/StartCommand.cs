namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Contexts.Contracts;
    using Factories;
    using BalloonsPop.Models;
    using Factories.Contracts;

    internal class StartCommand : ICommand
    {
        public StartCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            var factory = new GameFieldFactory(this.Context);
            var validator = new CommandValidator<GameDifficulty>();

            this.Context.Printer.PrintMessage(GlobalMessages.StartCommandMessage);
            var input = this.Context.Reader.ReadInput();

            if (validator.IsValidCommand(input))
            {
                this.Context.GameLogic.Game.Field = factory.CreateGame(validator.GetType(input));             
            }
            else
            {
                this.Context.Printer.PrintMessage(GlobalMessages.StartCommandInvalidDifficultyMessage);
            }

            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}