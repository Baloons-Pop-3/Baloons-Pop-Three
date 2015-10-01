namespace BalloonsPop
{
    using Common;
    using Data;
    using Engine;
    using Printer;
    using Reader;
    using TopScoreBoard;

    internal class GameFacade
    {
        private IGenericRepository<Player> players = new TxtFileRepository<Player>(GlobalConstants.TopScorePath);
        private IGenericRepository<Game> games = new TxtFileRepository<Game>(GlobalConstants.GamesPath);

        //// TODO: implement logic for saving games(this is the repository used for)
        private GameField field = new GameField(GlobalConstants.FieldBoardRows, GlobalConstants.FieldBoardCols);
        private IReader reader = new ConsoleReader();
        private IGamePrinter printer = new ConsoleGamePrinter();
        private ITopScore topScore;
        private Game balloonsGame;
        private GameLogic gameLogic;
        private IBalloonsData db;
        private IGameEngine engine;

        public void Start()
        {
            this.balloonsGame = new Game(this.field);
            this.gameLogic = new GameLogic(this.balloonsGame);
            this.db = new BalloonsData(this.players, this.games);
            this.topScore = new TopScore(this.db);
            this.engine = new GameEngine(this.gameLogic, this.printer, this.reader, this.db, this.topScore);

            this.engine.StartGame();
        }
    }
}