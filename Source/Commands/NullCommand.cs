using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Contexts;

namespace BalloonsPop.Commands
{
    class NullCommand : ICommand
    {
        public NullCommand(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public void Execute()
        {
        }
    }
}
