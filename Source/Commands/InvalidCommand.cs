using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Contexts;

namespace BalloonsPop.Commands
{
    class InvalidCommand : ICommand
    {
        public InvalidCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
            Context.Printer.PrintMessage("Invalid command type. Please try again");
        }
    }
}
