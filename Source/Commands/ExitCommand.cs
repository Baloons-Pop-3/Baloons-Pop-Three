namespace BalloonsPop.Commands
{
    using Contexts;

    internal class ExitCommand : ICommand
    {
        public ExitCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage("Thank you for playing this stupid game :) Welcome back");
        }
    }
}