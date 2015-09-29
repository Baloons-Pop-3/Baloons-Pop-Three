using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Contexts;
using BalloonsPop.Common;

namespace BalloonsPop.Commands
{
    class SaveCommand : ICommand
    {
        public SaveCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintMessage("Write the name of your game: ");
            var gameId = this.Context.Reader.ReadInput();

            Game savedGame = this.Context.GameLogic.Game.Clone();
            savedGame.Id = gameId;
      
            this.Context.DataBase.Games.Add(savedGame);

            this.Context.Printer.PrintMessage(GlobalMessages.SAVE_GAME_MSG);
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
