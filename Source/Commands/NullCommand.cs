namespace BalloonsPop.Commands
{
    using Contexts;

    class NullCommand : ICommand
    {
        public NullCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
        }
    }
}
