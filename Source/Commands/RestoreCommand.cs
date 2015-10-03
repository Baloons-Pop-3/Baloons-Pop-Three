namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;

    internal class RestoreCommand : ICommand
    {
        public RestoreCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            Game game;
            var savedGames = this.Context.DataBase.Games.All();

            this.Context.Printer.PrintMessage(GlobalMessages.AllGamesMsg);
            foreach (var savedGame in savedGames)
            {
                this.Context.Printer.PrintMessage(savedGame.Id);
            }
            this.Context.Printer.PrintMessage(GlobalMessages.NameOfGameToRestoreMsg);

            var nameOfTheGame = this.Context.Reader.ReadInput();

            game = this.Context.DataBase.Games.Find(nameOfTheGame);

            if (game == null)
            {
                this.Context.Printer.PrintMessage(GlobalMessages.RestoreCommandInvalidGame);
                return;
            }

            this.Context.GameLogic.Game = game;
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}