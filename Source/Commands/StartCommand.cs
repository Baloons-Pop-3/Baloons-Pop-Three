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
        public void Execute(IContext context)
        {
            var factory = new GameFactory();
            var validator = new CommandValidator<GameDifficulty>();

            context.Printer.PrintMessage(GlobalMessages.StartCommandMsg);
            var input = context.Reader.ReadInput();

            if (validator.IsValidCommand(input))
            {
                context.GameLogic.Game = factory.CreateGame(validator.GetType(input));
            }
            else
            {
                context.Printer.PrintMessage(GlobalMessages.StartCommandInvalidDifficultyMsg);
            }

            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}