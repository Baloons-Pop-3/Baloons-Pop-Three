﻿namespace BalloonsPop.Engine.Contracts
{
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Factories.Contracts;
    using LogicProviders.Contracts;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;

    internal interface IGameEngine
    {
        IGameLogicProvider GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }

        IContext Context { get; }

        ICommandFactory Factory { get; }

        void StartGame();
    }
}