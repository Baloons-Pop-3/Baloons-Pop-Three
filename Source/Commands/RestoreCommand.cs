//-----------------------------------------------------------------------
// <copyright file="RestoreCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the RestoreCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// Class that provides the Execute method for the restore command.
    /// </summary>
    internal class RestoreCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            IGame game;
            var savedGames = context.GamesController.All();

            context.Printer.PrintMessage(GlobalMessages.AllGamesMsg);
            foreach (var savedGame in savedGames)
            {
                context.Printer.PrintMessage(savedGame.Id);
            }

            context.Printer.PrintMessage(GlobalMessages.NameOfGameToRestoreMsg);

            var nameOfTheGame = context.Reader.ReadInput();

            game = context.GamesController.SearchById(nameOfTheGame);

            if (game == null)
            {
                context.Printer.PrintMessage(GlobalMessages.RestoreCommandInvalidGameMsg);
                return;
            }

            context.GameLogic.Game = game;
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}