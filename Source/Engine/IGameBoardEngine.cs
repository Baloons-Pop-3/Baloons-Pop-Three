namespace BalloonsPop.Engine
{
    using Data;
    using Printer;
    using Reader;

    interface IGameBoardEngine
    {
        GameLogic GameLogic { get; }

        IPrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        void Init();
    }
}
