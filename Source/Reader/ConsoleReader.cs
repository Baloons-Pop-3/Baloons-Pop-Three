using System;

namespace BalloonsPop.Reader
{
    internal class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}