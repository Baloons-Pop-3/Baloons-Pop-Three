namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// This is class for testing purposes. Must be deattached from 'BalloonsPop.Common.Enums.CommandType.cs' in production
    /// </summary>
    internal class FinishCommand : ICommand
    {
        public void Execute(IContext context)
        {
            IPlayer player = new Player();
            player.Score = context.GameLogic.Game.ShootCounter;

            context.Printer.PrintMessage(GlobalMessages.FinishCommandGreetingMsg + context.GameLogic.Game.ShootCounter);
            context.Printer.PrintMessage(GlobalMessages.AddToTopscoreMsg);
            player.Name = context.Reader.ReadInput();

            context.TopScoreController.AddPlayer(player);
            context.GameLogic.IsGameOver = true;
        }
    }
}