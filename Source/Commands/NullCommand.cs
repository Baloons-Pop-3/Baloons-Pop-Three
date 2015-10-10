namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    internal class NullCommand : ICommand
    {
        public void Execute(IContext context)
        {
        }
    }
}