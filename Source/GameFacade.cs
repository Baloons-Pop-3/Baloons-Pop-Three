namespace BalloonsPop
{
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Contexts;
    using BalloonsPop.Contexts.Contracts;
    using BalloonsPop.Controllers;
    using BalloonsPop.Controllers.Contracts;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Data.Repositories;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.Factories;
    using BalloonsPop.Factories.Contracts;
    using BalloonsPop.Models;
    using BalloonsPop.Printer;
    using BalloonsPop.Reader;
    using LogicProviders.Contracts;

    internal class GameFacade
    {
        private IGenericRepository<Player> players = new TxtFileRepository<Player>(GlobalConstants.TopScorePath);
        private IGenericRepository<Game> games = new TxtFileRepository<Game>(GlobalConstants.GamesPath);

        private GameField field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);
        private Game balloonsGame;
        private IReader reader = ConsoleReader.Instance;
        private IGamePrinter printer = ConsoleGamePrinter.Instance;
        private ITopScoreController topScoreController;
        private IGamesController gamesController;
        private IGameLogicProvider gameLogic;
        private IBalloonsData data;
        private IGameEngine engine;

        public void Start()
        {
            this.balloonsGame = new Game(this.field);
            this.gameLogic = new GameLogicProvider(this.balloonsGame);
            this.data = new BalloonsData(this.players, this.games);
            this.topScoreController = new TopScoreController(this.data.Players);
            this.gamesController = new GamesController(this.data.Games);
            this.engine = new GameEngine(this.gameLogic, this.printer, this.reader, this.data, this.topScoreController, this.gamesController);

            this.engine.StartGame();
        }
    }
}