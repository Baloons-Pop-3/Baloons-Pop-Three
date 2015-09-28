namespace BalloonsPop.Commands
{
    using Contexts;

    class RestartCommand : ICommand
    {
        public RestartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.GameLogic.Game.Field.FillWithBalloons();
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
