//-----------------------------------------------------------------------
// <copyright file="SaveCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the SaveCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// Class that provides the Execute method for the save command.
    /// </summary>
    internal class SaveCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(GlobalMessages.SaveGameMsg);
            var gameId = context.Reader.ReadInput();

            if (string.IsNullOrWhiteSpace(gameId))
            {
                context.Printer.PrintMessage(GlobalMessages.NullOrEmptyInput);
                return;
            }

            IGame savedGame = context.GameLogic.Game.Clone();
            savedGame.Id = gameId;

            context.GamesController.AddGame(savedGame);

            context.Printer.PrintMessage(GlobalMessages.SavedGameMsg);
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}