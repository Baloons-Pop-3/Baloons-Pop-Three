//-----------------------------------------------------------------------
// <copyright file="UndoCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the UndoCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;

    /// <summary>
    /// Class that provides the Execute method for the undo game command.
    /// </summary>
    internal class UndoCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            if (context.Memory.GameMemento != null)
            {
                context.GameLogic.Game.RestoreMemento(context.Memory.GameMemento);
            }

            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}