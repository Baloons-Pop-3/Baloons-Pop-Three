namespace BalloonsPop.Factories
{
    using System.Collections.Generic;
    using BalloonsPop.Commands;
    using BalloonsPop.Contexts;

    internal class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<CommandType, ICommand> characters = new Dictionary<CommandType, ICommand>();

        public CommandFactory(ICommandContext context)
        {
            this.Context = context;
        }

        public ICommandContext Context { get; private set; }

        public ICommand CreateCommand(CommandType input)
        {
            switch (input)
            {
                case CommandType.Exit:
                    if (!this.characters.ContainsKey(CommandType.Exit))
                    {
                        this.characters[CommandType.Exit] = new ExitCommand(this.Context);
                    }

                    return this.characters[CommandType.Exit];

                case CommandType.Restart:
                    if (!this.characters.ContainsKey(CommandType.Restart))
                    {
                        this.characters[CommandType.Restart] = new RestartCommand(this.Context);
                    }

                    return this.characters[CommandType.Restart];

                case CommandType.Top:
                    if (!this.characters.ContainsKey(CommandType.Top))
                    {
                        this.characters[CommandType.Top] = new TopScoreCommand(this.Context);
                    }

                    return this.characters[CommandType.Top];

                case CommandType.Start:
                    if (!this.characters.ContainsKey(CommandType.Start))
                    {
                        this.characters[CommandType.Start] = new StartCommand(this.Context);
                    }

                    return this.characters[CommandType.Start];

                case CommandType.Finish:
                    if (!this.characters.ContainsKey(CommandType.Finish))
                    {
                        this.characters[CommandType.Finish] = new FinishCommand(this.Context);
                    }

                    return this.characters[CommandType.Finish];

                case CommandType.Undo:
                    if (!this.characters.ContainsKey(CommandType.Undo))
                    {
                        this.characters[CommandType.Undo] = new UndoCommand(this.Context);
                    }

                    return this.characters[CommandType.Undo];

                case CommandType.Save:
                    if (!this.characters.ContainsKey(CommandType.Save))
                    {
                        this.characters[CommandType.Save] = new SaveCommand(this.Context);
                    }

                    return this.characters[CommandType.Save];

                case CommandType.Restore:
                    if (!this.characters.ContainsKey(CommandType.Restore))
                    {
                        this.characters[CommandType.Restore] = new RestoreCommand(this.Context);
                    }

                    return this.characters[CommandType.Restore];

                default:
                    return new NullCommand(this.Context);
            }
        }
    }
}