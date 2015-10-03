namespace BalloonsPop.Commands
{
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Models;

    internal class SaveCommand : ICommand
    {
        public SaveCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage(GlobalMessages.SaveGameMsg);
            var gameId = this.Context.Reader.ReadInput();

            Game savedGame = this.Context.GameLogic.Game.Clone();
            savedGame.Id = gameId;

            this.Context.DataBase.Games.Add(savedGame);

            this.Context.Printer.PrintMessage(GlobalMessages.SavedGameMsg);
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}