namespace BalloonsPop.Reader
{
    using System;

    internal class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}