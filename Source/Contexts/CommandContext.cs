using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Data;
using BalloonsPop.Printer;
using BalloonsPop.Reader;
using BalloonsPop.TopScoreBoard;

namespace BalloonsPop.Contexts
{
    class CommandContext : ICommandContext
    {
        public CommandContext(IBalloonsData data, GameLogic logic,IGamePrinter printer, IReader reader, ITopScore topScore)
        {
            this.DataBase = data;
            this.GameLogic = logic;
            this.Printer = printer;
            this.Reader = reader;
            this.TopScore = topScore;
        }

        public IBalloonsData DataBase { private set; get; }

        public GameLogic GameLogic { private set; get; }

        public IGamePrinter Printer { private set; get; }

        public IReader Reader { private set; get; }

        public ITopScore TopScore { private set; get; }
    }
}
