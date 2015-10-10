namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class TopScoreCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.Printer.PrintTopScore(context.TopScoreController.GetTop(GlobalConstants.NumberOfTopPlayers));
        }
    }
}