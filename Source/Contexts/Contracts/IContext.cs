namespace BalloonsPop.Contexts.Contracts
{
    using BalloonsPop.Data.Contracts;
    using LogicProviders.Contracts;
    using BalloonsPop.Mementos;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using BalloonsPop.TopScoreBoard;
    using Controllers;

    internal interface IContext
    {
        IGameLogicProvider GameLogic { get; }

        IGamePrinter Printer { get; }

        IReader Reader { get; }

        IBalloonsData DataBase { get; }

        ITopScoreController TopScoreController { get; }

        IGamesController GamesController { get; }

        GameStateMemory Memory { get; set; }
    }
}