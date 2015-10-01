namespace BalloonsPop.Commands
{
    using BalloonsPop.Contexts;

    internal class UndoCommand : ICommand
    {
        public UndoCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            if (this.Context.Memory.GameMemento != null)
            {
                this.Context.GameLogic.Game.RestoreMemento(this.Context.Memory.GameMemento);
            }

            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}