namespace BalloonsPop.Engine.Contracts
{
    using Common.Enums;
    using Contexts.Contracts;
    using Controllers.Contracts;
    using Data.Contracts;
    using Factories.Contracts;
    using Printer;
    using Reader;
    using LogicProviders.Contracts;
    using Common.Validators;

    internal interface IGameEngine
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