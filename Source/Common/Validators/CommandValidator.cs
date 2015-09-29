namespace BalloonsPop
{
    using System;
    using System.Linq;

    internal class CommandValidator
    { 
        internal bool IsValidCommand(string input)
        {
            // transform the string into string with first uppercase letter.
            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

            if (!Enum.IsDefined(typeof(CommandType), input))
            {
                return false;
            }

            return true;
        }

        internal CommandType GetType(string input)
        {
            CommandType type = (CommandType)Enum.Parse(typeof(CommandType), input, true);
            return type;
        }
    }
}
