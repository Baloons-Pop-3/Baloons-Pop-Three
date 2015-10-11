//-----------------------------------------------------------------------
// <copyright file="FinishCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the FinishCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    /// <summary>
    /// Class that provides the Execute method for the Finish/End game command.
    /// </summary>
    internal class FinishCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            IPlayer player = new Player();
            player.Score = context.GameLogic.Game.ShootCounter;

            context.Printer.PrintMessage(GlobalMessages.FinishCommandGreetingMsg + context.GameLogic.Game.ShootCounter);
            context.Printer.PrintMessage(GlobalMessages.AddToTopscoreMsg);
            var playerName = context.Reader.ReadInput();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                context.Printer.PrintMessage(GlobalMessages.NullOrEmptyInput);
            }
            else
            {
                player.Name = playerName;
                context.TopScoreController.AddPlayer(player);
            }

            context.GameLogic.IsGameOver = true;
        }
    }
}