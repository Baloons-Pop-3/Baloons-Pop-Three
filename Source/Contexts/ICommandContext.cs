using BalloonsPop.Data;
using BalloonsPop.Printer;
using BalloonsPop.Reader;
using BalloonsPop.TopScoreBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Contexts
{
    interface ICommandContext
    {
        GameLogic GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }
    }
}
