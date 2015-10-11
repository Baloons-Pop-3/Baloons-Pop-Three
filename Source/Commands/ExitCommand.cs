//-----------------------------------------------------------------------
// <copyright file="ExitCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ExitCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;

    /// <summary>
    /// Class that provides the Execute method for the Exit/End game command.
    /// </summary>
    internal class ExitCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(GlobalMessages.ExitCommandMessageMsg);
            context.GameLogic.IsGameOver = true;
        }
    }
}