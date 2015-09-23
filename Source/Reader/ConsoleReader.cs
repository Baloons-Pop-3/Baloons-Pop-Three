using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Reader
{
    class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
