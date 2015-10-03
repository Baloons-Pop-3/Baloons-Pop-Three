namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    internal class ExitCommand : ICommand
    {
        public ExitCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage(GlobalMessages.ExitCommandMessage);
        }
    }
}