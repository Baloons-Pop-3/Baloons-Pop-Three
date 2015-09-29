namespace BalloonsPop
{
    using System;
    using System.Linq;

    internal class CommandValidator<T> 
    { 
        public CommandValidator()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("should pass enumaration");
            }
        }

        internal bool IsValidCommand(string input)
        {
            // transform the string into string with first uppercase letter.
            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

            if (!Enum.IsDefined(typeof(T), input))
            {
                return false;
            }

            return true;
        }

        internal T GetType(string input)
        {
            T type = (T)Enum.Parse(typeof(T), input, true);
            return type;
        }
    }
}
