using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    using Engine;
    using Printer;
    using Reader;
    using Common;
    // veche pisha na c#, uraaaaaaaaaaaaaaa, mnogo e yako tova be!
    class EntryPoint
    {

        static void Main(string[] args)
        {
            GameFacade game = new GameFacade();

            game.Start();
        }
    }
}
