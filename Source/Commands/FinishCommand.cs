namespace BalloonsPop.Commands
{
    using Common;
    using Contexts;

    internal class FinishCommand : ICommand
    {
        public FinishCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            Player player = new Player();
            player.Score = this.Context.GameLogic.Game.ShootCounter;

            this.Context.Printer.PrintMessage("Congratulations, you popped all ballooons with " + this.Context.GameLogic.Game.ShootCounter);
            this.Context.Printer.PrintMessage(GlobalMessages.AddToTopscoreMsg);
            player.Name = this.Context.Reader.ReadInput();

            this.Context.TopScore.AddPlayer(player);
        }
    }
}