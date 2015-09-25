namespace BalloonsPop.Engine
{
    using TopScoreBoard;
    using Data;
    using Printer;
    using Reader;

    interface IGameEngine
    {
        GameLogic GameLogic { get; }

        IPrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScore TopScore { get; }

        void Init();
    }
}
