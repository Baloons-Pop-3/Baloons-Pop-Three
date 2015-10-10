namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    internal class SaveCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(GlobalMessages.SaveGameMsg);
            var gameId = context.Reader.ReadInput();

            IGame savedGame = context.GameLogic.Game.Clone();
            savedGame.Id = gameId;

            context.GamesController.AddGame(savedGame);

            context.Printer.PrintMessage(GlobalMessages.SavedGameMsg);
            context.Printer.PrintGameBoard(context.GameLogic.Game.Field);
        }
    }
}