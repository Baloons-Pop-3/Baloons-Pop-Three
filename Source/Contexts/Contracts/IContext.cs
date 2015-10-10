namespace BalloonsPop.Contexts.Contracts
{
    using Controllers.Contracts;
    using Data.Contracts;
    using LogicProviders.Contracts;
    using Mementos;
    using Printer.Contracts;
    using Reader.Contracts;

    public interface IContext
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