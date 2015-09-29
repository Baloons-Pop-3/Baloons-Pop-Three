namespace BalloonsPop
{
    using System;
    using System.Linq;

    internal class CommandValidator
    {
        public CommandType Type { get; set; }

        internal static bool IsValidCommand(string input)
        {
            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

            if (!Enum.IsDefined(typeof(CommandType), input))
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
