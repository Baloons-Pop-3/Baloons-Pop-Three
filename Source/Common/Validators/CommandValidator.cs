namespace BalloonsPop
{
    using System;

    internal class CommandValidator
    {
        private CommandType type;

        public CommandValidator()
        {
        }

        public CommandType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        internal static bool IsValidCommand(string input)
        {
            CommandType command;
            bool isValidCommand = Enum.TryParse(input, true, out command);

            if (!isValidCommand)
            {
                return false;
            }

            return true;
        }

        internal static CommandType GetType(string input)
        {
            CommandType type = (CommandType)Enum.Parse(typeof(CommandType), input, true);

            return type;
        }
    }
}
