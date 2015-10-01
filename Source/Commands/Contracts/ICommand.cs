namespace BalloonsPop.Commands
{
    using BalloonsPop.Contexts;

    internal interface ICommand
    {
        ICommandContext Context { get; }

        void Execute();
    }
}