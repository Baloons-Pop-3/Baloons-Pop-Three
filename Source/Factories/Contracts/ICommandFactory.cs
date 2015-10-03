namespace BalloonsPop.Factories.Contracts
{
    using BalloonsPop.Commands;
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Contexts;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Engine;

    internal interface ICommandFactory
    {
        ICommandContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}