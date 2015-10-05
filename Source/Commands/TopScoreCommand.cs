namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class TopScoreCommand : ICommand
    {
        public TopScoreCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintTopScore(this.Context.TopScoreController.GetTop(GlobalConstants.NumberOfTopPlayers));
        }
    }
}