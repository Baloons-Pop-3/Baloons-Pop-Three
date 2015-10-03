﻿namespace BalloonsPop.Factories.Contracts
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Contexts.Contracts;

    internal interface ICommandFactory
    {
        IContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}