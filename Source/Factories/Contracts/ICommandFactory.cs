//-----------------------------------------------------------------------
// <copyright file="ICommandFactory.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ICommandFactory interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Factories.Contracts
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Enums;

    /// <summary>
    /// Interface that provides a method for creating a command.
    /// </summary>
    internal interface ICommandFactory
    {
        /// <summary>
        /// Creates a command.
        /// </summary>
        /// <param name="input">The type of the command to be created.</param>
        /// <returns></returns>
        ICommand CreateCommand(CommandType input);
    }
}