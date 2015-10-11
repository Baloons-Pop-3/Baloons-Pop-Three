//-----------------------------------------------------------------------
// <copyright file="RestartCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the RestarCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using System.Diagnostics;
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Contexts.Contracts;
    using Models;

    /// <summary>
    /// Class that provides the Execute method for restart game command.
    /// </summary>
    internal class RestartCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            var gameField = new GameField(context.GameLogic.Game.Field.FieldRows, context.GameLogic.Game.Field.FieldCols);
            context.GameLogic.Game = new Game(gameField);
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}