using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Commands;
using BalloonsPop.Contexts;

namespace BalloonsPop.Factories
{
    class CommandFactory : ICommandFactory
    {
        public CommandFactory(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { private set; get; }

        public ICommand CreateCommand(CommandType input)
        {
            switch (input)
            {
                case CommandType.Exit: return new ExitCommand(this.Context);
                case CommandType.Restart: return new RestartCommand(this.Context);
                case CommandType.Top: return new TopScoreCommand(this.Context);
                case CommandType.Start: return new StartCommand(this.Context);
                case CommandType.Finish:return new FinishCommand(this.Context);
                case CommandType.Undo: return new UndoCommand(this.Context);
                case CommandType.Save: return new SaveCommand(this.Context);
                case CommandType.Restore: return new RestoreCommand(this.Context);
                default: return new NullCommand(this.Context);
            }
        }
    }
}
