namespace BalloonsPop.Commands
{
    using BalloonsPop.Common;
    using BalloonsPop.Contexts;

    internal class SaveCommand : ICommand
    {
        public SaveCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage("Write the name of your game: ");
            var gameId = this.Context.Reader.ReadInput();

            Game savedGame = this.Context.GameLogic.Game.Clone();
            savedGame.Id = gameId;

            this.Context.DataBase.Games.Add(savedGame);

            this.Context.Printer.PrintMessage(GlobalMessages.SaveGameMsg);
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}