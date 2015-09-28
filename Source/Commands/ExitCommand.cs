using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Contexts;

namespace BalloonsPop.Commands
{
    class ExitCommand : ICommand
    {
        public ExitCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
            Context.Printer.PrintMessage("Thank you for playing this stupid game :) Welcome back");
            return;
        }
    }
}
