namespace BalloonsPop.Engine
{
    using TopScoreBoard;
    using Data;
    using Printer;
    using Reader;
    using Contexts;
    using Factories;

    interface IGameEngine
    {
        GameLogic GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }

        ICommandContext Context { get; }

        ICommandFactory Factory { get; }

        void Init();
    }
}
