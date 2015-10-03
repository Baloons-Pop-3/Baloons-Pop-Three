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
            if (!this.commands.ContainsKey(input))
            {
                this.commands
            }
            switch (input)
            {
                case CommandType.Exit:
                    if (!this.commands.ContainsKey(CommandType.Exit))
                    {
                        this.commands[CommandType.Exit] = new ExitCommand(this.Context);
                    }

                    return this.commands[CommandType.Exit];

                case CommandType.Restart:
                    if (!this.commands.ContainsKey(CommandType.Restart))
                    {
                        this.commands[CommandType.Restart] = new RestartCommand(this.Context);
                    }

                    return this.commands[CommandType.Restart];

                case CommandType.Top:
                    if (!this.commands.ContainsKey(CommandType.Top))
                    {
                        this.commands[CommandType.Top] = new TopScoreCommand(this.Context);
                    }

                    return this.commands[CommandType.Top];

                case CommandType.Start:
                    if (!this.commands.ContainsKey(CommandType.Start))
                    {
                        this.commands[CommandType.Start] = new StartCommand(this.Context);
                    }

                    return this.commands[CommandType.Start];

                case CommandType.Finish:
                    if (!this.commands.ContainsKey(CommandType.Finish))
                    {
                        this.commands[CommandType.Finish] = new FinishCommand(this.Context);
                    }

                    return this.commands[CommandType.Finish];

                case CommandType.Undo:
                    if (!this.commands.ContainsKey(CommandType.Undo))
                    {
                        this.commands[CommandType.Undo] = new UndoCommand(this.Context);
                    }

                    return this.commands[CommandType.Undo];

                case CommandType.Save:
                    if (!this.commands.ContainsKey(CommandType.Save))
                    {
                        this.commands[CommandType.Save] = new SaveCommand(this.Context);
                    }

                    return this.commands[CommandType.Save];

                case CommandType.Restore:
                    if (!this.commands.ContainsKey(CommandType.Restore))
                    {
                        this.commands[CommandType.Restore] = new RestoreCommand(this.Context);
                    }

                    return this.commands[CommandType.Restore];

                default:
                    return new NullCommand(this.Context);
            }
        }
    }
}