namespace BalloonsPop.Commands
{
    using Contexts;

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