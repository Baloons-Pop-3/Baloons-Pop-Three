namespace BalloonsPop.Contexts.Contracts
{
    using BalloonsPop.Controllers.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Mementos;
    using BalloonsPop.Printer;
    using Printer.Contracts;
    using BalloonsPop.Reader.Contracts;
    using LogicProviders.Contracts;

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