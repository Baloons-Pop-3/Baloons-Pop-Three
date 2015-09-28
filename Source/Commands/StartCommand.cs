using System;
using BalloonsPop.Common;
using BalloonsPop.Contexts;

namespace BalloonsPop.Commands
{
    class StartCommand:ICommand
    {
        public StartCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintGameBoard(this.Context.GameLogic.Game.Field);
        }
    }
}
