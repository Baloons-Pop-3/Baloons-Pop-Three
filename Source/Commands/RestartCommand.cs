namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    internal class RestartCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.GameLogic.Game.Field.FillWithBalloons();
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}