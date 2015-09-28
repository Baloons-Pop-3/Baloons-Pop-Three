using BalloonsPop.Common;
using BalloonsPop.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Commands
{
    class FinishCommand:ICommand
    {
       public FinishCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            Player player = new Player();
            player.Score = this.Context.GameLogic.Game.ShootCounter;

            this.Context.Printer.PrintMessage(GlobalMessages.ADD_TO_TOPSCORE_MSG);
            player.Name = this.Context.Reader.ReadInput();

            this.Context.TopScore.AddPlayer(player);
        }
    }
}

