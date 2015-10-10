namespace BalloonsPop.Engine.Contracts
{
    using Controllers.Contracts;
    using Data.Contracts;
    using LogicProviders.Contracts;
    using Printer;
    using Reader;

    public interface IGameEngine
    {
        IGameLogicProvider GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScoreController TopScoreController { get; }

        IGamesController GamesController { get; }

        void StartGame();
    }
}