namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class InvalidCommand : ICommand
    {
        public InvalidCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
            this.Context.Printer.PrintMessage(GlobalMessages.InvalidCommandMsg);
        }
    }
}