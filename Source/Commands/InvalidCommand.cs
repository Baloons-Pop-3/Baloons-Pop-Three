namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class InvalidCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
            context.Printer.PrintMessage(GlobalMessages.InvalidCommandMsg);
        }
    }
}