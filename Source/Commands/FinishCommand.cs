namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;

    internal class FinishCommand : ICommand
    {
        public FinishCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            Player player = new Player();
            player.Score = this.Context.GameLogic.Game.ShootCounter;

            this.Context.Printer.PrintMessage(GlobalMessages.FinishCommandGreeting + this.Context.GameLogic.Game.ShootCounter);
            this.Context.Printer.PrintMessage(GlobalMessages.AddToTopscoreMsg);
            player.Name = this.Context.Reader.ReadInput();

            this.Context.TopScoreController.AddPlayer(player);
        }
    }
}