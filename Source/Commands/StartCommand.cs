namespace BalloonsPop.Commands
{
    using Contexts;

    class StartCommand:ICommand
    {
        public StartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            //TODO: add logic for user input of rows and cols form gamefield
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
