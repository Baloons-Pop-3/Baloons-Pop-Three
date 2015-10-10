namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    internal class UndoCommand : ICommand
    {
        public void Execute(IContext context)
        {
            if (context.Memory.GameMemento != null)
            {
                context.GameLogic.Game.RestoreMemento(context.Memory.GameMemento);
            }

            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}