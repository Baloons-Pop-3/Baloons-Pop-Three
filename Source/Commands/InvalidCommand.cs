namespace BalloonsPop.Commands
{
    using Contexts;

    internal class InvalidCommand : ICommand
    {
        public InvalidCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
            this.Context.Printer.PrintMessage("Invalid command type. Please try again");
        }
    }
}