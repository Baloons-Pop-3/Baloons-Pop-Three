namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Factories;

    internal class StartCommand : ICommand
    {
        public StartCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            var factory = new GameFieldFactory();
            var validator = new CommandValidator<GameDifficulty>();

            this.Context.Printer.PrintMessage(GlobalMessages.StartCommandMsg);
            var input = this.Context.Reader.ReadInput();

            if (validator.IsValidCommand(input))
            {
                this.Context.GameLogic.Game = factory.CreateGame(validator.GetType(input));
            }
            else
            {
                this.Context.Printer.PrintMessage(GlobalMessages.StartCommandInvalidDifficultyMsg);
            }

            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}