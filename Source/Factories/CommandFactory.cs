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

        public ICommand CreateCommand(CommandType input)
        {
            if (this.commands.ContainsKey(input))
            {
                return this.commands[input];
            }

            switch (input)
            {
                case CommandType.Exit:
                    {
                        this.commands[CommandType.Exit] = new ExitCommand();
                        break;
                    }

                case CommandType.Restart:
                    {
                        this.commands[CommandType.Restart] = new RestartCommand();
                        break;
                    }

                case CommandType.Top:
                    {
                        this.commands[CommandType.Top] = new TopScoreCommand();
                        break;
                    }

                case CommandType.Start:
                    {
                        this.commands[CommandType.Start] = new StartCommand();
                        break;
                    }

                case CommandType.Finish:
                    {
                        this.commands[CommandType.Finish] = new FinishCommand();
                        break;
                    }

                case CommandType.Undo:
                    {
                        this.commands[CommandType.Undo] = new UndoCommand();
                        break;
                    }

                case CommandType.Save:
                    {
                        this.commands[CommandType.Save] = new SaveCommand();
                        break;
                    }

                case CommandType.Restore:
                    {
                        this.commands[CommandType.Restore] = new RestoreCommand();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            return this.commands[input];
        }
    }
}