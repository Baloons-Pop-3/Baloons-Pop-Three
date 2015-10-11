//-----------------------------------------------------------------------
// <copyright file="StartCommand.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the StartCommand class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Factories;

    /// <summary>
    /// Class that provides the Execute method for the start game command.
    /// </summary>
    internal class StartCommand : ICommand
    {
        /// <summary>
        ///  Executes the context command .
        /// </summary>
        /// <param name="context">It is used for different kinds of commands to communicate with the game engine.</param>
        public void Execute(IContext context)
        {
            var factory = new GameFactory();
            var validator = new CommandValidator<GameDifficulty>();

            context.Printer.PrintMessage(GlobalMessages.StartCommandMsg);
            var input = context.Reader.ReadInput();

            if (validator.IsValidCommand(input))
            {
                context.GameLogic.Game = factory.CreateGame(validator.GetType(input));
            }
            else
            {
                context.Printer.PrintMessage(GlobalMessages.StartCommandInvalidDifficultyMsg);
            }

            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}