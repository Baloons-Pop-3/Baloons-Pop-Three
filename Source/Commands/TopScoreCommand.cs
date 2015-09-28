namespace BalloonsPop.Commands
{
    using Common;
    using Contexts;

    class TopScoreCommand:ICommand
    {
        public TopScoreCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintTopScore(this.Context.TopScore.GetTop(GlobalConstants.NUMBER_OF_TOP_PLAYERS));
        }
    }
}
