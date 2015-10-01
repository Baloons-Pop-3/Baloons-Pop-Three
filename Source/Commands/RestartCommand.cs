namespace BalloonsPop.Commands
{
    using Contexts;

    internal class RestartCommand : ICommand
    {
        public RestartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.GameLogic.Game.Field.FillWithBalloons();
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}