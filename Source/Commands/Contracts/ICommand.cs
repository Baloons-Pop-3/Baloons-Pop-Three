namespace BalloonsPop.Commands.Contracts
{
    using Contexts.Contracts;

    internal interface ICommand
    {
        IContext Context { get; }

        void Execute();
    }
}