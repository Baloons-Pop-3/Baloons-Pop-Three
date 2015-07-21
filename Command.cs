namespace BalloonsPops
{
    using System;

    internal class Command
    {
        private string name;

        public Command()
        {
        }

        // TODO: Check if the property is better to be of type CommandType
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // TODO: static class Validator
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("command name", "cannot be null or empty");
                }

                this.name = value;
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
    }
}
