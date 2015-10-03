namespace BalloonsPop.Factories
{
    using System.Collections.Generic;
    using BalloonsPop.Commands;
    using BalloonsPop.Commands.Contracts;
    using BalloonsPop.Common.Enums;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Factories.Contracts;

    internal class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<CommandType, ICommand> commands = new Dictionary<CommandType, ICommand>();

        public CommandFactory(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public ICommand CreateCommand(CommandType input)
        {
            if (this.commands.ContainsKey(input))
            {
                return this.commands[input];
            }

            switch (input)
            {
                case CommandType.Exit:
                    this.commands[CommandType.Exit] = new ExitCommand(this.Context); break;
                case CommandType.Restart:
                    this.commands[CommandType.Restart] = new RestartCommand(this.Context); break;
                case CommandType.Top:
                    this.commands[CommandType.Top] = new TopScoreCommand(this.Context); break;
                case CommandType.Start:
                    this.commands[CommandType.Start] = new StartCommand(this.Context); break;
                case CommandType.Finish:
                    this.commands[CommandType.Finish] = new FinishCommand(this.Context); break;
                case CommandType.Undo:
                    this.commands[CommandType.Undo] = new UndoCommand(this.Context); break;
                case CommandType.Save:
                    this.commands[CommandType.Save] = new SaveCommand(this.Context); break;
                case CommandType.Restore:
                    this.commands[CommandType.Restore] = new RestoreCommand(this.Context); break;
                default:
                    this.commands[CommandType.Restore] = new NullCommand(this.Context); break;
            }

            return this.commands[input];
        }
    }
}