using BalloonsPop.Contexts;

namespace BalloonsPop.Commands
{
    interface ICommand
    {
        ICommandContext Context { get; }
        void Execute();
    }
}
