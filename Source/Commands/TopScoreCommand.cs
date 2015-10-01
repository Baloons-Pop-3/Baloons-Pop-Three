namespace BalloonsPop.Commands
{
    using Common;
    using Contexts;

    internal class TopScoreCommand : ICommand
    {
        public TopScoreCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintTopScore(this.Context.TopScore.GetTop(GlobalConstants.NumberOfTopPlayers));
        }
    }
}