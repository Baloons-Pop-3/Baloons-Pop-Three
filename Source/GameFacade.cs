//-----------------------------------------------------------------------
// <copyright file="GameFacade.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the GameFacade class.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop
{
    using BalloonsPop.Common.Constants;
    using BalloonsPop.Controllers;
    using BalloonsPop.Controllers.Contracts;
    using BalloonsPop.Data;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Data.Repositories;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Contracts;
    using BalloonsPop.LogicProviders;
    using BalloonsPop.LogicProviders.Contracts;
    using BalloonsPop.Models;
    using BalloonsPop.Printer;
    using BalloonsPop.Printer.Contracts;
    using BalloonsPop.Reader;
    using BalloonsPop.Reader.Contracts;

    /// <summary>
    /// Class that hides the complex logic for creating a game.
    /// </summary>
    internal class GameFacade
    {
        /// <summary>
        /// The players in the text file repository.
        /// </summary>
        private readonly IGenericRepository<Player> players = new TxtFileRepository<Player>(GlobalConstants.TopScorePath);

        /// <summary>
        /// The games in the text file repository.
        /// </summary>
        private readonly IGenericRepository<Game> games = new TxtFileRepository<Game>(GlobalConstants.GamesPath);

        /// <summary>
        /// The field of the game.
        /// </summary>
        private readonly GameField field = new GameField(GlobalConstants.DefaultLevelRows, GlobalConstants.DefaultLevelCols);

        /// <summary>
        /// Instance of a console reader.
        /// </summary>
        private readonly IReader reader = ConsoleReader.Instance;

        /// <summary>
        /// Instance of a console printer.
        /// </summary>
        private readonly IGamePrinter printer = ConsoleGamePrinter.Instance;

        /// <summary>
        /// The game that will be started.
        /// </summary>
        private Game balloonsGame;

        /// <summary>
        /// The controller for the top scores.
        /// </summary>
        private ITopScoreController topScoreController;

        /// <summary>
        /// The controller for the game.
        /// </summary>
        private IGamesController gamesController;

        /// <summary>
        /// The logic for the game.
        /// </summary>
        private IGameLogicProvider gameLogic;

        /// <summary>
        /// The database for the game.
        /// </summary>
        private IBalloonsData data;

        /// <summary>
        /// The engine for the game.
        /// </summary>
        private IGameEngine engine;

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