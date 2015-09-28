using BalloonsPop.Commands;
using BalloonsPop.Contexts;

namespace BalloonsPop.Factories
{


    interface ICommandFactory
    {
        ICommandContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}
