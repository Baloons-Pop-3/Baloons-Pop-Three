namespace BalloonsPop.Engine
{
    using Contexts;
    using Data;
    using Factories;
    using Printer;
    using Reader;
    using TopScoreBoard;

    internal interface IGameEngine
    {
        GameLogic GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }

        ICommandContext Context { get; }

        ICommandFactory Factory { get; }

        void StartGame();
    }
}