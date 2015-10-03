namespace BalloonsPop.Commands.Contracts
{
    using BalloonsPop.Contexts.Contracts;

    internal interface ICommand
    {
        ICommandContext Context { get; }

        void Execute();
    }
}