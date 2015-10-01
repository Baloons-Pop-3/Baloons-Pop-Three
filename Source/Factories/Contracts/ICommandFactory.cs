namespace BalloonsPop.Factories
{
    using BalloonsPop.Commands;
    using BalloonsPop.Contexts;

    internal interface ICommandFactory
    {
        ICommandContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}