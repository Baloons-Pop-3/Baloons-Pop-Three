namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    internal class RestartCommand : ICommand
    {
        public RestartCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.GameLogic.Game.Field.FillWithBalloons();
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}