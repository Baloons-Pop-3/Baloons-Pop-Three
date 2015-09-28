using BalloonsPop.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Commands
{
    class TopScoreCommand:ICommand
    {
        public TopScoreCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            this.Context.Printer.PrintTopScore(this.Context.TopScore.GetTop(4));
        }
    }
}
