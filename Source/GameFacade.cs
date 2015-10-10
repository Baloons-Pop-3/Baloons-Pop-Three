//-----------------------------------------------------------------------
// <copyright file="GameFacade.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameFacade class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop
{
    using Common.Constants;
    using Controllers;
    using Controllers.Contracts;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Engine;
    using Engine.Contracts;
    using LogicProviders;
    using LogicProviders.Contracts;
    using Models;
    using Printer;
    using Printer.Contracts;
    using Reader;
    using Reader.Contracts;

    /// <summary>
    /// Class that hides the complex logic for creating a game.
    /// </summary>
    internal class GameFacade
    {
        private readonly IGenericRepository<Player> players = new TxtFileRepository<Player>(GlobalConstants.TopScorePath);
        private readonly IGenericRepository<Game> games = new TxtFileRepository<Game>(GlobalConstants.GamesPath);
        private readonly GameField field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);
        private readonly IReader reader = ConsoleReader.Instance;
        private readonly IGamePrinter printer = ConsoleGamePrinter.Instance;
        private Game balloonsGame;
        private ITopScoreController topScoreController;
        private IGamesController gamesController;
        private IGameLogicProvider gameLogic;
        private IBalloonsData data;
        private IGameEngine engine;

        public GameFacade()
        {
            this.players = new TxtFileRepository<Player>(GlobalConstants.TopScorePath);
            this.games = new TxtFileRepository<Game>(GlobalConstants.GamesPath);
            this.field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);
            this.reader = ConsoleReader.Instance;
            this.printer = ConsoleGamePrinter.Instance;
        }

        /// <summary>
        /// Starts a new console game.
        /// </summary>
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