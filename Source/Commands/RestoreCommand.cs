namespace BalloonsPop.Commands
{
    using Contexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class RestoreCommand:ICommand
    {
        public RestoreCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            Game game;
            var savedGames = this.Context.DataBase.Games.All();

            this.Context.Printer.PrintMessage("All games are:");
            foreach (var savedGame in savedGames)
            {
                this.Context.Printer.PrintMessage(savedGame.Id);
            }
            this.Context.Printer.PrintMessage("Write the name of your game:");

            var nameOfTheGame=this.Context.Reader.ReadInput();

            game=this.Context.DataBase.Games.Find(nameOfTheGame);

            if (game == null)
            {
                this.Context.Printer.PrintMessage("Sorry, game with this name is not found.");
                return;
            }

            this.Context.GameLogic.Game = game;
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
