namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    internal class NullCommand : ICommand
    {
        public NullCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
        }
    }
}