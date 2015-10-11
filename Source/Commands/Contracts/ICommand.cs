//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ICommand interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands.Contracts
{
    using Contexts.Contracts;

    /// <summary>
    /// Interface that provides the Execute method for command.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        void Execute(IContext context);
    }
}