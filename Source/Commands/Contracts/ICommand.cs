namespace BalloonsPop.Commands.Contracts
{
    using Contexts.Contracts;

    internal interface ICommand
    {
        void Execute(IContext Context);
    }
}