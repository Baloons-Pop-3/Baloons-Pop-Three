namespace BalloonsPop.Factories.Contracts
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Contexts.Contracts;

    internal interface ICommandFactory
    {
        ICommand CreateCommand(CommandType input);
    }
}