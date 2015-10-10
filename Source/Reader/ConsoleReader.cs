namespace BalloonsPop.Reader
{
    using System;

    internal sealed class ConsoleReader : IReader
    {
        private static ConsoleReader instance;

        private ConsoleReader()
        {
        }

        public static ConsoleReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleReader();
                }

                return instance;
            }
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}