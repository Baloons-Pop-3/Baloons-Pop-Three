namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;
    using Models.Contracts;

    internal class RestoreCommand : ICommand
    {
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