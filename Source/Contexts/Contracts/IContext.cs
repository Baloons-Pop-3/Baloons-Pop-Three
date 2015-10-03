namespace BalloonsPop.Contexts.Contracts
{
    using BalloonsPop.Data.Contracts;
    using LogicProviders.Contracts;
    using BalloonsPop.Mementos;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;

    internal interface IContext
    {
        IGameLogicProvider GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }

        GameStateMemory Memory { get; set; }
    }
}