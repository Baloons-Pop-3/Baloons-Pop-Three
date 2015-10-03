﻿namespace BalloonsPop.Contexts
{
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Mementos;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;

    internal class CommandContext : ICommandContext
    {
        public CommandContext(IBalloonsData data, GameLogic logic, IGamePrinter printer, IReader reader, ITopScore topScore)
        {
            this.DataBase = data;
            this.GameLogic = logic;
            this.Printer = printer;
            this.Reader = reader;
            this.TopScore = topScore;

            this.Memory = new GameStateMemory();
        }

        public IBalloonsData DataBase { get; private set; }

        public GameLogic GameLogic { get; private set; }

        public IGamePrinter Printer { get; private set; }

        public IReader Reader { get; private set; }

        public ITopScore TopScore { get; private set; }

        public GameStateMemory Memory { get; set; }
    }
}