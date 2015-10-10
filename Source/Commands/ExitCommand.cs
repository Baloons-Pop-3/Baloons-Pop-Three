namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class ExitCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(GlobalMessages.ExitCommandMessageMsg);
            context.GameLogic.IsGameOver = true;
        }
    }
}